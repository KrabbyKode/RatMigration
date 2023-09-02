using System;

namespace RatMigration.RatShell.Commands
{
	public class Clear : Command
	{
		public Clear()
		{
			Description = "Clears the console.";
			Name = nameof(Clear);
		}

		public override string Invoke(string[] Args)
		{
			Console.Clear(); //BE GONE, BITCH ASS SPAM!!!
			return string.Empty;
		}
	}
}