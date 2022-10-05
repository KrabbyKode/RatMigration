using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace RatMigration.Commands
{
    public class restart : Command
    {
        public restart(String name) : base(name) { }

        public override String execute(String[] args)
        {
            Console.WriteLine("Would you like to restart Rat OS? Yes/No");
            string ans = Console.ReadLine();
            if (ans.ToLower() == "y" || ans.ToLower() == "yes" || ans.ToLower() == "Yes")
            {
                Sys.Power.Reboot();
            }
            else
            {
                Console.Clear();
                return "Restart Aborted";
            }
            return "";
        }
    }
}
