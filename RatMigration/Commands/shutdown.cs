using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace RatMigration.Commands
{
    public class shutdown : Command
    {
        public shutdown(String name) : base(name) { }

        public override String execute(String[] args)
        {
            Console.WriteLine("Would you like to Shutdown Rat OS? Yes/No");
            string ans = Console.ReadLine();
            if (ans.ToLower() == "y" || ans.ToLower() == "yes" || ans.ToLower() == "Yes")
            {
                Sys.Power.Shutdown();
            }
            else
            {
                Console.Clear();
                return "Shutdown Aborted";
            }
                return "";
        }
    }
}
//* if (input.StartsWith("SHTDWN"))
//{
//    Console.WriteLine("Would you like to Shutdown Gizmo OS? Yes/No");
 //   string ans = Console.ReadLine();
//    if (ans.ToLower() == "y" || ans.ToLower() == "yes" || ans.ToLower() == "Yes")
//    {
 //       Sys.Power.Shutdown();
 //   }
 //   else
 //   {
 //       Console.Clear();
 //   }
