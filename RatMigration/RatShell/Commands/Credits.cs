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
			return "Terminal.cs#4512, xyve#5469, Kernel#0365, and Tech Media";
		}
	}
}