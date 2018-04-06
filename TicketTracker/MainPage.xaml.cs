﻿using System;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TicketTracker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Windows.UI.Xaml.Controls.Page
    {

        public MainPage()
        {
            this.InitializeComponent();
        }

        private ObservableCollection<Event> Events = new ObservableCollection<Event>();

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var movie in await TicketMasterData.GetEvents("IE"))
            {
                Events.Add(movie);
            }
        }

        private void Rectangle_PointerPressed(object sender, PointerRoutedEventArgs e)
        {

        }
    }
}
