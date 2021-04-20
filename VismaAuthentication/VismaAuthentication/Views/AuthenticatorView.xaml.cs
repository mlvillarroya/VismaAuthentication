using VismaAuthentication.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace VismaAuthentication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthenticatorView : ContentPage
    {
        public AuthenticatorView()
        {
            InitializeComponent();
            BindingContext = new AuthenticatorViewModel(Navigation);
        }
    }
}