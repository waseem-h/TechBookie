﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template10.Common
{
	public interface IStateItems
	{
		KeyValuePair<StateItemKey, object> Add(Type type, string key, object value);
		bool Contains(object value);
		bool Contains(StateItemKey key);
		bool Contains(Type type, string key);
		bool Contains(Type type, string key, object value);
		T Get<T>(StateItemKey key);
		T Get<T>(string key);
		void Remove(Type type);
		void Remove(object value);
		void Remove(Type type, string key);
		bool TryGet<T>(string key, out T value);
	}
}
