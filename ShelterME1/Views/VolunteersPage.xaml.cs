using Microsoft.Maui.Controls;
using ShelterME1.Models;
using System;
using System.Linq;

namespace ShelterME1.Views
{
    public partial class VolunteersPage : ContentPage
    {
        public VolunteersPage()
        {
            InitializeComponent();
            LoadVolunteers();
        }

        private async void LoadVolunteers()
        {
            VolunteersListView.ItemsSource = await App.Database.GetVolunteersAsync();
        }

        private async void OnAddVolunteerClicked(object sender, EventArgs e)
        {
            var volunteer = new Volunteer
            {
                Name = NameEntry.Text,
                Details = DetailsEntry.Text,
                ContactDetails = ContactDetailsEntry.Text,
                Email = EmailEntry.Text
            };

            await App.Database.SaveVolunteerAsync(volunteer);
            NameEntry.Text = string.Empty;
            DetailsEntry.Text = string.Empty;
            ContactDetailsEntry.Text = string.Empty;
            EmailEntry.Text = string.Empty;
            LoadVolunteers();
        }
    }
}