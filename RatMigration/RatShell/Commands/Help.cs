namespace RatMigration.RatShell.Commands
{
	public class Help : Command
	{
		public Help()
		{
			Description = $"Command to link for getting help with {nameof(RatMigration)}";
			Name = nameof(Help);
		}

		public override string Invoke(string[] Args)
		{
			string Response =
				"\n==============================" +
				"\nList of all available commands" +
				"\n==============================";
			for (int I = 0; I < Shell.Commands.Count; I++)
			{
				Response += '\n' + Shell.Commands[I].Name;
			}

			return
				"https://github.com/KrabbyKode/RatMigration/wiki\n" +
				"View the ReadMe.txt in the Rat OS Installation folder.\n" +
				Response;
		}
	}
}