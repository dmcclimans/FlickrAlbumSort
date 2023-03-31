using System;
using System.Windows.Forms;
using CenteredMessageBox;

namespace FlickrAlbumSort
{
    public partial class FormAddLoginAccount : Form
    {
        private Settings Settings { get; set; }
        FlickrManager FlickrManager { get; set; }

        // If a new user is added, this is set to the new user.
        public User NewUser = null;

        private FlickrNet.OAuthRequestToken requestToken;

        public FormAddLoginAccount(Settings settings, FlickrManager flickrManager)
        {
            Settings = settings;
            FlickrManager = flickrManager;
            InitializeComponent();
        }

        private void FormAddLoginAccount_Load(object sender, EventArgs e)
        {
            if (Settings.FormAddLoginAccountLocation.X != 0 ||
                Settings.FormAddLoginAccountLocation.Y != 0)
            {
                this.Location = Settings.FormAddLoginAccountLocation;
            }
            else
            {
                CenterToParent();
            }

            labelResult.Visible = false;
        }

        private void FormAddLoginAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save form location
            if (this.WindowState == FormWindowState.Minimized || this.WindowState == FormWindowState.Maximized)
            {
                Settings.FormAddLoginAccountLocation = this.RestoreBounds.Location;
            }
            else
            {
                Settings.FormAddLoginAccountLocation = this.Location;
            }
        }

        private void AuthenticateButton_Click(object sender, EventArgs e)
        {
            FlickrNet.Flickr f = FlickrManager.GetFlickrInstance();
            try
            {
                // Request a token. The parameter "oob" basically means Flickr shows the user the 
                // verification code on their own web page.
                requestToken = f.OAuthGetRequestToken("oob");
                string url = f.OAuthCalculateAuthorizationUrl(requestToken.Token, FlickrNet.AuthLevel.Write);
                System.Diagnostics.Process.Start(url);
                Step2GroupBox.Enabled = true;
                labelResult.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(this, ex.Message);
            }
        }

        private void CompleteAuthButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(VerifierTextBox.Text))
            {
                MessageBoxEx.Show(this, "Paste the verifier code into the text box above.");
                return;
            }

            FlickrNet.Flickr f = FlickrManager.GetFlickrInstance();
            try
            {
                var accessToken = f.OAuthGetAccessToken(requestToken, VerifierTextBox.Text);
                NewUser = new User(accessToken.Username);
                if (!string.IsNullOrWhiteSpace(accessToken.FullName))
                {
                    NewUser.RealName = accessToken.FullName;
                }
                NewUser.UserId = accessToken.UserId;
                NewUser.OAuthToken = accessToken.Token;
                NewUser.OAuthTokenSecret = accessToken.TokenSecret;

                // Add or replace the account in the account list. 
                Settings.AddReplaceFlickrLoginAccountName(NewUser);

                labelResult.Visible = true;
                btnCancel.Text = "Close";
                btnCancel.DialogResult = DialogResult.OK;
            }
            catch (FlickrNet.FlickrApiException ex)
            {
                MessageBoxEx.Show(this, "Failed to get access token./r/n" + ex.Message);
            }
        }
    }
}
