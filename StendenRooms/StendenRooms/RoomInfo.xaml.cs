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
    public sealed partial class RoomInfo : Page
    {

        String[] times = new String[] {"08:30-09:15", "09:15-10:00", "10:15-11:00", "11:00-11:45", "11:45-12:30", "12:30-13:15", "13:15-14:00", "14:00-14:45", "15:00-15:45", "15:45-16:30", "16:30-17:15", "17:15-18:00", "18:00-18:45", "18:45-19:30"};
        String[] facilities = new String[] {"Capacity", "Sockets", "Beamer", "Whiteboard", "Blackboard", "Activeboard", "TV"};
        String[] extras = new String[] {"Haspel", "Whiteboard Marker", "Whiteboard Wisser", "Beamer"};

        public RoomInfo()
        {
            this.InitializeComponent();

            

            createColomns(gTime, 4);
            createRows(gTime, times.Length + 1);

            createColomns(gFacilities, 4);
            createRows(gFacilities, facilities.Length + 2);

            createColomns(gExtra, 2);
            createRows(gExtra, extras.Length + 1);


        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void createColomns(Grid grid, int colomns)
        {
            for (int i = 0; i < colomns; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());

                TextBlock label = new TextBlock();
                label.FontSize = 20;
                if(i>0)
                label.TextAlignment = TextAlignment.Center;

                label.TextWrapping = TextWrapping.Wrap;

                if (grid == gTime){
                    if (i == 0) label.Text = "Time";
                    if (i == 1) label.Text = "First";
                    if (i == 2) label.Text = "Second";
                    if (i == 3) label.Text = "Third";
                }
                else if (grid == gFacilities) {
                    if (i == 0) label.Text = "Facilities";
                    if (i == 1) label.Text = "First";
                    if (i == 2) label.Text = "Second";
                    if (i == 3) label.Text = "Third";
                }
                else if (grid == gExtra) {
                    if (i == 0) label.Text = "Extra";
                    if (i == 1) label.Text = "Aantal";
                }

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
                label.FontSize = 18;
                label.Height = 30;
                label.TextAlignment = TextAlignment.Left;
                label.TextWrapping = TextWrapping.Wrap;

                if (grid == gTime && i > 0 ) { 
                    label.Text = times[i-1];
                }
                else if (grid == gFacilities && i > 0 && i < (facilities.Length +1)) { 
                    label.Text = facilities[i -1];
                }
                else if (grid == gExtra && i > 0)
                {
                    label.Text = extras[i - 1];
                }

                Grid.SetRow(label, i);
                grid.Children.Add(label);

            }
        }
    }
}
