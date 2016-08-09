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


            ////////LineUp Class///////
            //build every possible lineup (QB, RB, RB, WR, WR, WR, TE, FLEX, DST)

            ///////Solutions Class//////
            //Calculate sum of each lineup Salary
            //Format output lists
            //For each lineUp in Solutions, if Salary >= minCost && Salary <= maxCost ($50,000), display the lineup

            //Test Code
            //var allPlayers = new AvailablePlayers();
            //var allPlayersList = allPlayers.BuildPlayerList();
            //var separatePlayers = new PlayersByPosition();

            //var qbList = separatePlayers.BuildQBList(allPlayersList);
            //var rbList = separatePlayers.BuildRBList(allPlayersList);
            //var wrList = separatePlayers.BuildWRList(allPlayersList);
            //var teList = separatePlayers.BuildTEList(allPlayersList);
            //var dstList = separatePlayers.BuildDSTList(allPlayersList);
            //var flexList = separatePlayers.BuildFlexList(allPlayersList);

            //foreach (var player in wrList)
            //{
            //    Console.WriteLine(player.Name + " " + player.Position + " " + player.Cost);

            //}
            var list = new PlayersByPosition();
            list.BuildPositionLists();



        }
    }
}
