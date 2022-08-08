using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatMigration.Commands
{
    public class Credits : Command
    {
        public Credits (String name) : base (name) { }

        public override String execute(String[] args)
        {
            return "xyve#5469 & Tech Media";
        }

    }
}
