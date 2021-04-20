using VismaAuthentication.Models;

namespace VismaAuthentication.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private GoogleResponseModel _userInfo;
        public GoogleResponseModel UserInfo
        {
            get { return _userInfo; }
            set {
                _userInfo = value;
                OnPropertyChanged();
            }
        }

        public DashboardViewModel(GoogleResponseModel userInfo)
        {
            this.UserInfo = userInfo;
        }
    }
}
