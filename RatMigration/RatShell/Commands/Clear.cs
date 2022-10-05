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
			Console.Clear();
			return string.Empty;
		}
	}
}