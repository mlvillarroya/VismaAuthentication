using VismaAuthentication.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VismaAuthentication.ViewModels;

namespace VismaAuthentication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardView : ContentPage
    {
        public DashboardView(GoogleResponseModel userInfo)
        {
            InitializeComponent();
            BindingContext = new DashboardViewModel(userInfo);
        }

    }
}