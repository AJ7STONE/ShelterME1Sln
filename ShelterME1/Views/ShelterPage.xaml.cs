using Microsoft.Maui.Controls;

namespace ShelterME1.Views
{
    public partial class ShelterPage : ContentPage
    {
        public ShelterPage()
        {
            InitializeComponent();
        }

        async void OnVisitWebsiteClicked(object sender, EventArgs e)
        {
            // Specify the URI of the website you want to redirect to
            string websiteUri = "https://www.haven.org.za/";

            // Open the URI in the default browser
            await Launcher.OpenAsync(websiteUri);
        }
    }
}
