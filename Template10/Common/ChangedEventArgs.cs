using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template10.Common
{
	public class ChangedEventArgs<TValue> : EventArgs
	{
		private readonly TValue oldValue;
		private readonly TValue newValue;

		public ChangedEventArgs(TValue oldValue, TValue newValue)
		{
			this.oldValue = oldValue;
			this.newValue = newValue;
		}

		public TValue OldValue => oldValue;
		public TValue NewValue => newValue;
	}
}
