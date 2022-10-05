// "taskkill -f -im chrome.exe" will be our blueprint, we model are commands after it
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatMigration.Commands {
    
    public class CommandManager
    {
        private List<Command> commands; //makes a list of commands called "commands"
        
        public CommandManager()
        {
            this.commands = new List<Command>(8);// the "1" is how many commands will be in our list. We have one so far
            //register commands here
            this.commands.Add(new Help("help")); //"help" is the command name
            this.commands.Add(new Credits("credits"));
            this.commands.Add(new time("time"));
            this.commands.Add(new File("file"));
            this.commands.Add(new clear("clear"));
            this.commands.Add(new shutdown("shutdown"));
            this.commands.Add(new restart("restart"));
            this.commands.Add(new sysinfo("sysinfo"));
        }

        public String processInput (String input)//take the inupt from the user, and processes command. String input would be something like "taskkill -f -im chrome.exe"
        {
            String[] split = input.Split(' '); //its called "split" because there will be a space between the command and arguments
            String label=split[0]; // strings count up from zero. So what we are doing here is checking thr first string (taskkil). label == taskkill. label is defined here

            List<String> args=new List<String>();

            int ctr=0; //this part is making a counter thats starts at 0 (just like the string) so what happens is that it will take apart from the name of the command (taskkill) and leaves the "-f -im chrome.exe" part
            foreach (String s in split)
            {
                if (ctr!=0)//as long as the counter is not 0, then add to string
                    args.Add(s);
                ++ctr; //adds one to the counter, which started at [0]
            }

            //if you type in a bullshit name, this next part will skip it because the command wasnt in the list
            foreach (Command cmd in this.commands) //this calls on the "commands" list we made up at the top. We are checking to see if the user entered a command that is on the list (like a bouncer)
            {
                if (cmd.name==label)//seeing if the command is on the list
                    return cmd.execute(args.ToArray());
                
            }
            return "Your command \"" + label + "\" does not exist!";
        }
    }
}
/* The array would contain four parts. Split would put a space (or whatever charecter we specify) between them all
 * taskkill [0]
 * -f [1]
 * -im [2]
 * chrome.exe [3]
 */