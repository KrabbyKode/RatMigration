using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatMigration.RatShell.Commands
{
    // Define a class named 'Info' that derives from the 'Command' base class.
    public class Info : Command
    {
        // Constructor for the 'Info' class
        public Info()
        {
            // Set the description and name of the 'Info' command.
            Description = "Gets information about the system.";
            Name = nameof(Info);
        }

        // Declare fields to store system information
        int screenX = 800;
        int screenY = 640;
        public string user = "user";
        public string hostName = "rat_os";
        public string version = "v 0.2.10";

        // Implementation of the 'Invoke' method required by the 'Command' base class.
        public override string Invoke(string[] Args)
        {
            string Response = "";

            // Retrieve information about the system's memory
            uint maxmem = Cosmos.Core.CPU.GetAmountOfRAM();
            ulong availableMem = Cosmos.Core.GCImplementation.GetAvailableRAM();
            ulong usedmem = availableMem - maxmem;

            try
            {
                // Check the first argument provided to the 'Info' command.
                switch (Args[0])
                {
                    case "user":
                        // If the argument is "user," return the username.
                        Response += user;
                        break;

                    case "mem":
                        // If the argument is "mem," return memory-related information.
                        Response += "Memory Used: " + ((usedmem / 1024) / 1024) + "/" + maxmem; // Display used and total memory.
                        Response += "\nMemory Available: " + availableMem; // Display available memory.
                        break;

                    case "screen":
                        // If the argument is "screen," return screen size information.
                        Response += "Screensize (Columns and Rows): " + screenX + " x " + screenY;
                        break;

                    case "ver":
                        // If the argument is "ver," return the version of the system.
                        Response += version;
                        break;

                    case "host":
                        // If the argument is "host," return the host name.
                        Response += hostName;
                        break;

                    default:
                        // Handle unexpected arguments by including an error message in the response.
                        Response += "Unexpected argument: " + Args[0];
                        break;
                }
            }
            catch (Exception E)
            {
                // If an exception occurs, return the error message.
                return E.Message;
            }

            // Return the response, which may contain system information or an error message.
            return Response;
        }
    }
}
