using System;

namespace Test {
	class Program {
		static void Main(string[] args) {
			String [] names = { "meat1", "meat2", "meat3", "meat4", "meat5", "meat6", "meat7", "meat8", "meat9" };
			Random r = new Random(0);
			InventoryCore.Inventory inv = new InventoryCore.Inventory();
			foreach (string str in names) {
				inv.Add(new InventoryCore.Product(str));
			}
			Console.WriteLine(inv.Count+ " " + inv.getLength());

			inv.Add(new InventoryCore.Product("test"));
			Console.WriteLine(inv.Count + " " + inv.getLength());

			inv.SetProduct(5, new InventoryCore.Product("index5"));
			Console.WriteLine(inv.Count + " " + inv.getLength());

			inv.SetProduct(2, new InventoryCore.Product("index2"));
			Console.WriteLine(inv.Count + " " + inv.getLength());

			inv.SetProduct(0, new InventoryCore.Product("index0"));
			Console.WriteLine(inv.Count + " " + inv.getLength());

			inv.Add(new InventoryCore.Product("theEnd"));
			int count = 0;
			foreach (InventoryCore.Product pdt in inv)
				Console.WriteLine(count ++ +"\t"+pdt);

			Console.WriteLine("removing index 11");
			Console.WriteLine(	inv.Remove(11));
			Console.WriteLine("removed");
			inv.GetProduct(2).AddAmount(10);
			inv.GetProduct(2).SubAmount(3);
			count = 0;
			foreach (InventoryCore.Product pdt in inv)
				Console.WriteLine(count++ + "\t" + pdt);

			Console.WriteLine("index of  " + inv.IndexOf(new InventoryCore.Product("TheEnd")) );
			Console.WriteLine(inv.Remove(inv.IndexOf(new InventoryCore.Product("TheEnd"))));
			
			Console.WriteLine("clearing...");
			for (int i = 0; i < inv.Count;) 
				inv.Remove(0);
			
			Console.WriteLine("count: " + inv.Count);

			foreach (InventoryCore.Product pdt in inv)
				Console.WriteLine(count++ + "\t" + pdt);

			Console.Write("\nDone ...");
			Console.ReadLine();
		}
	}
}
