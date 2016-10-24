using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovieOrganiser2016.Helpers;

namespace Main
{
    public partial class Form1 : Form
    {
        SettingsHelper settings;
        string MovieFolder = "";

        public Form1()
        {
            settings = new SettingsHelper();
            
            InitializeComponent();

            FolderHelper hlp = new FolderHelper();
            var result = hlp.GetFolder("C:\\movies");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // check if the movie folder was stored earlier
            string MovieFolderSetting = settings.GetSetting("MovieFolder");

            // if no setting is found, then ask the user which folder he wants to open
            if(MovieFolderSetting == null || MovieFolderSetting == "" )
            {
                var folder = AskUserForMovieFolder();
                settings.WriteSettings("MovieFolder", folder);
                this.MovieFolder = folder;
            }
            else
            {
                // a setting is found, now check whether this folder exists.
                var exist = System.IO.Directory.Exists(MovieFolderSetting);
                if ( exist == false )
                {
                    var folder = AskUserForMovieFolder();
                    settings.WriteSettings("MovieFolder", folder);
                    this.MovieFolder = folder;
                }
                else
                    this.MovieFolder = MovieFolderSetting; 
            }

            labelFormTitle.Text = this.MovieFolder;
        }

        private string AskUserForMovieFolder()
        {
            var result = this.folderBrowserDialog1.ShowDialog();
            if ( result == DialogResult.OK )
            {
                return this.folderBrowserDialog1.SelectedPath;
            }
            return "";
        }

    }
}
