using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TicketTracker
{
    /// <summary>
    /// MainPage that display all of the events in a gridview
    /// </summary>
    public sealed partial class MainPage : Windows.UI.Xaml.Controls.Page, INotifyPropertyChanged
    {
        // Observable Collection of tuples with countryCode mapped to the country name that is bound to a ComboBox
        private ObservableCollection<Tuple<string, string>> Countries = new ObservableCollection<Tuple<string, string>>();
        // Observable Collection of event classifcations i.e Music, Sports, Film etc
        private ObservableCollection<string> Classifications = new ObservableCollection<string>();

        public MainPage()
        {
            this.InitializeComponent();
            /* Adding all of the country codes that are supported
               at one point I tried using all of the country codes that were listed on the API.
               but ending up removing them as they were not working.*/
            Countries.Add(new Tuple<string, string>("US", "United States"));
            Countries.Add(new Tuple<string, string>("IE", "Ireland"));
            Countries.Add(new Tuple<string, string>("CA", "Canada"));
            Countries.Add(new Tuple<string, string>("AU", "Australia"));
            Countries.Add(new Tuple<string, string>("AT", "Austria"));
            Countries.Add(new Tuple<string, string>("BE", "Belgium"));
            Countries.Add(new Tuple<string, string>("DK", "Denmark"));
            Countries.Add(new Tuple<string, string>("FR", "France"));
            Countries.Add(new Tuple<string, string>("GB", "Great Britain"));
            Countries.Add(new Tuple<string, string>("LU", "Luxembourg"));
            Countries.Add(new Tuple<string, string>("MX", "Mexico"));
            Countries.Add(new Tuple<string, string>("NL", "Netherlands"));
            Countries.Add(new Tuple<string, string>("NZ", "New Zealand"));
            Countries.Add(new Tuple<string, string>("NO", "Norway"));
            Countries.Add(new Tuple<string, string>("PL", "Poland"));
            Countries.Add(new Tuple<string, string>("PT", "Portugal"));
            Countries.Add(new Tuple<string, string>("ES", "Spain"));
            Countries.Add(new Tuple<string, string>("SE", "Sweden"));
            Countries.Add(new Tuple<string, string>("CH", "Switzerland"));

            // Adding event classifcations to observable collection
            Classifications.Add("Sports");
            Classifications.Add("Music");
            Classifications.Add("Arts & Theatre");
            Classifications.Add("Film");
        }

        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                ((INotifyPropertyChanged)Events).PropertyChanged += value;
            }

            remove
            {
                ((INotifyPropertyChanged)Events).PropertyChanged -= value;
            }
        }

        // Observable Collection of Events that are bound to a GridView
        private ObservableCollection<Event> Events = new ObservableCollection<Event>();

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Loop through each element that is return from the GetEventsByCountryId method
                // and append them to the observable collection
                foreach (var eventThing in await TicketMasterData.GetEventsByCountryId("IE"))
                {
                    Events.Add(eventThing);
                }
            }
            catch
            {
                // If there is an exception display dialog box to warn user
                ExceptionDialogBox();
                // Add 100 empty events to the grid
                for (int i = 0; i < 100; i++)
                {
                    // eventId is set to 0
                    Events.Add(new Event { name = "Event Name", venueName = "Venue Name", image = null, id = "0" });
                }
            }

        }

        // Navigate to event details page
        private void Goto_Event_Details_Page(object sender, ItemClickEventArgs e)
        {
            // eventId need to query API for event details
            var myEvent = e.ClickedItem as Event;
            // If it is 0 then display dialog box
            if (myEvent.id.Equals("0"))
            {
                ExceptionDialogBox();
            }
            else
            {
                // If there is no exception navigate user to EventDetailPage and pass
                // in event id
                Frame.Navigate(typeof(EventDetailPage), myEvent.id);
            }
        }

        // Dialog box to be display when exception occurs
        private async void ExceptionDialogBox()
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = "Cannot connect to API",
                Content = "Check your connection and try again.",
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await noWifiDialog.ShowAsync();
        }

        // When user clicks on Item in ComboBox
        private async void CountryBox_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // get countryCode of TextBlock
            var countryCode = ((TextBlock)sender).Tag;

            // Remove all previous events from the page
            Events.Clear();

            try
            {
                // Loop through each element that is return from the GetEventsByCountryId method
                // and append them to the observable collection
                foreach (var eventThing in await TicketMasterData.GetEventsByCountryId((string)countryCode))
                {
                    Events.Add(eventThing);
                }
            }
            catch
            {
                // If there is an exception display dialog box to warn user
                ExceptionDialogBox();
                for (int i = 0; i < 100; i++)
                {
                    Events.Add(new Event { name = "Event Name", venueName = "Venue Name", image = null, id = "0" });
                }
            }

        }

        // When user clicks on event type
        private async void ClassificationBox_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // get event type 
            var classificationName = ((TextBlock)sender).Text;

            // remove events from collection
            Events.Clear();

            try
            {
                // Loop through each element that is return from the GetEventsByCountryId method
                // and append them to the observable collection
                foreach (var eventThing in await TicketMasterData.GetEventsByClassifcation(classificationName))
                {
                    Events.Add(eventThing);
                }
            }
            catch
            {
                // If there is an exception alert user
                ExceptionDialogBox();
                for (int i = 0; i < 100; i++)
                {
                    Events.Add(new Event { name = "Event Name", venueName = "Venue Name", image = null, id = "0" });
                }
            }

        }
    }
}
