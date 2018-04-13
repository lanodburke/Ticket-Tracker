using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TicketTracker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EventDetailPage : Windows.UI.Xaml.Controls.Page
    {
        public EventDetailPage()
        {
            this.InitializeComponent();
        }

        // When page is navigated to get the eventId
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.eventId = (string)e.Parameter;
        }

        private string eventId;

        // Add needleIcon to map with venueName
        public void AddSpaceNeedleIcon(string longitude, string latitude, string venueName)
        {
            var MyLandmarks = new List<MapElement>();

            BasicGeoposition snPosition = new BasicGeoposition { Latitude = Convert.ToDouble(latitude), Longitude = Convert.ToDouble(longitude) };
            Geopoint snPoint = new Geopoint(snPosition);

            var spaceNeedleIcon = new MapIcon
            {
                Location = snPoint,
                NormalizedAnchorPoint = new Point(0.5, 1.0),
                ZIndex = 0,
                Title = venueName
            };

            MyLandmarks.Add(spaceNeedleIcon);

            var LandmarksLayer = new MapElementsLayer
            {
                ZIndex = 1,
                MapElements = MyLandmarks
            };

            myMap.Layers.Add(LandmarksLayer);

            myMap.Center = snPoint;
            myMap.ZoomLevel = 14;
        }

        // Display no connection dialog box
        private async void DisplayNoWifiDialog()
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = "Error Occured.",
                Content = "Cannot get event information at this time. Sorry for the inconvenience",
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await noWifiDialog.ShowAsync();
        }

        // When page is loaded call this method
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // event details
                RootObject1 myDetails = await TicketMasterDataEventDetails.GetEventDetails(this.eventId);
                // if object is not null
                if (myDetails != null)
                {
                    // event image
                    eventImage.Source = myDetails.image;
                    if (myDetails.name != null)
                    {
                        eventName.Text = myDetails.name;
                    }
                    else
                    {
                        eventName.Text = "Cannt find event name";
                    }

                    if (myDetails.eventInfo != null)
                    {
                        eventInfo.Text = myDetails.eventInfo;
                    }
                    else
                    {
                        eventInfo.Text = "No info has been given for the event!";
                    }
                    if (myDetails.info != null)
                    {
                        eventNote.Text = myDetails.info;
                    }
                    else
                    {
                        eventNote.Text = "No info has been given for the event!";
                    }

                    if (myDetails.venueName != null)
                    {
                        venueName.Text = myDetails.venueName;
                    }
                    else
                    {

                        venueName.Text = "No venue has been given for this event at this current time!";
                    }
                    if (myDetails.url != null)
                    {
                        urlInfo.Text = "To buy tickets, click the following link.";
                        url.Content = "www.ticketmaster.com/event/" + myDetails.id;
                        url.NavigateUri = new Uri(myDetails.url);
                    }
                    if (myDetails.date != null)
                    {
                        eventDate.Text = string.Format("{0:f}", myDetails.date);
                    }
                    else
                    {
                        eventDate.Text = "Cannot display date.";
                    }

                    if (myDetails.longitude == null || myDetails.latitude == null || myDetails.venueName == null)
                    {
                        
                    } else
                    {
                        AddSpaceNeedleIcon(myDetails.longitude, myDetails.latitude, myDetails.venueName);
                    }

                }

            }
            catch
            {
                DisplayNoWifiDialog();
            }



        }
    }
}
