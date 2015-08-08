using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace XamarinSignalRExample
{

	public class ChatListViewStackLayout : StackLayout
	{
		private ObservableCollection<MessageText> TextContainer = new ObservableCollection<MessageText>();
		public ListView ListView = new ListView();

		public ChatListViewStackLayout()
		{
			ListView = new ListView {
				ItemsSource = TextContainer,
				VerticalOptions = LayoutOptions.FillAndExpand,
				ItemTemplate = new DataTemplate (typeof(ChatListViewCell)),
				SeparatorVisibility = SeparatorVisibility.None,
				HasUnevenRows = true
			};
			Children.Add(ListView);
		}

		public void AddText(string text)
		{
			TextContainer.Add(new MessageText {Text = text});
		}
	}
	
}
