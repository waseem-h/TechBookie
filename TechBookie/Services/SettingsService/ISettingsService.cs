using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace TechBookie.Services.SettingsService
{
	public interface ISettingsService
	{
		bool UseShellBackButton { get; set; }
		ApplicationTheme AppTheme { get; set; }
		TimeSpan CacheMaxDuration { get; set; }
	}
}
