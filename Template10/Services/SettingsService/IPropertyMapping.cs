using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template10.Services.SettingsService
{
	public interface IPropertyMapping
	{
		IStoreConverter GetConverter(Type type);
	}
}
