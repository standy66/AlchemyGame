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
using System.Windows.Shapes;

namespace alchemy
{
	/// <summary>
	/// Логика взаимодействия для Menu.xaml
	/// </summary>
	public partial class Menu : Window
	{
		MainWindow mainWindowInstance;
		About aboutWindowInstance;

		public Menu()
		{
			InitializeComponent();
			play.AddHandler(MouseLeftButtonDownEvent, new MouseButtonEventHandler(play_MouseLeftButtonDown), true);
			leaderbords.AddHandler(MouseLeftButtonDownEvent, new MouseButtonEventHandler(leaderbords_MouseLeftButtonDown), true);
			exit.AddHandler(MouseLeftButtonDownEvent, new MouseButtonEventHandler(exit_MouseLeftButtonDown), true);
			settings.AddHandler(MouseLeftButtonDownEvent, new MouseButtonEventHandler(settings_MouseLeftButtonDown), true);
			DataStorage.instance = new DataStorage("data.bin");
		}

		private void exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Close();
		}

		private void leaderbords_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			aboutWindowInstance = new About();
			aboutWindowInstance.ShowDialog();
		}

		private void settings_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			DataStorage.instance.LoadDefaults();
			DataStorage.instance.SaveData("data.bin");
			MessageBox.Show("Все настройки сброшены");
		}

		private void play_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			mainWindowInstance = new MainWindow();
			mainWindowInstance.ShowDialog();
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			DataStorage.instance.SaveData("data.bin");
			e.Cancel = false;
		}


	}
}
