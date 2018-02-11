using Microsoft.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Utils;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Template10.Behaviors
{
	[TypeConstraint(typeof(CommandBar))]
	public class EllipsisBehavior : DependencyObject, IBehavior
	{
		private CommandBar commandBar => AssociatedObject as CommandBar;
		public DependencyObject AssociatedObject { get; private set; }

		public void Attach(DependencyObject associatedObject)
		{
			AssociatedObject = associatedObject;
			commandBar.Loaded += (s, e) => Update();
			commandBar.PrimaryCommands.VectorChanged += Commands_VectorChanged;
			commandBar.SecondaryCommands.VectorChanged += Commands_VectorChanged;
			Update();
		}

		public void Detach()
		{
			commandBar.Loaded -= (s, e) => Update();
			commandBar.PrimaryCommands.VectorChanged -= Commands_VectorChanged;
			commandBar.SecondaryCommands.VectorChanged -= Commands_VectorChanged;
		}

		private void Commands_VectorChanged(Windows.Foundation.Collections.IObservableVector<ICommandBarElement> sender,
			Windows.Foundation.Collections.IVectorChangedEventArgs @event)
		{ Update(); }

		public enum Visibilities { Visible, Collapsed, Auto }
		public Visibilities Visibility
		{
			get { return (Visibilities)GetValue(VisibilityProperty); }
			set { SetValue(VisibilityProperty, value); }
		}
		public static readonly DependencyProperty VisibilityProperty =
			DependencyProperty.Register(nameof(Visibility), typeof(Visibilities),
				typeof(EllipsisBehavior), new PropertyMetadata(Visibilities.Auto));

		private void Update()
		{
			var controls = XamlUtils.AllChildren<Control>(commandBar);
			var button = controls.OfType<Button>().FirstOrDefault(x => x.Name.Equals("MoreButton"));
			if (button == null)
				return;
			switch (Visibility)
			{
				case Visibilities.Visible:
					button.Visibility = Windows.UI.Xaml.Visibility.Visible;
					break;
				case Visibilities.Collapsed:
					button.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
					break;
				case Visibilities.Auto:
					var count = commandBar.PrimaryCommands.OfType<Control>().Count(x => x.Visibility.Equals(Windows.UI.Xaml.Visibility.Visible));
					count += commandBar.SecondaryCommands.OfType<Control>().Count(x => x.Visibility.Equals(Windows.UI.Xaml.Visibility.Visible));
					button.Visibility = (count > 0) ? Windows.UI.Xaml.Visibility.Visible : Windows.UI.Xaml.Visibility.Collapsed;
					break;
			}

		}
	}
}
