using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace FlickrAlbumSort
{
    /// <summary>
    /// Settings values.
    /// Implement INotifyPropertyChanged.
    /// Persist settings to xml file.
    /// </summary>
    /// <remarks>
    /// <para>
    /// You should create only once instance of this class. Pass this instance
    /// to any class or method that needs to access the settings.
    /// </para>
    /// </remarks>
    public class Settings : SimpleSettings.SettingsBase
    {
        // Properties that are serialized, and trigger the PropertyChanged events.

        // It would be convenient to make this a Dictionary<string, User>. But
        // Dictionary does not automatically serialize to XML, while List does.
        private BindingList<User> flickrLoginAccountListValue = new BindingList<User>();
        public BindingList<User> FlickrLoginAccountList
        {
            get { return flickrLoginAccountListValue; }
            set { SetProperty(ref flickrLoginAccountListValue, value, true); }
        }

        private string flickrLoginAccountNameValue = "";
        public string FlickrLoginAccountName
        {
            get { return flickrLoginAccountNameValue; }
            set { SetProperty(ref flickrLoginAccountNameValue, value, true); }
        }

        private Point formAddLoginAccountLocationValue;
        public Point FormAddLoginAccountLocation
        {
            get { return formAddLoginAccountLocationValue; }
            set { SetProperty(ref formAddLoginAccountLocationValue, value, true); }
        }

        private Point formMainLocationValue;
        public Point FormMainLocation
        {
            get { return formMainLocationValue; }
            set { SetProperty(ref formMainLocationValue, value, true); }
        }

        private Size formMainSizeValue;
        public Size FormMainSize
        {
            get { return formMainSizeValue; }
            set { SetProperty(ref formMainSizeValue, value, true); }
        }

        private string sortOrderValue = "";
        public string SortOrder
        {
            get { return sortOrderValue; }
            set { SetProperty(ref sortOrderValue, value, true); }
        }

        // Properties which are not persisted nor trigger property changed.
        // There are none for this project

        // Methods
        // Load, Save, and SaveIfChanged methods must be defined.
        public static Settings Load()
        {
            return SimpleSettings.SettingsBase.Load<Settings>();
        }
        public void Save()
        {
            base.Save(typeof(Settings));
        }
        public void SaveIfChanged()
        {
            base.SaveIfChanged(typeof(Settings));
        }

        // Add a new user or replace an existing user to the FlickrLoginAccountName list.
        // By using this method, we trigger the property changed event and set IsChanged.
        // If the user replaces an element in the list directly, these don't occur.
        public void AddReplaceFlickrLoginAccountName(User newUser)
        {
            // Find where to insert in the list.
            // It's a small list, don't bother with binary search
            int index = 0;
            while (index < FlickrLoginAccountList.Count)
            {
                int compare = String.Compare(FlickrLoginAccountList[index].UserName, newUser.UserName, StringComparison.OrdinalIgnoreCase);
                if (compare == 0)
                {
                    // Found matching name, replace it
                    FlickrLoginAccountList[index] = newUser;
                    break;
                }
                else if (compare > 0)
                {
                    // Found name beyond the new user name, so insert before here.
                    FlickrLoginAccountList.Insert(index, newUser);
                    break;
                }
                index++;
            }
            if (index >= FlickrLoginAccountList.Count)
            {
                // NewUser is beyond end of list. Add to the end.
                FlickrLoginAccountList.Add(newUser);
            }

            OnPropertyChanged(nameof(FlickrLoginAccountList));
            IsChanged = true;
            FlickrLoginAccountList.ResetBindings();
            FlickrLoginAccountName = newUser.UserName;
        }

        // Remove a user in the FlickrLoginAccountName list.
        // By using this method, we trigger the property changed event and set IsChanged.
        public void RemoveFlickrLoginAccountName(User user)
        {
            int index = FlickrLoginAccountList.ToList<User>().FindIndex(x => x.UserName == user.UserName);
            if (index < 0)
            {
                throw new KeyNotFoundException(
                    string.Format("Unexpected error. The user '{0}' is not found.",
                    user.UserName));
            }
            else
            {
                FlickrLoginAccountList.RemoveAt(index);
                OnPropertyChanged(nameof(FlickrLoginAccountList));
                IsChanged = true;
                FlickrLoginAccountList.ResetBindings();
                if (FlickrLoginAccountList.Count == 0)
                {
                    FlickrLoginAccountName = "";
                }
                else if (index < FlickrLoginAccountList.Count)
                {
                    FlickrLoginAccountName = FlickrLoginAccountList[index].UserName;
                }
                else
                {
                    FlickrLoginAccountName = FlickrLoginAccountList[index - 1].UserName;
                }
            }
        }
    }
}
