using System;

namespace RatMigration.RatShell.Commands
{
	public class Shutdown : Command
	{
		public Shutdown()
		{
			Description = "Tool to shut down the system.";
			Name = nameof(Shutdown);
		}

		public override string Invoke(string[] Args)
        {
            Console.WriteLine("Would you like to Shutdown Rat OS? [Y]es/[N]o");
            string Answer = Console.ReadLine().ToLower();
            if (Answer == "y" || Answer == "yes")
            {
                Cosmos.System.Power.Shutdown();
			}
			// We can just assume it was aborted as the code will not go past the power function.
			return "Restart Aborted.";
		}
	}
}