namespace RatMigration.RatShell
{
    /// <summary>
    /// This is the base class all commands must inherit.
    /// </summary>
    public abstract class Command
    {
        // Constructor for the 'Command' class
        public Command()
        {
            // Add the current instance of 'Command' to the 'Commands' list in the 'Shell' class.
            Shell.Commands.Add(this);
        }

        #region Methods

        // Declare an abstract method named 'Invoke' that must be implemented by derived classes.
        public abstract string Invoke(string[] Args);

        #endregion

        #region Fields

        // Public properties for the 'Description' and 'Name' of the command.
        public string Description { get; set; }
        public string Name { get; set; }

        #endregion
    }
}