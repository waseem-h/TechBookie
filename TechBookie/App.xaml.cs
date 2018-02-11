using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using TechBookie.Services.FileService;
using TechBookie.Services.SettingsService;
using Template10.Common;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Store;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace TechBookie
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : BootStrapper
    {
        
        public App()
        {
            this.InitializeComponent();
			SplashFactory = (e) => new Views.Splash(e);

			var _settings = SettingsService.Instance;
			RequestedTheme = _settings.AppTheme;
			CacheMaxDuration = _settings.CacheMaxDuration;
			ShowShellBackButton = _settings.UseShellBackButton;
			AskForRating();
		}


		public override Task OnInitializeAsync(IActivatedEventArgs args)
		{
			if((Window.Current.Content as Views.Shell) == null)
			{
				var nav = NavigationServiceFactory(BackButton.Attach, ExistingContent.Include);
				Window.Current.Content = new Views.Shell(nav);
			}
			return Task.CompletedTask;
		}

		private async void AskForRating()
		{
			var fileService = new FileService();
			if (!await fileService.FileExistsAsync("AppOpenCount"))
			{
				await fileService.WriteFileAsync("AppOpenCount", "1");
			}
			else
			{
				int count = Convert.ToInt32(await fileService.ReadFileAsync<string>("AppOpenCount")) + 1;
				if (count == 3)
				{
					Globals.AskForRating = true;
				}
				await fileService.WriteFileAsync("AppOpenCount", count.ToString());
			}
		}

		public override Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
		{
			NavigationService.Navigate(typeof(Views.MainPage));
			return Task.CompletedTask;
		}
	}
}
