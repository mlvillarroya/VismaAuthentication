using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VismaAuthentication.Models;
using VismaAuthentication.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VismaAuthentication.ViewModels
{
    public class AuthenticatorViewModel : BaseViewModel
    {
        private GoogleResponseModel userInfo { get; set; }
        public INavigation Navigation { get; set; }
              
        const string authenticationUrl = "http://enigmatic-basin-12787.herokuapp.com/mobileauth/"; //Back end

        private JsonSerializer _serializer = new JsonSerializer();

        public ICommand GoogleCommand { get; }

        private string accessToken = string.Empty;

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        public string AuthToken
        {
            get => accessToken;
            set => SetProperty(ref accessToken, value);
        }

        public AuthenticatorViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            GoogleCommand = new Command(async () => await OnAuthenticate("Google"));
        }


        async Task OnAuthenticate(string scheme)
        {
            try
            {
                WebAuthenticatorResult r = null;

                var authUrl = new Uri(authenticationUrl + scheme);
                var callbackUrl = new Uri("xamarinessentials://");

                r = await WebAuthenticator.AuthenticateAsync(authUrl, callbackUrl);

                AuthToken = r?.AccessToken ?? r?.IdToken;
                GetUserInfoUsingToken(AuthToken);

            }
            catch (Exception ex)
            {
                AuthToken = string.Empty;
                await DisplayAlertAsync($"Failed: {ex.Message}");
            }
        }

        private async void GetUserInfoUsingToken(string authToken)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://www.googleapis.com/oauth2/v3/");
            var httpResponseMessage = await httpClient.GetAsync("tokeninfo?access_token=" + authToken);
            using (var stream = await httpResponseMessage.Content.ReadAsStreamAsync())
            using (var reader = new StreamReader(stream))
            using (var json = new JsonTextReader(reader))
            {
                var userInfo = _serializer.Deserialize<GoogleResponseModel>(json);
                Preferences.Set("UserToken", authToken);
                await Navigation.PushAsync(new DashboardView(userInfo));

            }

        }
    }
}
