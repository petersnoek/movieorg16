using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;

namespace JeromyMovieOrg
{
    public partial class Form1 : Form
    {
        TMDbClient client;

        public Form1()
        {
            InitializeComponent();

            // Instantiate a new client, all that's needed is an API key, but it's possible to 
            // also specify if SSL should be used, and if another server address should be used.
            client = new TMDbClient("c6b31d1cdad6a56a23f0c913e2482a31");

        }

        private void searchbutton_Click(object sender, EventArgs e)
        {
            string query = this.searchtext.Text;

            // This example shows the fetching of a movie.
            // Say the user searches for "Thor" in order to find "Thor: The Dark World" or "Thor"
            SearchContainer<SearchMovie> results = client.SearchMovie(query);

            // The results is a list, currently on page 1 because we didn't specify any page.
            Console.WriteLine("Searched for movies: '" + query + "', found " + results.TotalResults + " results in " +
                              results.TotalPages + " pages");

            // Let's iterate the first few hits
            foreach (SearchMovie result in results.Results)
            {
                this.listBox1.Items.Add(result.Id + ": " + result.Title);
            }

        }
    }
}
