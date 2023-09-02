using System.Collections.Generic;
using System;

namespace RatMigration.RatShell
{
    public static class Shell
    {
        #region Methods

        public static ReturnCode TryInvoke(string Name, string[] Args, out string Return)
        {
            // Check if there are no commands available
            if (Commands.Count == 0)
            {
                Return = "Command not found!";
                return ReturnCode.CommandNotFound;
            }

            // Loop through the available commands to find a matching one
            for (int I = 0; I < Commands.Count; I++)
            {
                // Use .ToLower to normalize strings for case-insensitive comparison
                if (Commands[I].Name.ToLower() == Name.ToLower())
                {
                    // Call the matching command's Invoke method with 'Args' and store the result in 'Return'
                    Return = Commands[I].Invoke(Args);
                    return ReturnCode.Success;
                }
            }

            // If no matching command is found, return an error message
            Return = $"Command '{Name}' not found!";
            return ReturnCode.CommandNotFound;
        }

        public static string Invoke(string Name, string[] Args)
        {
            // Call TryInvoke with 'Name' and 'Args' as arguments and store the result in the 'S' variable
            TryInvoke(Name, Args, out string S);

            // Return the result
            return S;
        }

        public static string Invoke(string[] Args)
        {
            // Create a new array (NewArgs) with one less element than Args
            string[] NewArgs = new string[Args.Length - 1];

            // Copy elements from Args to NewArgs, skipping the first element
            for (int I = 0; I < NewArgs.Length; I++)
            {
                NewArgs[I] = Args[I + 1];
            }

            // Call TryInvoke with the first element of Args and NewArgs as arguments
            // and store the result in the 'Return' variable
            TryInvoke(Args[0], NewArgs, out string Return);

            // Return the result
            return Return;
        }

        public static void Initialize()
        {
            // Create all command objects. Since we have the code that allows for uppercase and lowercase, we dont have to worry about the capitization of the command
            _ = new Commands.Clear();
            _ = new Commands.Credits();
            _ = new Commands.File();
            _ = new Commands.Help();
            _ = new Commands.Info();
            _ = new Commands.Time();
            _ = new Commands.Network();
            _ = new Commands.Display();
            //_ = new Commands.Dictionary(); busted as of now, plus its hidden in VS
            _ = new Commands.System();


            // Log for debugging. Doesnt say much right now, but if you're seeing it, then everything went well
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[ OK ] "); //this bit looks cool, I should do more with this
            Console.ResetColor();
            Console.WriteLine("Initialized RatShell successfully. Get typing biatch!");
        }


        #endregion

        #region Fields

        internal static List<Command> Commands { get; set; } = new(); // Declare a static list of Command objects

        #endregion
    }
}
