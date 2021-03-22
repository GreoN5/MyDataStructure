using System;

namespace ItemList
{
	public class InvalidCapacityException : Exception
	{
		public InvalidCapacityException(string message) : base(message) { }
	}
}
