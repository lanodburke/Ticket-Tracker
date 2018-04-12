using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Windows.UI.Xaml.Controls.Page, INotifyPropertyChanged
    {
        private ObservableCollection<Tuple<string, string>> Countries = new ObservableCollection<Tuple<string, string>>();
        private ObservableCollection<string> Classifications = new ObservableCollection<string>();

        public MainPage()
        {
            this.InitializeComponent();
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

        private ObservableCollection<Event> Events = new ObservableCollection<Event>();

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var eventThing in await TicketMasterData.GetEventsByCountryId("IE"))
                {
                    Events.Add(eventThing);
                }
            }
            catch
            {
                DisplayNoWifiDialog();
                for (int i = 0; i < 100; i++)
                {
                    Events.Add(new Event { name = "Event Name", venueName = "Venue Name", image = null, id = "0" });
                }
            }

        }

        private void Goto_Event_Details_Page(object sender, ItemClickEventArgs e)
        {
            var myEvent = e.ClickedItem as Event;
            if (myEvent.id.Equals("0"))
            {
                DisplayNoWifiDialog();
            }
            else
            {
                Frame.Navigate(typeof(EventDetailPage), myEvent.id);
            }
        }

        private async void DisplayNoWifiDialog()
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = "Cannot connect to database",
                Content = "Check your connection and try again.",
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await noWifiDialog.ShowAsync();
        }

        private async void CountryBox_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var countryCode = ((TextBlock)sender).Tag;

            Events.Clear();

            try
            {
                foreach (var eventThing in await TicketMasterData.GetEventsByCountryId((string)countryCode))
                {
                    Events.Add(eventThing);
                }
            }
            catch
            {
                DisplayNoWifiDialog();
                for (int i = 0; i < 100; i++)
                {
                    Events.Add(new Event { name = "Event Name", venueName = "Venue Name", image = null, id = "0" });
                }
            }

        }

        private async void ClassificationBox_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var classificationName = ((TextBlock)sender).Text;
            Debug.WriteLine(classificationName);

            Events.Clear();

            try
            {
                foreach (var eventThing in await TicketMasterData.GetEventsByClassifcation(classificationName))
                {
                    Events.Add(eventThing);
                }
            }
            catch
            {
                DisplayNoWifiDialog();
                for (int i = 0; i < 100; i++)
                {
                    Events.Add(new Event { name = "Event Name", venueName = "Venue Name", image = null, id = "0" });
                }
            }

        }
    }
}
