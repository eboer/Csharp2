using System.Net.Http;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace StendenRooms
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">
        ///     Event data that describes how this page was reached.
        ///     This parameter is typically used to configure the page.
        /// </param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Check if data is correct
            string name = tbxName.Text;
            string email = tbxEmail.Text;
            string studentnr = tbxStudentNr.Text;
            string password = tbxPassword.Password;

            var http = new HttpClient();
            HttpResponseMessage response =
                await http.GetAsync("http://stendenrooms.deweurding.nl/register.php?studentnr=" + studentnr +
                                    "&name=" + name + "&email=" + email + "&password=" + password);
            string responseFromDB = await response.Content.ReadAsStringAsync();
            btnRegister.Content = responseFromDB;

            // Making a toast notification
            var toastTemplate = ToastTemplateType.ToastImageAndText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            if (responseFromDB == "Succes")
            {
                toastTextElements[0].AppendChild(toastXml.CreateTextNode("Account succesfully created!"));
            }
            else if (responseFromDB == "1062")
            {
                toastTextElements[0].AppendChild(toastXml.CreateTextNode("Studentnumber already used!"));
            }
            else
            {
                toastTextElements[0].AppendChild(toastXml.CreateTextNode("Unknown error. Errornumber: " + responseFromDB));
            }
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement) toastNode).SetAttribute("duration", "long");
            var toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
            if (responseFromDB == "Succes")
            {
                Frame.Navigate(typeof (MainPage));
            }
        }
    }
}