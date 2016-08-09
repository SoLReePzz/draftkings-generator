using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftKings
{
    public class PlayersByPosition
    {
        //private lists for each position
        private List<Player> _qB;
        private List<Player> _rB;
        private List<Player> _wR;
        private List<Player> _tE;
        private List<Player> _flex;
        private List<Player> _dST;

        //Some players do not see the field because they suck (relatively) 
        //Set the cutoff cost to exclude these degenerates from our lineups
        private int _qBCutoffCost = 5000;
        private int _rBCutoffCost = 3000;
        private int _wRCutoffCost = 3000;
        private int _tECutoffCost = 3000;
        private int _dSTCutoffCost = 1000;

        public List<List<Player>> BuildPositionLists()
        {
            //Create an instance of the AvailablePlayers.cs, Build full player list
            var allPlayers = new AvailablePlayers();
            var allPlayersList = allPlayers.BuildPlayerList();

            //Create lists for each position plus flex option by passing in full player list
            var qbList = BuildQBList(allPlayersList);
            var rbList = BuildRBList(allPlayersList);
            var wrList = BuildWRList(allPlayersList);
            var teList = BuildTEList(allPlayersList);
            var dstList = BuildDSTList(allPlayersList);
            _rB = rbList;
            _wR = wrList;
            _tE = teList;
            var flexList = BuildFlexList();

            

            //Return a matrix of the lists here, rows are by position (QB, RB, WR, TE, DST, FLEX)...
            var positionTable = new List<List<Player>> { };
            var row = new List<Player> { };
            row = qbList;
            positionTable.Add(row);
            row = rbList;
            positionTable.Add(row);
            row = wrList;
            positionTable.Add(row);
            row = teList;
            positionTable.Add(row);
            row = dstList;
            positionTable.Add(row);
            row = flexList;
            positionTable.Add(row);

            //Testing the matrix to pass into the LineUp class
            for (var i =0; i < positionTable.Count(); i++)
            {
                for (var j=0; j < positionTable[i].Count(); j++)
                {
                    Console.WriteLine(positionTable[i][j].Name);
                }
            }

            return positionTable;
        }


        public List<Player> BuildQBList(List<Player> availablePlayers)
        {
            var _qB = new List<Player> { };
            foreach (var player in availablePlayers)
            {
                if (player.Position == "QB" && player.Cost > _qBCutoffCost)
                    _qB.Add(player);
            }

            return _qB;
        }

        public List<Player> BuildRBList(List<Player> availablePlayers)
        {
            var _rB = new List<Player> { };
            foreach (var player in availablePlayers)
            {
                if (player.Position == "RB" && player.Cost > _rBCutoffCost)
                    _rB.Add(player);
            }

            return _rB;
        }

        public List<Player> BuildWRList(List<Player> availablePlayers)
        {
            var _wR = new List<Player> { };
            foreach (var player in availablePlayers)
            {
                if (player.Position == "WR" && player.Cost > _wRCutoffCost)
                    _wR.Add(player);
            }

            return _wR;
        }

        public List<Player> BuildTEList(List<Player> availablePlayers)
        {
            var _tE = new List<Player> { };
            foreach (var player in availablePlayers)
            {
                if (player.Position == "TE" && player.Cost > _tECutoffCost)
                    _tE.Add(player);
            }

            return _tE;
        }

        public List<Player> BuildDSTList(List<Player> availablePlayers)
        {
            var _dST = new List<Player> { };
            foreach (var player in availablePlayers)
            {
                if (player.Position == "DST" && player.Cost > _dSTCutoffCost)
                    _dST.Add(player);
            }

            return _dST;
        }

        public List<Player> BuildFlexList()
        {
            var _flex = new List<Player> { };
            try
            {
                _flex.AddRange(_rB);
                _flex.AddRange(_wR);
                _flex.AddRange(_tE);
            }
            catch (Exception)
            {

                throw new ArgumentException("The ranges could not be added to the Flex player list");
            }


            return _flex;
        }

        
    }
}
