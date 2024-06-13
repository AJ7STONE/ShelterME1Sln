using Microsoft.Maui.Controls;

namespace ShelterME1.Views
{
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            // Simulate a backend request for user login
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                // Assuming login is successful
                await DisplayAlert("Success", "Login successful!", "OK");
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                MessageLabel.Text = "Please fill out all fields";
            }
        }

        private async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SigninPage());
        }
    }
}
