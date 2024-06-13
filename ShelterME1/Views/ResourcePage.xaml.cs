using Microsoft.Maui.Controls;
using ShelterME1.Models;
using ShelterME1.Services;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ShelterME1.Views
{
    public partial class ResourcePage : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public ResourcePage()
        {
            InitializeComponent();
            _databaseService = App.Database;
        }

       
        private void OnResourceTypeSelected(object sender, EventArgs e)
        {
            var selectedResourceType = ResourceTypePicker.SelectedItem?.ToString();
            ResourceItemsLayout.Children.Clear();

            if (selectedResourceType == null)
                return;

            string[] items = Array.Empty<string>();

            switch (selectedResourceType)
            {
                case "Food":
                    items = new[] { "Non-perishable items (canned goods, pasta, rice)", "Fresh produce and meats", "Prepared meals" };
                    break;
                case "Clothing":
                    items = new[] { "Seasonal clothing", "Footwear", "Socks and underwear", "Blankets and bedding" };
                    break;
                case "Hygiene Products":
                    items = new[] { "Soap, shampoo, conditioner", "Toothbrushes and toothpaste", "Deodorant", "Feminine hygiene products", "Razors and shaving cream" };
                    break;
                case "Health Supplies":
                    items = new[] { "First aid kits", "Over-the-counter medications", "Masks and hand sanitizers" };
                    break;
                case "Furniture and Bedding":
                    items = new[] { "Beds and mattresses", "Pillows and pillowcases", "Sheets and towels" };
                    break;
                case "Kitchen Supplies":
                    items = new[] { "Pots, pans, and cooking utensils", "Plates, bowls, and cutlery" };
                    break;
                case "Monetary Donations":
                    items = new[] { "Cash donations", "Fundraising events and campaigns", "Grants from individuals or organizations" };
                    break;
                case "Gift Cards and Vouchers":
                    items = new[] { "For groceries, clothing, and transportation" };
                    break;
            }

            foreach (var item in items)
            {
                var stackLayout = new StackLayout { Orientation = StackOrientation.Horizontal };
                var checkBox = new CheckBox();
                var label = new Label { Text = item, VerticalOptions = LayoutOptions.Center };

                stackLayout.Children.Add(checkBox);
                stackLayout.Children.Add(label);

                ResourceItemsLayout.Children.Add(stackLayout);
            }
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            var name = NameEntry.Text;
            var surname = SurnameEntry.Text;
            var contactDetails = ContactDetailsEntry.Text;
            var email = EmailEntry.Text;
            var otherDetails = OtherDetailsEntry.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) ||
                string.IsNullOrWhiteSpace(contactDetails) || string.IsNullOrWhiteSpace(email))
            {
                await DisplayAlert("Error", "Please fill in all user details.", "OK");
                return;
            }

            var selectedResourceType = ResourceTypePicker.SelectedItem?.ToString();

            if (selectedResourceType == null)
            {
                await DisplayAlert("Error", "Please select a resource type.", "OK");
                return;
            }

            var selectedItems = ResourceItemsLayout.Children
               .OfType<StackLayout>()
               .Where(sl => sl.Children.OfType<CheckBox>().FirstOrDefault()?.IsChecked == true)
               .Select(sl => sl.Children.OfType<Label>().FirstOrDefault()?.Text);

            if (!selectedItems.Any())
            {
                await DisplayAlert("Error", "Please select at least one item.", "OK");
                return;
            }

            var user = new User
            {
                FullName = name,
                ContactDetails = contactDetails,
                EmailAddress = email,
                OtherDetails = otherDetails
            };

            // Save user details to the database
            await _databaseService.SaveUserAsync(user);

            // Save each selected item as a resource in the database
            foreach (var item in selectedItems)
            {
                var resource = new ShelterME1.Models.Resource
                {
                    Name = selectedResourceType,
                    Description = item,
                   
                };

                await _databaseService.SaveResourceAsync(resource);
            }

            await DisplayAlert("Submission", "Resources and user details submitted successfully.", "OK");
        }
    }
}
