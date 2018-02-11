using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template10.Common
{
	public class ItemPropertyChangedEventArgs
	{
		public ItemPropertyChangedEventArgs(object item, int changedIndex, PropertyChangedEventArgs e)
		{
			ChangedItem = item;
			ChangedItemIndex = changedIndex;
			PropertyChangedArgs = e;
		}
		public object ChangedItem { get; set; }

		public int ChangedItemIndex { get; set; }

		public PropertyChangedEventArgs PropertyChangedArgs { get; set; }
	}
}
