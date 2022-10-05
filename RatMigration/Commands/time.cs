using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatMigration.Commands
{
    public class time : Command
    {
        //this part sets the command
        public time (String name) : base (name) { }
        //the part below sets up the response

        public override String execute(String[] args)
        {
            DateTime.Now.ToString("hh: mm:ss tt"); //could be replaced with Cosmos.HAL.RTC
            Console.WriteLine(DateTime.Now);
            return "";

        }

    }
}
//Make a switch to be able to turn time setting from Advanced (hh:mm:ss tt) to Simple (hh:mm)