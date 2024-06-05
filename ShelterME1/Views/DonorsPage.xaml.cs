using Microsoft.Maui.Controls;
using ShelterME1.Models;
using System;

namespace ShelterME1.Views
{
    public partial class DonorsPage : ContentPage
    {
        public DonorsPage()
        {
            InitializeComponent();
            LoadDonors();
        }

        private async void LoadDonors()
        {
            DonorsListView.ItemsSource = await App.Database.GetDonorsAsync();
        }

        private async void OnAddDonorClicked(object sender, EventArgs e)
        {
            var donor = new Donor
            {
                Name = NameEntry.Text,
                ContactDetails = ContactDetailsEntry.Text,
                Email = EmailEntry.Text,
                Details = DetailsEntry.Text
            };

            await App.Database.SaveDonorAsync(donor);
            NameEntry.Text = string.Empty;
            ContactDetailsEntry.Text = string.Empty;
            EmailEntry.Text = string.Empty;
            DetailsEntry.Text = string.Empty;
            LoadDonors(); // Ensure the list is reloaded after adding a new donor
        }
    }
}
