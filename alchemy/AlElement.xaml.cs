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
	/// Логика взаимодействия для AlElement.xaml
	/// </summary>
	public partial class AlElement : UserControl
	{
		private string id;
		private bool terminal;


		public AlElement()
		{
			InitializeComponent();
		}

		public AlElement(AlElement other)
		{
			InitializeComponent();
			ElementId = other.id;
			this.terminal = other.terminal;
		}

		public AlElement(string id)
		{
			InitializeComponent();
			ElementId = id;
		}

		public string ElementId
		{
			set
			{
				id = value;
				//string query = "id" + value.ToString();
				//string text = Properties.Resources.ResourceManager.GetString(query);
				//string imq = "im" + value.ToString();
				string ims = "/Resources/" + value.ToString() + ".png";
				Uri uri = new Uri(ims, UriKind.Relative);
				BitmapImage src = new BitmapImage(uri);
				image.Source = src;
				
				lbl.Content = ElementId;
			}
			get
			{
				return id;
			}
		}
		
	}
}
