using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaAuthentication.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VismaAuthentication.ViewModels;

namespace VismaAuthentication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthenticatorView : ContentPage
    {
        public AuthenticatorView()
        {
            InitializeComponent();
            BindingContext = new AuthenticatorViewModel();
        }
    }
}