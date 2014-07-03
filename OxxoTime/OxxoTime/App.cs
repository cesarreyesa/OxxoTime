using System;
using Xamarin.Forms;

namespace OxxoTime
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new ContentPage { 
				Content = new StackLayout{
					Children = {
						new Label {
							Text = "Hello, Forms !",
							VerticalOptions = LayoutOptions.CenterAndExpand,
							HorizontalOptions = LayoutOptions.CenterAndExpand,
						},
						new Button{

						}
					}
				}
			};
		}
	}
}

