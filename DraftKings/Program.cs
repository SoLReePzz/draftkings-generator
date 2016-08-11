using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftKings
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create new Player by Position Class to build the player matrix
            var list = new PlayersByPosition();
            
            //Testing Player Matrix output to pass into LineUp.cs methods
            list.BuildPositionLists();

            //TESTING LINEUP CLASS
            //Create new LineUp class, call BuildLineUp method with player matrix return from list.BuildPositionLists method
            //Uncomment below here to run program
            var lineUp = new LineUp();
            lineUp.BuildLineUp(list.BuildPositionLists());

        }
    }
}
