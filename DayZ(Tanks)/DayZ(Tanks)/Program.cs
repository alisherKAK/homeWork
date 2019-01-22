using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLib.WorldOfTanks;

namespace DayZ_Tanks_
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int firstTeamWins = Constants.NULL;
                int secondTeamWins = Constants.NULL;
                Tank[] firstTankTeam = new Tank[Constants.TANKS_COUNT_IN_GAME];
                Tank[] secondTankTeam = new Tank[Constants.TANKS_COUNT_IN_GAME];
                for(int i = 0; i < Constants.TANKS_COUNT_IN_GAME; i++)
                {
                    firstTankTeam[i] = new Tank(MyClassLib.TanksName.T_34);
                    secondTankTeam[i] = new Tank(MyClassLib.TanksName.Pantera);
                }
                
                for(int i = 0; i < Constants.TANKS_COUNT_IN_GAME; i++)
                {
                    if (firstTankTeam[i] ^ secondTankTeam[i])
                    {
                        ++firstTeamWins;
                    }
                    else
                    {
                        ++secondTeamWins;
                    }
                }

                if(firstTeamWins > secondTeamWins)
                {
                    Console.WriteLine("First Team Win!");
                }
                else if(firstTeamWins < secondTeamWins)
                {
                    Console.WriteLine("Second Team Win!");
                }
                else
                {
                    Console.WriteLine("Draw!");
                }
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
