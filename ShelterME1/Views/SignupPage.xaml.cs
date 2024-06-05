using Microsoft.Maui.Controls;

namespace ShelterME1.Views
{
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        private async void OnSignupButtonClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            // Simulate a backend request for user registration
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                // Assuming registration is successful
                await DisplayAlert("Success", "Signup successful!", "OK");
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                MessageLabel.Text = "Please fill out all fields";
            }
        }
    }
}
