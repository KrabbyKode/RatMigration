using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatMigration.Commands
{
    public class Help : Command //whatever class we write past the colon, Help will inherit it
    {
        //this part sets the command
        public Help (String name) : base (name) { } //base refers to the parent (Command). We are taking a string, and passing it to the base
        //the part below sets up the response

        public override String execute(String[] args)
        {
            return "https://github.com/KrabbyKode/RatMigration/wiki";
            return "view ReadMe.txt in the Rat OS Installation folder.";



        }

    }
}
/*
 *          Console.WriteLine("Available Commands");
            Console.WriteLine("==================");
            Console.WriteLine("Help- displays commands");
            Console.WriteLine("Credits- Displays credits");
            Console.WriteLine("file- filesystem. It has several arguments:");
            Console.WriteLine("    create- creates file");
            Console.WriteLine("    erase- deletes file");
            Console.WriteLine("    createdir- creates folder/directory");
            Console.WriteLine("    ereasedir- erases folder/directory");
*/