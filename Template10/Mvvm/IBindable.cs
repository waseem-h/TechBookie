using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Template10.Mvvm
{
	public interface IBindable : INotifyPropertyChanged
	{
		void RaisePropertyChanged([CallerMemberName]string propertyName = null);
	}
}
