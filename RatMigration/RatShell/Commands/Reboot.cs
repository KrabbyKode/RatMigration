using System;

namespace RatMigration.RatShell.Commands
{
	public class Reboot : Command
	{
		public Reboot()
		{
			Description = "Tool to reboot the system.";
			Name = nameof(Reboot);
		}

		public override string Invoke(string[] Args)
		{
			Console.WriteLine("Would you like to reboot Rat OS? [Y]es/[N]o");
			string Answer = Console.ReadLine().ToLower();
			if (Answer == "y" || Answer == "yes")
			{
				Cosmos.System.Power.Reboot();
			}
			// We can just assume it was aborted as the code will not go past the power function.
			return "Restart Aborted.";
		}
	}
}
