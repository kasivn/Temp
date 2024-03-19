
using Microsoft.AspNet.SignalR.Client;
using Microsoft.Maui.Controls;

namespace CSMauiAppTest;

public partial class SignalR_Page : ContentPage
{
    private HubConnection _hubConnection;
    private IHubProxy _hubProxy;
    public SignalR_Page()
	{
		InitializeComponent();
       
    }


}