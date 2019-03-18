using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork16_03_19
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randSeed = new Random();
            Game game = new Game();

            Start(game, randSeed);

            game.GameProcess();
        }
        static int Chose()
        {
            try
            {
                Console.WriteLine("1. Start\n" +
                                  "2. Add Player\n" +
                                  "3. Delete Player\n" +
                                  "4. Show all players\n" +
                                  "5. Card shuffling");

                int chose;

                if (int.TryParse(Console.ReadLine().Trim(), out chose))
                {
                    if(chose >= Constants.START_CHOSE && chose <= Constants.CARD_SHUFFLING_CHOSE)
                        return chose;
                }

                throw new ArgumentException("Такого выбора нет");
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return Chose();
            }
        }
        static void Start(Game game, Random randSeed)
        {
            bool isStart = false;

            switch (Chose())
            {
                case Constants.START_CHOSE:
                    if (game.Players.Count != Constants.NULL)
                        if (game.Players.Count % Constants.EVEN == Constants.NULL && game.Players.Count <= Constants.MAX_PLAYER_COUNT)
                            isStart = true;
                        else
                            Console.WriteLine("Нужно чертное кол игроков не больше 8");
                    else
                        Console.WriteLine("Нужно хотябы 2 игрока");
                    break;
                case Constants.ADD_PLAYER_CHOSE:
                    game.AddPlayer();
                    break;
                case Constants.DELETE_PLAYER:
                    game.DeletePlayer();
                    break;
                case Constants.SHOW_ALL_PLYERS:
                    game.ShowAllPlayers();
                    break;
                case Constants.CARD_SHUFFLING_CHOSE:
                    game.CardShuffling(randSeed.Next());
                    break;
            }

            if (isStart == true)
            {
                return;
            }
            Start(game, randSeed);
        }
    }
}
