using System;

namespace ItemList
{
	public class Program
	{
		public static void Main(string[] args)
		{
			ItemList<int> myItems = new ItemList<int>();

			myItems.AddItem(2);
			myItems.AddItem(3);
			myItems.AddItem(5);
			myItems.AddItem(1);
			myItems.AddItem(10);
			myItems.AddItem(12);
			myItems.AddItem(100);
			myItems.AddItem(56);
			myItems.AddItem(54);

			for (int i = 0; i < myItems.ItemsCount; i++)
			{
				Console.WriteLine(myItems.GetItem(i));
			}

			Console.WriteLine();
			Console.WriteLine("--------------------------------------------------------");
			Console.WriteLine("--------------------------------------------------------");
			Console.WriteLine();

			Console.WriteLine($"Empty space of the item list: {myItems.GetEmptySpace()}");
			Console.WriteLine($"Filled space of the item list: {myItems.GetFilledSpace()}");

			Console.WriteLine();
			Console.WriteLine($"Item: {myItems.GetItem(2)}");
			Console.WriteLine();

			var firstItem = myItems.RemoveFirstItem();
			Console.WriteLine();
			Console.WriteLine("After removed first item:");

			for (int i = 0; i < myItems.ItemsCount; i++)
			{
				Console.WriteLine(myItems.GetItem(i));
			}

			Console.WriteLine();
			Console.WriteLine($"First item returned: {firstItem}");
			Console.WriteLine();

			var lastItem = myItems.RemoveLastItem();
			Console.WriteLine();
			Console.WriteLine("After last item removed:");

			for (int i = 0; i < myItems.ItemsCount; i++)
			{
				Console.WriteLine(myItems.GetItem(i));
			}

			Console.WriteLine();
			Console.WriteLine($"Last item returned: {lastItem}");
			Console.WriteLine();

			var removedItemAt = myItems.RemoveItemAt(4);
			Console.WriteLine();
			Console.WriteLine("After removed item at position:");
			
			for (int i = 0; i < myItems.ItemsCount; i++)
			{
				Console.WriteLine(myItems.GetItem(i));
			}

			Console.WriteLine();
			Console.WriteLine($"Item at position returned: {removedItemAt}");
			Console.WriteLine();

			myItems.RemoveItem(100);
			Console.WriteLine();
			Console.WriteLine("After removed item:");

			for (int i = 0; i < myItems.ItemsCount; i++)
			{
				Console.WriteLine(myItems.GetItem(i));
			}

			myItems.ReplaceItemAt(2, 15);
			Console.WriteLine();
			Console.WriteLine("After replaced item:");

			for (int i = 0; i < myItems.ItemsCount; i++)
			{
				Console.WriteLine(myItems.GetItem(i));
			}

			myItems.ReplaceItemAtFirstPlace(7);
			Console.WriteLine();
			Console.WriteLine("After replaced first item:");

			for (int i = 0; i < myItems.ItemsCount; i++)
			{
				Console.WriteLine(myItems.GetItem(i));
			}

			myItems.ReplaceItemAtLastPlace(69);
			Console.WriteLine();
			Console.WriteLine("After replaced last item:");

			for (int i = 0; i < myItems.ItemsCount; i++)
			{
				Console.WriteLine(myItems.GetItem(i));
			}
		}
	}
}
