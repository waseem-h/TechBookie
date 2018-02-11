using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template10.Services.SerializationService
{
	public interface ISerializationService
	{
		/// <summary>
		/// Serializes the parameter.
		/// </summary>
		string Serialize(object parameter);

		/// <summary>
		/// Deserializes the parameter.
		/// </summary>
		object Deserialize(string parameter);

		/// <summary>
		/// Deserializes the parameter.
		/// </summary>
		T Deserialize<T>(string parameter);
	}
}
