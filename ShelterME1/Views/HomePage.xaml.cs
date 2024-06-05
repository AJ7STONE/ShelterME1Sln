using Microsoft.Maui.Controls;

namespace ShelterME1.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void OnShelterButtonClicked(object sender, EventArgs e)
        {
            // Navigate to ShelterPage
            await Navigation.PushAsync(new ShelterPage());
        }

        private async void OnUsersButtonClicked(object sender, EventArgs e)
        {
            // Navigate to UserOptionsPage
            await Navigation.PushAsync(new UserOptionsPage());
        }

        private async void OnResourcesButtonClicked(object sender, EventArgs e)
        {
            // Navigate to ResourcesPage
            await Navigation.PushAsync(new ResourcePage());
        }
    }
}
