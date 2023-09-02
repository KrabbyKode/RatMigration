namespace RatMigration.RatShell.Commands
{
    // Define a class named 'Help' that derives from the 'Command' base class.
    public class Help : Command
    {
        // Constructor for the 'Help' class
        public Help()
        {
            // Set the description and name of the 'Help' command.
            Description = $"Command to link for getting help with {nameof(RatMigration)}";
            Name = nameof(Help);
        }

        // Implementation of the 'Invoke' method required by the 'Command' base class.
        public override string Invoke(string[] Args)
        {
            string Response =
                "\n===============================" +
                "\nList of all available commands:" +
                "\n===============================";

            // Loop through the list of available commands and append their names to the response.
            for (int I = 0; I < Shell.Commands.Count; I++)
            {
                Response += '\n' + Shell.Commands[I].Name;
            }

            // Return a response containing a link to the RatMigration wiki, a reference to ReadMe.txt,
            // and a list of available commands.
            return
                "https://github.com/KrabbyKode/RatMigration/wiki\n" +
                "View the ReadMe.txt in the Rat OS Installation folder.\n" +
                Response;
        }
    }
}
