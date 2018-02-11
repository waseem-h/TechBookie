using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template10.Services.SettingsService
{
	public class JsonMapping : IPropertyMapping
	{
		protected IStoreConverter jsonConverter = new JsonConverter();
		public IStoreConverter GetConverter(Type type) => this.jsonConverter;
	}
}
