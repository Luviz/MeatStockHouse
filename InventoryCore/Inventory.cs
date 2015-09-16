using System;
using System.Collections;
using System.Collections.Generic;

namespace InventoryCore {
	public class Inventory : IEnumerable{
		//public List<Product> Products { get; private set; } //why use this when I can make it much more fun
		private Product[] Products;
		public int Count { get; private set; }

		public Inventory() {
			Products = new Product[10];
			Count = 0;
		}

		/// <summary>
		/// add a new Product to the list
		/// </summary>
		/// <param name="newPdt"></param>
		public void Add(Product newPdt) {
			if (Count < Products.Length) {
				Products[Count++] = newPdt;
			}
			else {
				// expand the list
				ExpandArray();
				Add(newPdt);
			}
		}

		/// <summary>
		/// Expands the Array with a countstan amount of 10
		/// </summary>
		private void ExpandArray() {
			Product[] tmp = new Product[Products.Length + 10];
			for (int i = 0; i < Products.Length; i++) {
				tmp[i] = Products[i];	//filling tmp with products 
			}
			Products = tmp;
		}

		public Product GetProduct (int index) {
			if (index < Count)
				return Products[index];
			else
				throw new System.IndexOutOfRangeException();
		}
		
		/// <summary>
		/// will add and expand the array
		/// </summary>
		/// <param name="index"></param>
		/// <param name="newPdt"></param>
		public void SetProduct(int index, Product newPdt) {

			if (index < Count) {
				Product[] tmp = Count  < Products.Length ? new Product[Products.Length] : new Product[Products.Length + 1];
				int i = 0;
				for( ; i < index; i++) 
					tmp[i] = Products[i];		//Pre - Filling
				tmp[i++]= newPdt;				//adding
				for (; i < tmp.Length; i++)
					tmp[i] = Products[i - 1];   //Post filling
				Products = tmp;
				Count++;
			}
			else
				throw new System.IndexOutOfRangeException();
		}
		//remove this DEBUG only
		public int getLength() {
			return Products.Length;
		}

		public Product Remove(int index) {
			if (index < Count && index > -1) {
				Product[] tmp = new Product[Products.Length];
				int i = 0;
				for (; i < index; i++)
					tmp[i] = Products[i];
				//Console.WriteLine(i);//DEBUG
				Product ret = Products[i++];
				for (; i < Products.Length; i++)
					tmp[i - 1] = Products[i];
				Products = tmp;
				Count--;
				return ret;
			}
			else if (index  == -1) {
				return null;
			}
			else {
				throw new System.IndexOutOfRangeException();
			}
		}
		public Product Remove(Product pdt) {
			return Remove(IndexOf(pdt));
		}
		public int IndexOf(Product pdt) {
			int ret = -1;
			bool found = false;
			int c = 0;
			while (!found && c < Count) {
				if (pdt.Equals(Products[c++])) {
					found = true;
					ret = c-1;
				}
			}
			return ret;
		}

		public Product[] GetProducts() {
			Product[] tmp = new Product[Count];
			for (int i = 0; i < Count; i++)
				tmp[i] = Products[i];
			return tmp;
		}

		public IEnumerator GetEnumerator() {
			Product[] tmp = new Product[Count];
			for (int i =0; i < Count; i++) 
				tmp[i] = Products[i];
			return tmp.GetEnumerator();
		}
	}
}
