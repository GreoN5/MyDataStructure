using System;

namespace ItemList
{
	public class InvalidItemException : Exception
	{
		public InvalidItemException(string message) : base(message) { }
	}
}
