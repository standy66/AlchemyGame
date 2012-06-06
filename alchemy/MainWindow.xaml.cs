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
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		private int stackIndex;
		const int MOD = 10;

		private void initElements()
		{
			int k = 0;
            
			foreach(string s in DataStorage.instance.Data.Links.Values)
			{
				if (DataStorage.instance.Data[s])
				{
					AlElement el = new AlElement(s);
					double left = (k % MOD) * el.Width;
					double right = left + el.Width;

					double top = (k / MOD) * el.Height;
					double bottom = top + el.Height;

					el.Margin = new Thickness(left, top, right, bottom);
					elements.Children.Add(el);
					k++;
				}
			}
			stackIndex = k;
		}

		public MainWindow()
		{
			InitializeComponent();
			initElements();
			label1.Content = DataStorage.instance.Size.ToString() + " / " + DataStorage.MAXSIZE.ToString();
		}

		private void elements_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			object o = e.OriginalSource;
			AlElement content = Extensions.FindAnchestor<AlElement>((UIElement)o);
			if (content != null)
			{
				DataObject data = new DataObject("AlElement", content);
				DragDrop.DoDragDrop((UIElement)sender, data, DragDropEffects.Copy);
			}
		}

		private void elements_DragEnter(object sender, DragEventArgs e)
		{
			if (!e.Data.GetDataPresent("AlElement") || sender == e.Source)
				e.Effects = DragDropEffects.None;
		}

		private void elements_Drop(object sender, DragEventArgs e)
		{

		}

		private void workspace_Drop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent("AlElement"))
			{
				Point p = e.GetPosition(workspace);
				AlElement el = e.Data.GetData("AlElement") as AlElement;
				AlElement copy = new AlElement(el);
				copy.Margin = new Thickness(p.X - copy.Width / 2, p.Y - copy.Height / 2, p.X + copy.Width / 2, p.Y + copy.Height / 2);
				workspace.Children.Add(copy);
				foreach (UIElement o1 in workspace.Children)
				{
					foreach (UIElement o2 in workspace.Children)
					{
						AlElement u = o1 as AlElement;
						AlElement v = o2 as AlElement;
						if (u == null || v == null)
							continue;
						if (Extensions.Close(u.Margin, v.Margin))
						{
							string newid = DataStorage.instance.Data.Links[u.ElementId, v.ElementId];
							if (newid != null && u != v)
							{
								if (!DataStorage.instance.Data[newid] )
								{
									DataStorage.instance.Data[newid] = true;
									label1.Content = DataStorage.instance.Size.ToString() + " / " + DataStorage.MAXSIZE.ToString();
									AlElement elem = new AlElement(newid);
									double left = (stackIndex % MOD) * el.Width;
									double right = left + el.Width;
									double top = (stackIndex / MOD) * el.Height;
									double bottom = top + el.Height;
									elem.Margin = new Thickness(left, top, right, bottom);
									elements.Children.Add(elem);
									stackIndex++;
								}
								AlElement newel = new AlElement(newid);
								newel.Margin = u.Margin;
								workspace.Children.Remove(u);
								workspace.Children.Remove(v);
								workspace.Children.Add(newel);
								return;
							}
						}
					}
				}
			}
		}

		private void workspace_DragEnter(object sender, DragEventArgs e)
		{
			if (!e.Data.GetDataPresent("AlElement") || sender == e.Source)
				e.Effects = DragDropEffects.None;
		}

		private void workspace_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			object o = e.OriginalSource;
			AlElement content = Extensions.FindAnchestor<AlElement>((UIElement)o);
			if (content != null)
			{
				DataObject data = new DataObject("AlElement", content);
				DragDrop.DoDragDrop((UIElement)sender, data, DragDropEffects.Copy);
				workspace.Children.Remove(content);
			
			}
		}

		private void elements_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
		{

		}

	}
}
