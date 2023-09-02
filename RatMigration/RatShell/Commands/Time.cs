using System;

namespace RatMigration.RatShell.Commands
{
    // Define a class named 'Time' that derives from the 'Command' base class.
    public class Time : Command
    {
        // Constructor for the 'Time' class
        public Time()
        {
            // Set the description and name of the 'Time' command.
            Description = "Gets the current time of the system.";
            Name = nameof(Time);
        }

        // Implementation of the 'Invoke' method required by the 'Command' base class.
        // This method returns the current system time as a formatted string.
        public override string Invoke(string[] Args)
        {
            return DateTime.Now.ToString();
        }
    }
}
