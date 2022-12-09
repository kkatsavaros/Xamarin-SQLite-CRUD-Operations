using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private void loginButton_Clicked(System.Object sender, System.EventArgs e)
        {
            bool isEmailEntry = string.IsNullOrEmpty(emailEntry.Text);         // Returns true or False και ανάθεση στην isEmailEntry.
            bool isPasswordEntry = string.IsNullOrEmpty(passwordEntry.Text);   // Returns true or False και ανάθεση στην isPasswordEntry.

            if (isEmailEntry || isPasswordEntry) // Αν είναι άδειο. -  if (isEmailEntry == true || isPasswordEntry==true) // Αν είναι άδειο.
            {
                // do not Navigate
            }
            else
            {
                // Navigate
                Navigation.PushAsync(new HomePage());
            }
        }
    }
}
