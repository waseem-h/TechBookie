using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template10.Services.SettingsService
{
	public interface IStoreConverter
	{
		string ToStore(object value, Type type);
		object FromStore(string value, Type type);
	}
}
