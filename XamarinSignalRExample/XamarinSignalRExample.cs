using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace XamarinSignalRExample
{
	public class App : Application
	{
		public SignalRClient SignalRClient = new SignalRClient("http://localhost:9995");

		public App()
		{
			//show an error if the connection doesn't succeed for some reason
			SignalRClient.Start ().ContinueWith(task => {
				if (task.IsFaulted) 
					MainPage.DisplayAlert("Error", "An error occurred when trying to connect to SignalR: " + task.Exception.InnerExceptions[0].Message, "OK");
			});


			//try to reconnect every 10 seconds, just in case
			Device.StartTimer (TimeSpan.FromSeconds (10), () => {
				if (!SignalRClient.IsConnectedOrConnecting)
					SignalRClient.Start();

				return true;
			});

			var usernameStack = new UsernameStackLayout();
			var sendMessage = new SendMessageStackLayout();
			var listView = new ChatListViewStackLayout ();
			var connectionLabel = new Label {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				BindingContext = SignalRClient
			};
			connectionLabel.SetBinding (Label.TextProperty, "ConnectionState");

			// The root page of your application
			MainPage = new ContentPage
			{
				Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5),
				Content = new StackLayout
				{
					Children = {
						new Label {
							FontSize = 12.0,
							HorizontalOptions = LayoutOptions.CenterAndExpand,
							Text = "SignalR + Xamarin!"
						},
						usernameStack,
						sendMessage,
						listView,
						connectionLabel
					}
				}
			};

			sendMessage.MessageSent += (message) => {
				listView.AddText("Me: " + message);
				SignalRClient.SendMessage(usernameStack.UsernameTextbox.Text, message);
			};

			SignalRClient.OnMessageReceived += (username, message) =>{
				listView.AddText(username + ": " + message);
			};
		}
	}
}

