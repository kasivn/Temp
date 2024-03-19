using Microsoft.AspNet.SignalR.Client;
using System.Net;

namespace CSMauiAppTest
{
    public partial class MainPage : ContentPage
    {
        private HubConnection _hubConnection;
        private IHubProxy _hubProxy;

        public MainPage()
        {
            InitializeComponent();
            _hubConnection = new HubConnection("https://signalrserverapp.azurewebsites.net/");
            _hubProxy = _hubConnection.CreateHubProxy("ChatHub");

            // Subscribe to receive messages from the server
            _hubProxy.On<string, string>("broadcastMessage", (name, message) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    // Update UI with received message
                    chatLabel.Text += $"{name}: {message}\n";
                });
            });

            // Start the connection
            _hubConnection.Start().Wait();
        }

        private async void SendButton_Clicked(object sender, EventArgs e)
        {
            // Check if connection is established
            if (_hubConnection.State == ConnectionState.Connected)
            {
                // Send message to server
                await _hubProxy.Invoke("Send", "MAUI Client", messageEntry.Text);
                messageEntry.Text = string.Empty; // Clear the message entry
            }
            else
            {
                // Handle connection not established
                // For example, you may display an error message
                await DisplayAlert("Error", "Connection to server is not established.", "OK");
            }
        }

        private async void SendButton_Clicked1(object sender, EventArgs e)
        {
            // Check if connection is established
            if (_hubConnection.State == ConnectionState.Connected)
            {
                try
                {

                    // Send message to server
                    await _hubProxy.Invoke("Send", "MAUI Client", messageEntry.Text);
                    messageEntry.Text = string.Empty; // Clear the message entry
                }
                catch (Exception ex)
                {
                    throw ex;
                }
               
            }
            else
            {
                // Handle connection not established
                // For example, you may display an error message
                await DisplayAlert("Error", "Connection to server is not established.", "OK");
            }
        }

    }

}
