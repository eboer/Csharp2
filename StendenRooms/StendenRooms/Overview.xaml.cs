using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace StendenRooms
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Overview : Page
    {
        public Overview()
        {
            this.InitializeComponent();

            createColomns(reserves, 3);
            createRows(reserves, 15);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RoomInfo));
        }

        private void createColomns(Grid grid, int colomns) {
            for (int i = 0; i < colomns; i++) {
                grid.ColumnDefinitions.Add(new ColumnDefinition());

                TextBlock label = new TextBlock();
                label.FontSize = 20;
                label.TextAlignment = TextAlignment.Center;

                if (i == 0) label.Text = "Room";
                if (i == 1) label.Text = "Time";
                if (i == 2) label.Text = "Extra";

                Grid.SetColumn(label, i);
                grid.Children.Add(label);

            }
        }

        private void createRows(Grid grid, int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());

                TextBlock label = new TextBlock();
                label.FontSize = 20;
                label.TextAlignment = TextAlignment.Center;
                label.TextWrapping = TextWrapping.Wrap;

                if(i > 0)
                label.Text = i.ToString();

                Grid.SetRow(label, i);
                grid.Children.Add(label);

            }
        }
        
    }
}
