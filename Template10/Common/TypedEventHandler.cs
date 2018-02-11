using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template10.Common
{
	public delegate void TypedEventHandler<T>(object sender, T e);

	public class EventArgs<T> : EventArgs
	{
		public EventArgs(T value)
		{
			Value = value;
		}

		public T Value { get; private set; }
	}

	public class CancelEventArgs<T> : CancelEventArgs
	{
		public CancelEventArgs(T value)
		{
			Value = value;
		}

		public T Value { get; private set; }
	}
}
