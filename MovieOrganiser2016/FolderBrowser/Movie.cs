using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderBrowser
{
    class Movie
    {
        public string FolderName { get; set; }



        //public string FolderName { get; set; }
        private string _folderName;
        
        public string FolderName
        {
            get
            {
                return _folderName;
            }
            set
            {
                this._folderName = value;
            }
        }

        public string GetFirstPart()
        {
            string[] parts = this._folderName.Split('(');

            return parts[0];
        }




    }
}
