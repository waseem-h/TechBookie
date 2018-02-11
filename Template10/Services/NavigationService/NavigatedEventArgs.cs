using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Template10.Services.NavigationService
{
	public class NavigatedEventArgs : EventArgs
	{
		public NavigatedEventArgs() { }
		public NavigatedEventArgs(NavigationEventArgs e, Page page)
		{
			Page = page;
			PageType = e.SourcePageType;
			Parameter = e.Parameter;
			NavigationMode = e.NavigationMode;
		}

		public NavigationMode NavigationMode { get; set; }
		public Type PageType { get; set; }
		public object Parameter { get; set; }
		public Page Page { get; set; }
	}
}
