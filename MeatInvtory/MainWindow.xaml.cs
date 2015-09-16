using InventoryCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MeatInvtory {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		private Inventory Inv;
		public MainWindow() {
			String[] names = { "meat1", "meat2", "meat3", "meat4", "meat5", "meat6", "meat7", "meat8", "meat9" };
			Random r = new Random(0);
			Inv = new Inventory();
			foreach (string str in names) {
				Inv.Add(new Product(str, r.Next(50)));
			}

			List<Product> p = new List<Product>();
			for (int i = 0; i < Inv.Count; i++)
				p.Add(Inv.GetProduct(i));

			InitializeComponent();
			MainList.ItemsSource = Inv.GetProducts();
			Inv.Add(new Product("Yummmeat", 12));
			UpdateList();
		}
		/// <summary>
		/// this will update the List
		/// </summary>

		private void UpdateList() {
			MainList.ItemsSource = Inv.GetProducts();
		}


		private void button_Add_Click(object sender, RoutedEventArgs e) {
			if (NameTB.Text.Any() && AmountTB.Text.Any() && InfoTB.Text.Any()) {
				Product p =  new Product(NameTB.Text, int.Parse(AmountTB.Text));
				p.ProductInfo = InfoTB.Text;
				Inv.Add(p);
			}
			else if (NameTB.Text.Any() && AmountTB.Text.Any()) {
				Inv.Add(new Product(NameTB.Text, int.Parse(AmountTB.Text)));
			}
			else if (NameTB.Text.Any()) {
				Inv.Add(new Product(NameTB.Text));
			}
			else {

			}
			button_Clear_Click(null, null);
			UpdateList();
		}



		private void button_Rem_Click(object sender, RoutedEventArgs e) {
			Console.WriteLine("debug: " + MainList.SelectedIndex);
			Inv.Remove(MainList.SelectedIndex);
			UpdateList();
		}

		private void button_Update_Click(object sender, RoutedEventArgs e) {
			if (NameTB.Text.Any() && AmountTB.Text.Any()) {
				Inv.GetProduct(MainList.SelectedIndex).Name = NameTB.Text;
				Inv.GetProduct(MainList.SelectedIndex).AddAmount(int.Parse(AmountTB.Text) - Inv.GetProduct(MainList.SelectedIndex).Amount);
				Inv.GetProduct(MainList.SelectedIndex).ProductInfo = InfoTB.Text.Any() ? InfoTB.Text : "n/a";
			}
			else {
				//??
			}
			UpdateList();
		}

		/// <summary>
		/// clear all the filds
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_Clear_Click(object sender, RoutedEventArgs e) {
			NameTB.Text = "";
			AmountTB.Text = "";
			InfoTB.Text = "";
		}
		/// <summary>
		/// Adds 1 to selected amount
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_AAm_Click(object sender, RoutedEventArgs e) {
			Inv.GetProduct(MainList.SelectedIndex).AddAmount(1);
			UpdateList();
		}
		/// <summary>
		/// subs 1 to selected amount
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_SAm_Click(object sender, RoutedEventArgs e) {
			Inv.GetProduct(MainList.SelectedIndex).SubAmount(1);
			UpdateList();
		}

		private void button_Clear_MouseDoubleClick(object sender, MouseButtonEventArgs e) {

		}

		private void MainList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
			if (MainList.SelectedIndex > -1) {
				Console.WriteLine("DEBUG: " + MainList.SelectedIndex);
				NameTB.Text = Inv.GetProduct(MainList.SelectedIndex).Name;
				AmountTB.Text = Inv.GetProduct(MainList.SelectedIndex).Amount.ToString();
				InfoTB.Text = Inv.GetProduct(MainList.SelectedIndex).ProductInfo;
			}
		}

		private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) {
			Regex regex = new Regex("[^0-9]+");
			e.Handled = regex.IsMatch(e.Text);
		}


	}
}
