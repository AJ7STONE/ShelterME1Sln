using Microsoft.Maui.Controls;

namespace ShelterME1.Views
{
    public partial class UserOptionsPage : ContentPage
    {
        public UserOptionsPage()
        {
            InitializeComponent();
        }

        private async void OnVolunteerButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VolunteersPage());
        }

        private async void OnDonorsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DonorsPage());
        }


       



    }
}

