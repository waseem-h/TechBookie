using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Common;
using Windows.UI.Xaml.Navigation;

namespace Template10.Services.NavigationService
{
	public interface INavigable
	{
		Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state);
		Task OnNavigatedFromAsync(IDictionary<string, object> state, bool suspending);
		Task OnNavigatingFromAsync(NavigatingEventArgs args);
		INavigationService NavigationService { get; set; }
		IDispatcherWrapper Dispatcher { get; set; }
		IStateItems SessionState { get; set; }
	}
}
