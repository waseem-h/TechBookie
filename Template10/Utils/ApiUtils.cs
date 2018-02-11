using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;

namespace Template10.Utils
{
	public static class ApiUtils
	{
		static bool? isHardwareButtonsApiPresent;
		public static bool IsHardwareButtonsApiPresent => isHardwareButtonsApiPresent ?? (isHardwareButtonsApiPresent = ApiInformation.IsTypePresent(@"Windows.Phone.UI.Input.HardwareButtons")).Value;
	}
}
