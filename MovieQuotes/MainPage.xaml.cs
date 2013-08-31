using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MovieQuotes.Resources;

namespace MovieQuotes
{
    public partial class MainPage : PhoneApplicationPage
    {
        //Private variables to hold movie quotes
        private List<MovieQuote> _movieQuotes;
        private QuotesReader _reader;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPageLoaded;
        }
        //When page is loaded, read quotes using reader
        //And bind it to main page
        private void MainPageLoaded(object sender, RoutedEventArgs e)
        {
            _reader = new QuotesReader();
            _movieQuotes = _reader.GetMovieQuotes();
            this.DataContext = _movieQuotes.FirstOrDefault();
        }
        //Handle previous quote button click
        private void BackClicked(object sender, EventArgs e)
        {
           this.DataContext = _reader.GetMovieQuotes().GetSingleRandom();
        }
        //Handle next quote button click
        private void NextClicked(object sender, EventArgs e)
        {
            this.DataContext = _reader.GetMovieQuotes().GetSingleRandom();
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}