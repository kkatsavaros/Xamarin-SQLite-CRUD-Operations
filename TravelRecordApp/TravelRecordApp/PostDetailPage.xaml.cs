using App1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLite;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetailPage : ContentPage
    {
        Post selectedPost;     // Δημιουργία Global property τύπου Post στην κλάση PostDetailPage.

        public PostDetailPage(Post selectedPost)
        {
            InitializeComponent();

            this.selectedPost = selectedPost;                // <----

            experienceEntry.Text = selectedPost.Experience;  // Για να το βλέπουμε και μετά να το αλλάξουμε.
        }

        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            selectedPost.Experience = experienceEntry.Text;

            // Δημιουργία του Connection.
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();                   // Δημιoυργία του πίνακα Post, Generics.
                int rows = conn.Update(selectedPost);       // 

                if (rows > 0)
                    DisplayAlert("Success", "Experience succesfully updated", "ok");
                else
                    DisplayAlert("Failure", "Experience failed to be updated", "ok");
            }

            Navigation.PushAsync(new HistoryPage());

        }


        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            // Δημιουργία του Connection.
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();                   // Δημιoυργία του πίνακα Post, Generics.
                int rows = conn.Delete(selectedPost);       // 

                if (rows > 0)
                    DisplayAlert("Success", "Experience succesfully deleted", "ok");
                else
                    DisplayAlert("Failure", "Experience failed to be deleted", "ok");
            }

            Navigation.PushAsync(new HistoryPage());

        }

    }
}