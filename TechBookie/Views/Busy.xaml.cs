using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace TechBookie.Views
{
	public sealed partial class Busy : UserControl
	{
		public Busy()
		{
			this.InitializeComponent();
		}



		public bool IsBusy
		{
			get { return (bool)GetValue(IsBusyProperty); }
			set { SetValue(IsBusyProperty, value);
				if(IsBusy == false)
				{
					BusyText = "";
				}
			}
		}

		// Using a DependencyProperty as the backing store for IsBusy.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IsBusyProperty =
			DependencyProperty.Register("IsBusy", typeof(bool), typeof(Busy), new PropertyMetadata(false));




		public string BusyText
		{
			get { return (string)GetValue(BusyTextProperty); }
			set { SetValue(BusyTextProperty, value); }
		}

		// Using a DependencyProperty as the backing store for BusyText.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty BusyTextProperty =
			DependencyProperty.Register("BusyText", typeof(string), typeof(Busy), new PropertyMetadata("Please Wait..."));


	}
}
