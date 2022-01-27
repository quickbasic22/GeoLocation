using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GeoLocation
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async private void GetLocation_Clicked(object sender, EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest()
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)

                    }, new System.Threading.CancellationToken());
                }
                if (location != null)
                {
                    Cooridates.Text = $"Latitude is {location.Latitude} Longitude is {location.Longitude}";
                    Direction.Text = $"Direction is {location.Course}";
                    Speed.Text = $"Speed is {location.Speed}";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error {ex.Message}");
            }
        }
    }
}
