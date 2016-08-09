using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftKings
{
    public class LineUp
    {
        //set the min cost of the lineUp as you so choose
        private int _maxCost = 50000;
        private int _minCost = 42000;
        private List<List<Player>> _lineUps;
     

        public List<List<Player>> BuildLineUp(List<List<Player>> playerMatrix)
        {

            var _lineUps = new List<List<Player>> { };
            var lineUp = new List<Player> { };

            for (var i = 0; i < playerMatrix[0].Count(); i++) //qb's
            {
                lineUp.Add(playerMatrix[0][i]);
                for (var j = 0; j < playerMatrix[1].Count(); j++) //rb's
                {
                    lineUp.Add(playerMatrix[1][j]);
                    for (var k=0; k < playerMatrix[2].Count(); k++) //wr's
                    {
                        lineUp.Add(playerMatrix[2][k]);
                        for (var ii=0; ii< playerMatrix[3].Count(); ii++) //te's
                        {
                            lineUp.Add(playerMatrix[3][ii]);
                            for (var jj=0; jj< playerMatrix[4].Count(); jj++)
                            {
                                lineUp.Add(playerMatrix[4][jj]);
                                for (var kk=0; kk< playerMatrix[5].Count(); kk++)
                                {
                                    lineUp.Add(playerMatrix[5][kk]);

                                    if (lineUp.Distinct().Count() == lineUp.Count()) //also need ot test if player.cost is good
                                    {
                                        _lineUps.Add(lineUp);
                                    }
                                        
                                        
                                }
                            }
                        }
                    }
                }

            }

            return _lineUps;
        }

    }
}
