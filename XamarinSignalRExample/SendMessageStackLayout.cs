using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace XamarinSignalRExample
{

	public class SendMessageStackLayout : StackLayout
	{
		private Entry Entry;
		private Button EnterButton;
		public event OnMessageSent MessageSent;
		public delegate void OnMessageSent(string message);

		public SendMessageStackLayout()
		{
			Orientation = StackOrientation.Horizontal;

			EnterButton = new Button {
				Text = "Send",
				HorizontalOptions = LayoutOptions.EndAndExpand
			};
			EnterButton.Clicked += EnterButton_Clicked;

			Entry = new Entry {
				Placeholder = "Enter a message",
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			Children.Add (new Label {
				Text="Text:"
			});
			Children.Add(Entry);
			Children.Add(EnterButton);
		}

		private void EnterButton_Clicked(object sender, EventArgs e)
		{
			var messageSent = MessageSent;
			if (messageSent != null)
				messageSent(Entry.Text);

			Entry.Text = string.Empty;
		}
	}
	
}
