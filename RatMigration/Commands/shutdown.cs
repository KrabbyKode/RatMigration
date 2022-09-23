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
            Sys.Power.Shutdown();
            return "Shutting Down";
        }
    }
}
