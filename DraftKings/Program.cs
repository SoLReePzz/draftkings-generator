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

            var list = new PlayersByPosition();
            list.BuildPositionLists();

        }
    }
}
