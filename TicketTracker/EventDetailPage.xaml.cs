using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private string eventId;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.eventId = (string)e.Parameter;
        }

        private ObservableCollection<RootObject1> Details = new ObservableCollection<RootObject1>();

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var details in await TicketMasterDataEventDetails.GetEventDetails(this.eventId))
            {
                Details.Add(details);
            }
        }
    }
}
