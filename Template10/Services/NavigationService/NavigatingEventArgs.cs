using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Template10.Services.NavigationService
{
	public class NavigatingEventArgs : NavigatedEventArgs
	{
		public NavigatingEventArgs() { }
		public NavigatingEventArgs(NavigatingCancelEventArgs e, Page page, object parameter)
		{
			NavigationMode = e.NavigationMode;
			PageType = e.SourcePageType;
			Page = page;
			Parameter = parameter;
		}
		public bool Cancel { get; set; } = false;
		public bool Suspending { get; set; } = false;
	}
}
