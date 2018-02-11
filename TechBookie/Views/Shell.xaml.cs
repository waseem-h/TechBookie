using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Template10.Common;
using Template10.Controls;
using Template10.Services.NavigationService;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TechBookie.Views
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Shell : Page
	{
		public static Shell Instance { get; set; }
		public static HamburgerMenu HamburgerMenu { get { return Instance.MyHamburgerMenu; } }
		public Shell()
		{
			Instance = this;
			this.InitializeComponent();
			Loaded += Shell_Loaded;
		}

		private void Shell_Loaded(object sender, RoutedEventArgs e)
		{
			//SettingsButton.IsEnabled = false;
		}

		public Shell(INavigationService navigationService)
		{
			Instance = this;
			InitializeComponent();
			SetNavigationService(navigationService);
		}

		private void SetNavigationService(INavigationService navigationService)
		{
			MyHamburgerMenu.NavigationService = navigationService;
		}

		public static void SetBusy(bool busy, string text = null)
		{
			WindowWrapper.Current().Dispatcher.Dispatch(() =>
			{
				Instance.BusyView.BusyText = text;
				Instance.ModalContainer.IsModal = Instance.BusyView.IsBusy = busy;
			});
		}
	}
}
