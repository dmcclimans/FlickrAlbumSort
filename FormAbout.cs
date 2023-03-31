using System;
using System.Reflection;
using System.Windows.Forms;

namespace FlickrAlbumSort
{
    public partial class FormAbout : Form
    {
        private Settings Settings { get; set; }
        public FormAbout(Settings settings)
        {
            Settings = settings;
            InitializeComponent();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            lblVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                CenterToParent();
        }

        private void FormAbout_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
