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
        private int _minCost = 46500;
     
        public void BuildLineUp(List<List<Player>> playerMatrix)
        {
            //I totally forgot about RB2, WR2, WR3!!!
            var lineUp = new List<Player> { };

            for (var i = 0; i < playerMatrix[0].Count(); i++) //qb's
            {
                lineUp.Add(playerMatrix[0][i]);
                for (var j = 0; j < playerMatrix[1].Count(); j++) //rb1's
                {
                    lineUp.Add(playerMatrix[1][j]);
                    for (var l = 0; l < playerMatrix[1].Count(); l++) //rb2's
                    {
                        lineUp.Add(playerMatrix[1][l]);
                        for (var k = 0; k < playerMatrix[2].Count(); k++) //wr1's
                        {
                            lineUp.Add(playerMatrix[2][k]);
                            for (var ll = 0; ll < playerMatrix[2].Count(); ll++) //wr2's
                            {
                                lineUp.Add(playerMatrix[2][ll]);
                                for (var w = 0; w < playerMatrix[2].Count(); w++) //wr3's
                                {
                                    lineUp.Add(playerMatrix[2][w]);
                                    for (var ii = 0; ii < playerMatrix[3].Count(); ii++) //te's
                                    {
                                        lineUp.Add(playerMatrix[3][ii]);

                                        for (var jj = 0; jj < playerMatrix[4].Count(); jj++) //dst's
                                        {
                                            lineUp.Add(playerMatrix[4][jj]);

                                            for (var kk = 0; kk < playerMatrix[5].Count(); kk++) //flex's
                                            {
                                                lineUp.Add(playerMatrix[5][kk]);
                                                var flexName = playerMatrix[5][kk].Name;
                                                var totalCost = 0;
                                                var duplicateCheckList = new List<string> { };
                                                foreach (var player in lineUp)
                                                {
                                                    totalCost = player.Cost + totalCost;
                                                    duplicateCheckList.Add(player.Name);
                                                }
                                                if (totalCost <= _maxCost && totalCost >= _minCost && duplicateCheckList.Distinct().Count() == 9) //Number 9 is players/lineup
                                                {

                                                    Console.WriteLine("Lineup ID: " + i + "" + j + "" + l + "" + k + "" + ll + "" + w + "" + ii + "" + jj + "" + kk);
                                                    foreach (var player in lineUp)
                                                    {
                                                        Console.WriteLine(player.Name);
                                                    }
                                                    Console.WriteLine(" ");
                                                }
                                                lineUp.Remove(playerMatrix[5][kk]); //remove flex
                                            }
                                            lineUp.Remove(playerMatrix[4][jj]); //remove DST
                                        }
                                        lineUp.Remove(playerMatrix[3][ii]); //remove te
                                    }
                                    lineUp.Remove(playerMatrix[2][w]); //remove wr3
                                }
                                lineUp.Remove(playerMatrix[2][ll]); //remove wr2
                            }
                            lineUp.Remove(playerMatrix[2][k]); //remove wr1
                        }
                        lineUp.Remove(playerMatrix[1][l]); //remove rb2
                    }
                    lineUp.Remove(playerMatrix[1][j]); //remove rb1
                }
                lineUp.Remove(playerMatrix[0][i]); //remove qb
            }

        }

    }
}
