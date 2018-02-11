using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Template10.Utils
{
	public static class ResourceUtils
	{
		public static T GetResource<T>(string resourceName, T otherwise)
		{
			try
			{
				return (T)Application.Current.Resources[resourceName];
			}
			catch
			{
				return otherwise;
			}
		}
	}
}
