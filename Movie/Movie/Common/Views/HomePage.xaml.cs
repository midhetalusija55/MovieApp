using Movie.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Movie
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public User registrovanikorisnik;
        public HomePage(User _user)
        {
            InitializeComponent();
            registrovanikorisnik = _user;
        }
    }

    
}
