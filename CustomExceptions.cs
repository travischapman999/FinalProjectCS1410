using System;
using System.Collections.Generic;
using System.Text;

namespace CustomExceptions
{
	public class PlayerNotFoundException : Exception
	{
		public PlayerNotFoundException()
			: base("You are not in our system.") { }
	}
	public class InvalidInputException : Exception
	{
		public InvalidInputException()
			: base("Invalid input. Please try again.") { }
	}

}
