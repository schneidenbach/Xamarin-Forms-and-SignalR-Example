using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace XamarinSignalRExample
{
	public class App : Application
	{
		public SignalRClient SignalRClient = new SignalRClient("");

		public App()
		{
			var usernameStack = new UsernameStackLayout();
			var sendMessage = new SendMessageStackLayout();
			var listView = new ChatListViewStackLayout ();

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
						listView
					}
				}
			};

			sendMessage.MessageSent += (message) => {
				listView.AddText("Me: " + message);
			};

			SignalRClient.MessageReceived += (username, message) =>{
				listView.AddText(username + ": " + message);
			};
		}
	}
}

