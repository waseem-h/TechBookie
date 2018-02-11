using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template10.Services.SettingsService
{
	public class JsonConverter : IStoreConverter
	{
		public object FromStore(string value, Type type) => JsonConvert.DeserializeObject(value, type);
		public string ToStore(object value, Type type) => JsonConvert.SerializeObject(value, Formatting.None);
	}
}
