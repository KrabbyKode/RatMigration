using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RatMigration.RatShell.Commands
{
    public class System : Command
    {
        public System()
        {
            Description = "This command helps with interacting with files on the filesystem.";
            Name = nameof(System);
        }
        public override string Invoke(string[] Args)
        {
            string Response = "";
            try
            {
                switch (Args[0])  // Assuming Args is an array holding command-line arguments
                {
                    case "shutdown":
                    case "reboot":
                        Console.WriteLine($"Would you like to {(Args[0] == "shutdown" ? "Shutdown" : "reboot")} Rat OS? [Y]es/[N]o");
                        string answer = Console.ReadLine().ToLower();
                        if (answer == "y" || answer == "yes")
                        {
                            if (Args[0] == "shutdown")
                            {
                                Cosmos.System.Power.Shutdown();
                            }
                            else if (Args[0] == "reboot")
                            {
                                Cosmos.System.Power.Reboot();
                            }
                        }
                        // We can just assume it was aborted as the code will not go past the power function.
                        return $"{(Args[0] == "shutdown" ? "Shutdown" : "Restart")} Aborted.";


                    default:
                        Response += "Unexpected argument: " + Args[0]; //if you give a bullshit argument, it will tell you that it's an error and shame you with what you typed.
                        break;
                }


            }
            catch (Exception E)
            {
                return E.Message;
            }
            return Response;
        }
    }
}
       

