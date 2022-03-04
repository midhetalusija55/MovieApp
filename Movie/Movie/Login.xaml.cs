using System;
using Movie.Models;
using Movie.Common.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Movie
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public User registrovanikorisnik;
        public Login(User _user)
        {
            InitializeComponent();
            registrovanikorisnik = _user;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (registrovanikorisnik.Email == entryEmail.Text && registrovanikorisnik.Password == entryPassword.Text)
            {
                await Navigation.PushModalAsync(new HomePage(registrovanikorisnik));
            }
            else
            {
                await DisplayAlert("Error", "Check your e-mail or password!", "OK");
            }

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registration());
        }
    }
}