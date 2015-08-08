using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace XamarinSignalRExample
{

	public class UsernameStackLayout : StackLayout
	{
		public UsernameStackLayout()
		{
			Orientation = StackOrientation.Horizontal;
			Children.Add(new Label {Text="Username:"});
			UsernameTextbox = new Entry {
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			Children.Add(UsernameTextbox);
		}

		public Entry UsernameTextbox { get; private set; }
	}

}
