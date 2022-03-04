using System;
using Xamarin.Forms;

namespace Movie
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void Login_Button_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Error", "Please create your account!", "OK");
        }

        public async void NewProfile_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Registration());
        }
    }
}