using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace alchemy
{
	public static class Extensions
	{
		public static bool PointInRect(this Rect r, Point p)
		{
			if (p.X >= r.Left && p.X <= r.Right && p.Y >= r.Top && p.Y <= r.Bottom)
				return true;
			else
				return false;
		}

		public static T FindAnchestor<T>(DependencyObject current) where T : UIElement
		{
			do
			{
				if (current is T)
				{
					return (T)current;
				}
				current = VisualTreeHelper.GetParent(current);
			}
			while (current != null);
			return null;
		}


		public static bool Close(Thickness t1, Thickness t2)
		{
			Point c1 = new Point((t1.Left + t1.Right) / 2, (t1.Top + t1.Bottom) / 2);
			Point c2 = new Point((t2.Left + t2.Right) / 2, (t2.Top + t2.Bottom) / 2);

			Vector v = c1 - c2;
			if (v.Length < 50)
				return true;
			else
				return false;

		}
	}
}
