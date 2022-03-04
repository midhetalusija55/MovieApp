using System;
using Movie.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Movie
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registration : ContentPage
    {
        public Registration()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (entryPassword.Text == entryConfirmPassword.Text)
            {
                User user = new User
                {
                    Name = entryName.Text,
                    Password = entryPassword.Text,
                    Email = entryEmail.Text
                };

                await Navigation.PushModalAsync(new Login(user));
            }

            else
            {
                await DisplayAlert("Error", "Fields Password and Confirm Password must be the same!", "OK");
            }
        }
    }
}