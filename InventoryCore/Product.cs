using System;

namespace InventoryCore {
	public class Product {
		public string Name { get; set; }
		public DateTime AddedDate { get; private set; }
		private int _Amount;
		public int Amount { get { return _Amount; } }
		public string ProductInfo { get; set; }

		public Product(string name) {
			Name = name;
			_Amount = 0;
			ProductInfo = "n/a";
			AddedDate = DateTime.Now;
		}
		public Product(string name, int amount) {
			Name = name;
			_Amount = amount;
			ProductInfo = "n/a";
			AddedDate = DateTime.Now;
		}
		public Product(string name, int amount, string info) {
			Name = name;
			_Amount = amount;
			ProductInfo = info;
			AddedDate = DateTime.Now;
		}

		public void AddAmount(int amount) {
			_Amount += amount;
		}
		public void SubAmount(int amount) {
			_Amount -= amount;
		}

		public override string ToString() {
			return "name: " + Name + " amount: " + _Amount + " Added: " + AddedDate.ToShortDateString();
		}
	}
}
