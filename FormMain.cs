using FlickrNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace FlickrAlbumSort
{
    public partial class FormMain : Form
    {
        private Settings Settings { get; set; }

        // Sorting options
        private Dictionary<string, string> SortOptions { get; set; } =
            new Dictionary<string, string>
            {
                {"DateTakenOldestFirst","Date taken (oldest first)"},
                {"DateTakenNewestFirst","Date taken (newest first)"},
                {"DateUploadedOldestFirst","Date uploaded (oldest first)"},
                {"DateUploadedNewestFirst","Date uploaded (newest first)"},
                {"TitleAZ", "Title (A-Z)" },
                {"TitleZA", "Title (Z-A)" },
            };

        private FlickrManager FlickrManager { get; set; }

        // User corresponding to Settings.FlickrLoginAccountName. This is the user
        // that we are logged in as, and whose albums we will sort.
        private User AccountUser;

        private bool FormIsLoaded { get; set; } = false;

        // Checkbox that is put in the header of the dgvPhotosets.
        private CheckBox cbHeader;

        // Number of albums sorted.
        private int SortedPhotosetCount = 0;

        // The list of photosets (albums) returned by GetAlbums, and used during a search.
        // This property is set in the foreground thread, and is read but not changed by the
        // background thread. It is not changed by the foreground thread while the background 
        // thread is active.
        private SortableBindingList<Photoset> PhotosetList { get; set; }

        // The following properties are used to communicate from the background thread to the
        // foreground UI thread. They are set in the background thread, and not touched 
        // by the foreground thread until the background thread has completed. 

        // Error message returned from BG search methods. Empty if no error.
        private string BGErrorMessage { get; set; } = "";

        // List of search status strings. List has same size as PhotosetList. 
        private List<string> BGStatusList { get; set; }


        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Settings = Settings.Load();
            if (Settings.FormMainLocation.X != 0 ||
                  Settings.FormMainLocation.Y != 0)
            {
                this.Location = Settings.FormMainLocation;
            }
            if (Settings.FormMainSize.Height != 0 ||
                  Settings.FormMainSize.Width != 0)
            {
                this.Size = Settings.FormMainSize;
            }

            FlickrManager = new FlickrManager(Settings);

            // Bind the login account list.
            cbLoginAccount.DataSource = Settings.FlickrLoginAccountList;
            cbLoginAccount.DisplayMember = "CombinedName";
            if (Settings.FlickrLoginAccountName.Length > 0)
            {
                int index = cbLoginAccount.FindString(Settings.FlickrLoginAccountName);
                if (index >= 0)
                {
                    cbLoginAccount.SelectedIndex = index;
                }
            }

            // Bind the sorting option list
            cbSortOrder.DataSource = new BindingSource(SortOptions, null);
            cbSortOrder.DisplayMember = "Value";
            cbSortOrder.ValueMember = "Key";
            if (Settings.SortOrder.Length > 0)
            {
                cbSortOrder.SelectedValue = Settings.SortOrder;
            }

            // For the Album (photoset) DataGridView, add a "select all" checkbox to the header row
            // Set checkbox header to center of header cell. This is kluge code from the internet,
            // modified slightly so it looks right on my system.
            Rectangle rect = dgvPhotosets.GetCellDisplayRectangle(0, -1, true);
            rect.X = rect.X + rect.Width / 4;
            rect.Y = rect.Y + 2;

            cbHeader = new CheckBox
            {
                Name = "cbHeader",
                Size = new System.Drawing.Size(18, 18),
                Location = rect.Location
            };
            cbHeader.CheckedChanged += new EventHandler(cbHeader_CheckedChanged);
            dgvPhotosets.Controls.Add(cbHeader);

            FormIsLoaded = true;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save the form location
            Settings.FormMainLocation = this.Location;
            Settings.FormMainSize = this.Size;

            Settings.Save();
        }

        private void cbHeader_CheckedChanged(object sender, EventArgs e)
        {
            bool enable = ((CheckBox)dgvPhotosets.Controls.Find("cbHeader", true)[0]).Checked;
            for (int i = 0; i < dgvPhotosets.RowCount; i++)
            {
                dgvPhotosets[0, i].Value = enable;
            }
            dgvPhotosets.EndEdit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout dlg = new FormAbout(Settings);
            dlg.ShowDialog(this);
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            BGErrorMessage = "";

            AccountUser = (User)cbLoginAccount.SelectedItem;
            if (AccountUser == null)
            {
                MessageBox.Show("No account selected");
                return;
            }

            Stopwatch RunTimer = new Stopwatch();
            RunTimer.Start();

            bool sortSuccessful = false;
            sortSuccessful = SortPhotosets();

            RunTimer.Stop();
            if (sortSuccessful)
            {
                if (String.IsNullOrWhiteSpace(BGErrorMessage))
                {
                    MessageBox.Show(String.Format("Sorted {0} albums in {1}:{2:mm}:{3:ss}.",
                        SortedPhotosetCount,
                        (int)RunTimer.Elapsed.TotalHours, RunTimer.Elapsed, RunTimer.Elapsed));
                }
                else if (BGErrorMessage.Contains("Too many photos"))
                {
                    int index = BGErrorMessage.IndexOf(":");
                    int count = 0;
                    if (index >= 0)
                    {
                        int.TryParse(BGErrorMessage.Substring(index + 1), out count);
                    }
                    // It is not clear from the FlickrApi documentation whether the 4000 photo limit applies
                    // when searching albums (Photosets.GetPhotos).
                    // At present I assume it does not. This seems consistent with the fact that you cannot
                    // filter a Photoset.GetPhotos call by date.
                    // This error message is not currently returned by my code when searching albums, so
                    // you will never see it. But there is some disabled (ifdef) code in BGSearchPhotosets
                    // that could be enabled to return this error message.
                    MessageBox.Show("Too many photos found.\r\n\r\n" +
                        "Flickr limits the number of photos returned from a search to about 4000. " +
                        $"One of the album searches found {count} photos and the resulting photo list is not accurate.\r\n\r\n" +
                        "Reduce the size of the search by reducing the number of photos in the albums.");
                }
                else
                {
                    MessageBox.Show(BGErrorMessage);
                }
            }
        }

        private bool SortPhotosets()
        {
            // Check for no photosets enabled
            int enabledCount = 0;
            if (PhotosetList != null)
            {
                foreach (Photoset ps in PhotosetList)
                {
                    if (ps.EnableSearch)
                        enabledCount++;
                }
            }
            if (enabledCount == 0)
            {
                MessageBox.Show("No albums enabled to sort");
                return false;
            }

            FormProgress dlg = new FormProgress("Sort albums", BGSortPhotosets);

            // Show dialog with Synchronous/blocking call.
            // BGSortPhotosets() is called by dialog.
            DialogResult result = dlg.ShowDialog();
            if (result != DialogResult.OK)
                return false;

            // Update status in form.
            SortedPhotosetCount = 0;
            for (int i=0; i<PhotosetList.Count; i++)
            {
                PhotosetList[i].Status = BGStatusList[i];
                if (BGStatusList[i] == "Sorted")
                    SortedPhotosetCount++;
            }
            bindingSourcePhotosets.ResetBindings(false);

            return true;
        }

        private void btnGetAlbums_Click(object sender, EventArgs e)
        {
            BGErrorMessage = "";

            dgvPhotosets.Rows.Clear();

            AccountUser = (User)cbLoginAccount.SelectedItem;
            if (AccountUser == null)
            {
                MessageBox.Show("No account selected");
                return;
            }
            PhotosetList = new SortableBindingList<Photoset>();

            FormProgress dlg = new FormProgress("Find albums", BGFindPhotosets);

            // Show dialog with Synchronous/blocking call.
            // BGFindPhotosets() is called by dialog.
            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (!String.IsNullOrWhiteSpace(BGErrorMessage))
                {
                    MessageBox.Show(BGErrorMessage);
                }
                else
                {
                    bindingSourcePhotosets.DataSource = PhotosetList;
                    if (dgvPhotosets.Rows.Count > 0 &&
                        dgvPhotosets.Rows[0].Cells.Count > 0)
                    {
                        dgvPhotosets.CurrentCell = dgvPhotosets.Rows[0].Cells[0];
                        dgvPhotosets.Rows[0].Selected = true;
                    }
                }
            }
            else
            {
                // Search was canceled. Do nothing.
            }
        }

        private void BGFindPhotosets(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            BGErrorMessage = "";

            FlickrNet.Flickr f = FlickrManager.GetFlickrAuthInstance();
            if (f == null)
            {
                BGErrorMessage = "You must authenticate before you can download data from Flickr.";
                return;
            }

            try
            {
                int page = 1;
                int perPage = 500;
                FlickrNet.PhotosetCollection photoSets = new FlickrNet.PhotosetCollection();
                FlickrNet.PhotoSearchExtras PhotosetExtras = 0;
                do
                {
                    photoSets = f.PhotosetsGetList(AccountUser.UserId, page, perPage, PhotosetExtras);
                    foreach (FlickrNet.Photoset ps in photoSets)
                    {
                        PhotosetList.Add(new Photoset(ps));
                        int index = PhotosetList.Count - 1;
                        PhotosetList[index].OriginalSortOrder = index;
                    }
                    page = photoSets.Page + 1;
                }
                while (page <= photoSets.Pages);
            }
            catch (FlickrNet.FlickrException ex)
            {
                BGErrorMessage = "Album search failed. Error: " + ex.Message;
                return;
            }
        }

        // Background thread to sort each photoset in a list of photosets.
        private void BGSortPhotosets(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            BGErrorMessage = "";
            BGStatusList = new List<string>(PhotosetList.Count);
            for (int i=0; i<PhotosetList.Count; i++)
            {
                BGStatusList.Add("");
            }

            worker.ReportProgress(0, "Connecting");

            // Count the number of enabled photosets, so we can do an estimate of percent complete;
            int enabledPhotosets = 0;
            foreach (Photoset photoset in PhotosetList)
            {
                if (photoset.EnableSearch)
                {
                    enabledPhotosets++;
                }
            }

            if (enabledPhotosets == 0)
            {
                // No photosets are enabled. We are done.
                return;
            }

            FlickrNet.Flickr f = FlickrManager.GetFlickrAuthInstance();

            int indexEnabledPhotoset = 0;
            for (int indexPhotoset=0; indexPhotoset < PhotosetList.Count; indexPhotoset++)
            {
                if (worker.CancellationPending) // See if cancel button was clicked.
                {
                    return;
                }

                Photoset photoset = PhotosetList[indexPhotoset];

                if (photoset.EnableSearch)
                {
                    int percent = indexEnabledPhotoset * 100 / enabledPhotosets;
                    string userState = "Sorting Album " + photoset.Title;
                    worker.ReportProgress(percent, userState); // Report percent and user-status info to dialog

                    // The list of photos in the album.
                    List<FlickrNet.Photo> photoList = new List<Photo>();
                    bool success = BGGetPhotosInPhotoset(worker, f, photoset.PhotosetId, photoList);
                    if (!success)
                    {
                        return;
                    }

                    if (IsSorted(photoList))
                    {
                        BGStatusList[indexPhotoset] = "Already sorted";
                    }
                    else 
                    {
                        success = SortPhotos(f, photoset.PhotosetId, photoList);
                        if (!success)
                        {
                            BGStatusList[indexPhotoset] = "Failed";
                            return;
                        }
                        BGStatusList[indexPhotoset] = "Sorted";
                    }
                    indexEnabledPhotoset++;
                }
            }
        }

        private bool BGGetPhotosInPhotoset(BackgroundWorker worker, FlickrNet.Flickr f, string PhotosetId, List<FlickrNet.Photo> photoList)
        {
            int page = 1;
            int perpage = 500;

            // Define the photoCollection outside the for loop so that it can be used in the
            // while clause.
            FlickrNet.PhotosetPhotoCollection photoCollection = new PhotosetPhotoCollection();

            // SearchExtras defines what fields are returned by PhotosetsGetPhotos.
            // All will return all fields.
            // The app is faster if you don't download all attributes of the
            // photos and only retrieve what you need.
            FlickrNet.PhotoSearchExtras SearchExtras =
#if false
            FlickrNet.PhotoSearchExtras.All;
#else
            FlickrNet.PhotoSearchExtras.DateTaken |
            FlickrNet.PhotoSearchExtras.DateUploaded;
#endif

            do
            {
                if (worker.CancellationPending) // See if cancel button was pressed.
                {
                    return false;
                }

                try
                {
                    photoCollection = f.PhotosetsGetPhotos(PhotosetId, SearchExtras, page, perpage);
#if false
                            // It is not clear from the documentation whether the limit of 4000 photos per search applies
                            // to album searches. If an album has more than 4000 photos, is the result of GetPhotos
                            // accurate? I assume that it is. If this turns out to be false, you can enable this code.
                            if (photoCollection.Total > 3999)
                            {
                                SortErrorMessage = $"Too many photos ({photoCollection.Total}) in album {photoset.Title}";
                                return;
                            }
#endif
                    foreach (FlickrNet.Photo flickrPhoto in photoCollection)
                    {
                        photoList.Add(flickrPhoto);
                    }
                    page = photoCollection.Page + 1;
                }
                catch (FlickrNet.FlickrException ex)
                {
                    BGErrorMessage = "Getting photo metadata failed. Error: " + ex.Message;
                    return false;
                }
            }
            while (page <= photoCollection.Pages);
            
            return true;
        }

        // Sort photos in a photoset at flickr.
        // photoList contains the list of photos returned by flickr.
        private bool SortPhotos(FlickrNet.Flickr f, string PhotosetId, List<FlickrNet.Photo> photoList)
        {
            // Sort the photos using the sort method.
            photoList.Sort(PhotoCompare);

            // Create a list of photo ids in the new order
            string[] SortedPhotoIDs = new string[photoList.Count];
            for (int i = 0; i<photoList.Count; i++)
            {
                SortedPhotoIDs[i] = photoList[i].PhotoId.ToString();
            }


            try
            {
                // Send list to flickr.
                f.PhotosetsReorderPhotos(PhotosetId, SortedPhotoIDs);
            }
            catch (FlickrNet.FlickrException ex)
            {
                BGErrorMessage = "Sort failed. Error: " + ex.Message;
                return false;
            }

            return true;
        }

        // Compare function that uses the global Settings.SortOrder to determine how to sort
        // Returns
        //  <0 if A<B
        //  0 if A==B
        //  +1 if A>B
        // If an object is null, it is treated as less. 
        // If a title is null, it is treated as less.
        private int PhotoCompare(FlickrNet.Photo A, FlickrNet.Photo B)
        {
            // Check for null objects.
            if (A == null)
            {
                if (B == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else if (B == null) 
            {
                return 1;
            }

            // DateTime is a value type, so it cannot be null.
            // If the DateTaken is not known, Flickr sets it to the DateUploaded.
            if (Settings.SortOrder == "DateTakenNewestFirst")
            {
                return (-A.DateTaken.CompareTo(B.DateTaken));
            }
            else if (Settings.SortOrder == "DateUploadedOldestFirst")
            {
                return (A.DateUploaded.CompareTo(B.DateUploaded));
            }
            else if (Settings.SortOrder == "DateUploadedNewestFirst")
            {
                return (-A.DateUploaded.CompareTo(B.DateUploaded));
            }
            else if (Settings.SortOrder == "TitleAZ")
            {
                // String.Compare can handle null objects. Any string, including the empty string (""),
                // compares greater than a null reference; and two null references compare equal to each other.
                return (String.Compare(A.Title, B.Title));
            }
            else if (Settings.SortOrder == "TitleZA")
            {
                return (-String.Compare(A.Title, B.Title));
            }
            else // if (Settings.SortOrder == "DateTakenOldestFirst")
            {
                return (A.DateTaken.CompareTo(B.DateTaken));
            }
        }

        private bool IsSorted(List<FlickrNet.Photo> photoList)
        {
            for (int i = 1; i<photoList.Count; i++)
            {
                if (PhotoCompare(photoList[i-1], photoList[i]) > 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(BGErrorMessage))
            {
                MessageBox.Show(BGErrorMessage);
            }
        }

        private void btnRemoveLoginAccount_Click(object sender, EventArgs e)
        {
            var user = (User)cbLoginAccount.SelectedItem;
            if (user == null)
            {
                MessageBox.Show("No user selected.");
            }
            else
            {
                DialogResult result = MessageBox.Show("Remove the login account '" + user.CombinedName + "'?",
                    "FlickrAlbumSort", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    Settings.RemoveFlickrLoginAccountName(user);
                }
            }
        }

        private void btnAddLoginAccount_Click(object sender, EventArgs e)
        {
            FormAddLoginAccount dlg = new FormAddLoginAccount(Settings, FlickrManager);
            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                User NewUser = dlg.NewUser;
                if (NewUser != null)
                {
                    try
                    {
                        cbLoginAccount.SelectedItem = NewUser;
                        Settings.FlickrLoginAccountName = NewUser.UserName;
                    }
                    catch (Exception)
                    {
                        // Ignore error.
                    }
                }
            }
        }

        private void cbLoginAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FormIsLoaded)
            {
                User user = (User)cbLoginAccount.SelectedItem;
                if (user != null)
                {
                    Settings.FlickrLoginAccountName = user.UserName;
                }
            }
        }

        private void cbSortOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FormIsLoaded && cbSortOrder.SelectedItem != null)
            {
                var kvp = (KeyValuePair<string, string>)cbSortOrder.SelectedItem;
                Settings.SortOrder = kvp.Key;
            }

        }
    }
}
