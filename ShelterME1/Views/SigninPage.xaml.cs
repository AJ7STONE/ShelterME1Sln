using System;
using Microsoft.Maui.Controls;
using ShelterME1.Models;
using ShelterME1.Services;

namespace ShelterME1.Views
{
    public partial class SigninPage : ContentPage
    {
      //  private readonly UserService _userService;

        public SigninPage()
        {
            InitializeComponent();
        //    _userService = new UserService(); // Assuming UserService handles database operations
        }

        private async void OnSignupButtonClicked(object sender, EventArgs e)
        {
            string fullName = FullNameEntry.Text;
            string emailAddress = EmailAddressEntry.Text;
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;
            DateTime dateOfBirth = DatePicker.Date;
            string gender = GenderPicker.SelectedItem?.ToString();
            string location = LocationEntry.Text;
            string securityQuestion = SecurityQuestionPicker.SelectedItem?.ToString();
            string securityAnswer = SecurityAnswerEntry.Text;
            bool termsAccepted = TermsCheckBox.IsChecked;

            // Perform validation
            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(emailAddress) ||
                string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) ||
                dateOfBirth == default || string.IsNullOrWhiteSpace(gender) ||
                string.IsNullOrWhiteSpace(location) || string.IsNullOrWhiteSpace(securityQuestion) ||
                string.IsNullOrWhiteSpace(securityAnswer) || !termsAccepted)
            {
                await DisplayAlert("Error", "Please fill out all required fields.", "OK");
                return;
            }

            // Create a new User object with the provided information
            var newUser = new User
            {
                FullName = fullName,
                EmailAddress = emailAddress,
                Username = username,
                PasswordHash = password, // Note: For better security, consider hashing the password
                DateOfBirth = dateOfBirth,
                Gender = gender,
                Location = location,
                SecurityQuestion = securityQuestion,
                SecurityAnswer = securityAnswer,
                TermsAccepted = termsAccepted
            };

            // Save the new user to the database

            bool success = await App.Database.RegisterUser(newUser);

            if (success)
            {
                await DisplayAlert("Success", "Registration successful!", "OK");
                // Redirect the user to the confirmation page, login page, or home page
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                await DisplayAlert("Error", "Failed to register user. Please try again.", "OK");
            }
        }
    }
}

