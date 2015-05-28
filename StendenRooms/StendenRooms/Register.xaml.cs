using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace StendenRooms
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Register : Page
    {
        public Register()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Check if data is correct
            string name = tbxName.Text;
            string email = tbxEmail.Text;
            string studentnr = tbxStudentNr.Text;
            string password = tbxPassword.Password;

            HttpWebRequest request =
                (HttpWebRequest)
                    WebRequest.Create("https://stendenrooms.deweurding.nl/register.php?studentnr=" + studentnr +
                                      "&name=" + name + "&email=" + email + "&password=" + password);
            Debug.WriteLine(request.GetResponseAsync().ToString());
        }
    }
}
