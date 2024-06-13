using Microsoft.Maui.Controls;
using System;

namespace ShelterME1.Views
{
    public partial class ChatPage : ContentPage
    {
        private ChatBotService _chatBotService;

        public ChatPage()
        {
            InitializeComponent();
            _chatBotService = new ChatBotService();
        }

        private async void OnSendButtonClicked(object sender, EventArgs e)
        {
            string userMessage = UserMessageEntry.Text;
            if (!string.IsNullOrEmpty(userMessage))
            {
                DisplayMessage("You", userMessage);
                UserMessageEntry.Text = string.Empty;

                string botResponse = await _chatBotService.SendMessageAsync(userMessage);
                DisplayMessage("Bot", botResponse);
            }
        }

        private void DisplayMessage(string sender, string message)
        {
            MessagesStack.Children.Add(new Label { Text = $"{sender}: {message}", Margin = new Thickness(0, 5) });
            ChatScrollView.ScrollToAsync(0, ChatScrollView.ContentSize.Height, true);
        }
    }
}
