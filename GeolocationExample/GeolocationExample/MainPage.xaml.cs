using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GeolocationExample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        } 



        private async void ButtonLocation_Clicked(object sender, EventArgs e)
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync(request);
                
                if (location != null)
                { 
                    labelLatitude.Text = "Latitude: " + location.Latitude.ToString();
                    labelLongitude.Text = "Longitude:" + location.Longitude.ToString();
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Failed", fnsEx.Message, "OK");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Failed", pEx.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Failed", ex.Message, "OK");
            }
        }
    }
}
