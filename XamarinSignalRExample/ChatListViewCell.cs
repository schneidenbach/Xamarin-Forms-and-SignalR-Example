using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace XamarinSignalRExample
{

	public class ChatListViewCell : ViewCell {
		public ChatListViewCell() {
			var label = new Label();

			label.SetBinding (Label.TextProperty, "Text");
			View = new StackLayout {
				Padding = new Thickness(5),
				Children = {
					label
				}
			};
		}
	}
	
}
