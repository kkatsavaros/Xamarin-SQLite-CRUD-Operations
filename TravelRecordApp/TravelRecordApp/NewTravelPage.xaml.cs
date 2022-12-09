using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLite;
using App1.Model;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Post post = new Post()                        // using App1.Model;
            {
                Experience = experienceEntry.Text
            };


            // Δημιουργία του Connection.
            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                SQLiteConnection conn = sQLiteConnection;     // using SQLite.Net; Δημιουργία Object για αυτό το Connection.

                conn.CreateTable<Post>();                     // Δημιoυργία του πίνακα Post, Generics.
                int rows = conn.Insert(post);                 // Εισαγωγή και πόσες γραμμές έγιναν εισαγωγή.

                //conn.Close();                               // Κλείνουμε το Connection

                if (rows > 0)
                {
                    DisplayAlert("Success", "Experience succesfully inserted", "ok");
                }
                else
                {
                    DisplayAlert("Failure", "Experience failed to be inserted", "ok");
                }


                Navigation.PushAsync(new HistoryPage());

            }
        }




    }
}