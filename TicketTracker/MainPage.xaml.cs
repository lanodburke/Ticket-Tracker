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
        private ObservableCollection<Tuple<string,string>> Countries = new ObservableCollection<Tuple<string, string>>();
        private ObservableCollection<string> Classifications = new ObservableCollection<string>();

        public MainPage()
        {
            this.InitializeComponent();
            Countries.Add(new Tuple<string, string>("US", "United States"));
            Countries.Add(new Tuple<string, string>("IE", "Ireland"));
            Countries.Add(new Tuple<string, string>("CA", "Canada"));
            Countries.Add(new Tuple<string, string>("AD", "Andorra"));
            Countries.Add(new Tuple<string, string>("AI", "Anguilla"));
            Countries.Add(new Tuple<string, string>("AR", "Argentina"));
            Countries.Add(new Tuple<string, string>("AU", "Australia"));
            Countries.Add(new Tuple<string, string>("AT", "Austria"));
            Countries.Add(new Tuple<string, string>("AZ", "Azerbaijan"));
            Countries.Add(new Tuple<string, string>("AZ", "Azerbaijan"));
            Countries.Add(new Tuple<string, string>("BS", "Bahamas"));
            Countries.Add(new Tuple<string, string>("BH", "Bahrain"));
            Countries.Add(new Tuple<string, string>("BB", "Barbados"));
            Countries.Add(new Tuple<string, string>("BE", "Belgium"));
            Countries.Add(new Tuple<string, string>("BE", "Belgium"));



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
            foreach (var eventThing in await TicketMasterData.GetEventsByCountryId("IE"))
            {
                Events.Add(eventThing);
            }
        }

        private void Goto_Event_Details_Page(object sender, ItemClickEventArgs e)
        {
            var myEvent = e.ClickedItem as Event;
            Frame.Navigate(typeof(EventDetailPage), myEvent.id);            
        }

        private async void CountryBox_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var countryCode = ((TextBlock)sender).Tag;

            Events.Clear();
            foreach (var eventThing in await TicketMasterData.GetEventsByCountryId((string)countryCode))
            {
                Events.Add(eventThing);
            }
        }

        private async void ClassificationBox_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var classificationName = ((TextBlock)sender).Text;
            Debug.WriteLine(classificationName);

            Events.Clear();
            foreach (var eventThing in await TicketMasterData.GetEventsByClassifcation(classificationName))
            {
                Events.Add(eventThing);
            }
        }
    }
}
