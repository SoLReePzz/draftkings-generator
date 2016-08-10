using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;


namespace DraftKings
{
    public class AvailablePlayers
    {
        private List<Player> _allPlayers;


        //Methods to read the positions, Names, Salaries of each player and return the lists
        public List<Player> BuildPlayerList()
        {
           //Pull in excel workbook (.CSV downloaded from DK website)
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\Samuel Crawford\Documents\C-Sharp\DraftKings\DKSalaries-Mock.csv");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;

            //initialize _allPlayers list
            _allPlayers = new List<Player> { };

            //build all players list
            for (int i=2; i <= rowCount; i++)
            {
                var player = new Player();
                try
                {
                    player.Name = xlRange.Cells[i, 2].value.ToString();
                    player.Position = xlRange.Cells[i, 1].value.ToString();
                }
                catch (Exception)
                {

                    throw new ArgumentException("Can not vconvert Name and Position to strings");
                }
                
                try
                {
                    player.Cost = Convert.ToInt32(xlRange.Cells[i, 3].value);
                }
                catch (Exception)
                {

                    throw new ArgumentException("Can not convert Salary to integer value");
                }
                
                _allPlayers.Add(player);

            }

            //Cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //Release COM objects
            //Marshal.ReleaseComObject(xlRange);
            //Marshal.ReleaseComObject(xlWorksheet);

            //Close and release
            xlWorkbook.Close();
            //Marshal.ReleaseComObject(xlWorkbook);
            
            //quit and release
            xlApp.Quit();
            //Marshal.ReleaseComObject(xlApp);

            return _allPlayers;
        }
        
    }
}
