using System;

namespace ItemList
{
	public class ItemList<T>
	{
		private T[] _items;
		private const int _defaultCapacity = 5;

		private int _emptySpace;
		private int _filledSpace;

		public int ItemsCount { get; private set; }

		public ItemList()
		{
			this._items = new T[_defaultCapacity];

			this.ItemsCount = 0;
			this._filledSpace = 0;
			this._emptySpace = _defaultCapacity;
		}

		public ItemList(int capacity)
		{
			if (capacity <= 0)
			{
				throw new InvalidCapacityException("Capacity should be greater than 0!");
			}

			this._items = new T[capacity];

			this.ItemsCount = 0;
			this._filledSpace = 0;
			this._emptySpace = capacity;
		}

		public int GetFilledSpace()
		{
			return this._filledSpace;
		}

		public int GetEmptySpace()
		{
			return this._emptySpace;
		}

		public T GetItem(int index)
		{
			return this.ReturnItem(index);
		}

		public void AddItem(T item)
		{
			if (this.ItemsCount == this._items.Length)
			{
				T[] broadenItems = new T[this.ItemsCount * 2];

				this._items.CopyTo(broadenItems, 0);
				this._items = broadenItems;

				this._emptySpace = broadenItems.Length - this.ItemsCount;
			}

			this._items[this.ItemsCount] = item;
			this.ItemsCount++;

			this._filledSpace = this.ItemsCount;
			this._emptySpace--;
		}

		public void RemoveItem(T item)
		{
			if (!this.CheckIfItemExists(item))
			{
				throw new InvalidItemException("Item not found!");
			}

			int indexOfItem = this.GetIndexOfItem(item);

			this.ShiftArray(indexOfItem);
		}

		public T RemoveItemAt(int index)
		{
			if (!CheckIndex(index))
			{
				throw new ArgumentOutOfRangeException("Invalid index!");
			}

			T itemReturned = ReturnItem(index);

			this.ShiftArray(index);
			return itemReturned;
		}

		public T RemoveFirstItem()
		{
			T removedItem = this._items[0];

			this.ShiftArray(0);

			return removedItem;
		}

		public T RemoveLastItem()
		{
			T removedItem = this._items[this.ItemsCount - 1];

			this._filledSpace--;
			this.ItemsCount--;

			this._items[this.ItemsCount] = default(T);

			return removedItem;
		}

		public void ReplaceItemAt(int index, T item)
		{
			if (!CheckIndex(index))
			{
				throw new ArgumentOutOfRangeException("Invalid index of an item!");
			}

			this._items[index] = item;
		}

		public void ReplaceItemAtFirstPlace(T item)
		{
			this._items[0] = item;
		}

		public void ReplaceItemAtLastPlace(T item)
		{
			this._items[this.ItemsCount - 1] = item;
		}

		private void ShiftArray(int startIndex)
		{
			int index = startIndex;

			while (index < this.ItemsCount - 1)
			{
				this._items[index] = this._items[index + 1];
				index++;
			}

			this.ItemsCount--;
			this._filledSpace--;
			this._emptySpace++;

			this._items[this.ItemsCount] = default(T);
		}

		private bool CheckIfItemExists(T item)
		{
			for (int i = 0; i < this.ItemsCount - 1; i++)
			{
				if (this._items[i].Equals(item))
				{
					return true;
				}
			}

			return false;
		}

		private bool CheckIndex(int index)
		{
			if (index < 0 || index >= this.ItemsCount)
			{
				return false;
			}

			return true;
		}

		private int GetIndexOfItem(T item)
		{
			for (int i = 0; i < this.ItemsCount - 1; i++)
			{
				if (this._items[i] != null && this._items[i].Equals(item))
				{
					return i;
				}
			}

			return default;
		}

		private T ReturnItem(int index)
		{
			if (!CheckIndex(index))
			{
				throw new ArgumentOutOfRangeException("Invalid index!");
			}

			return this._items[index];
		}
	}
}
