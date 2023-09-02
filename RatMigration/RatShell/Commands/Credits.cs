namespace RatMigration.RatShell.Commands
{
    // Define a class named 'Credits' that derives from the 'Command' base class.
    public class Credits : Command
    {
        // Constructor for the 'Credits' class
        public Credits()
        {
            // Set the description and name of the 'Credits' command.
            Description = "Returns the credits list.";
            Name = nameof(Credits);
        }

        // Implementation of the 'Invoke' method required by the 'Command' base class.
        public override string Invoke(string[] Args)
        {
            // Return a string containing the credits list for your program.
            return "Terminal.cs#4512, xyve#5469, Kernel#0365, and Tech Media";
        }
    }
}
