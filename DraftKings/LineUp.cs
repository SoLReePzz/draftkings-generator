﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftKings
{
    public class LineUp
    {
        //Set the min cost of the lineUp as you so choose
        //I need to find a more efficient algorithm that actually works
        //Currently not getting the expected output and there is a TON of inefficiency
        private int _maxCost = 50000;
        private int _minCost = 46500;
     
        public void BuildLineUp(List<List<Player>> playerMatrix)
        {
            
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
                                                var totalCost = 0;
                                                var duplicateCheckList = new List<string> { };
                                                foreach (var player in lineUp)
                                                {
                                                    totalCost = player.Cost + totalCost;
                                                    duplicateCheckList.Add(player.Name);
                                                }
                                              
                                                if (totalCost <= _maxCost && totalCost >= _minCost && duplicateCheckList.Count() == 9) //Number 9 is players/lineup
                                                {
                                                    Console.WriteLine("Lineup ID: " + i + "" + j + "" + l + "" + k + "" + ll + "" + w + "" + ii + "" + jj + "" + kk);
                                                    foreach (var player in lineUp)
                                                    {
                                                        Console.WriteLine(player.Name);
                                                    }
                                                    Console.WriteLine(" ");
                                                }
                                                lineUp.RemoveAt(8); //remove flex
                                            }
                                            lineUp.RemoveAt(7); //remove dst
                                        }
                                        lineUp.RemoveAt(6); //remove te
                                    }
                                    lineUp.RemoveAt(5); //remove wr3
                                }
                                lineUp.RemoveAt(4); //remove wr2
                            }
                            lineUp.RemoveAt(3); //remove wr1
                        }
                        lineUp.RemoveAt(2); //remove rb2
                    }
                    lineUp.RemoveAt(1); //remove rb1
                }
                lineUp.RemoveAt(0); //remove qb
                //lineUp.Remove(playerMatrix[0][i]); //remove qb
            }

        }

    }
}
