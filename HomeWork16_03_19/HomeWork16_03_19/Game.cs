using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork16_03_19
{
    public class Game
    {
        public List<Card> DeckOfCards { get; set; }
        public List<Player> Players { get; set; }
        public Dictionary<Player, Card> Table { get; set; }

        public Game()
        {
            Table = new Dictionary<Player, Card>();
            DeckOfCards = new List<Card>();

            Lears[] lears = new Lears[]
            {
                Lears.Spades,
                Lears.Clubs,
                Lears.Diamonds,
                Lears.Hearts
            };
            CardTypes[] cardTypes = new CardTypes[]
            {
                CardTypes.Six,
                CardTypes.Seven,
                CardTypes.Eight,
                CardTypes.Nine,
                CardTypes.Ten,
                CardTypes.Jack,
                CardTypes.Queen,
                CardTypes.King,
                CardTypes.Ace
            };

            for(int i = 0; i < Constants.LEARS_COUNT; i++)
            {
                for(int j = 0; j < Constants.CARD_TYPES_COUNT; j++)
                {
                    Card card = new Card(lears[i], cardTypes[j]);

                    DeckOfCards.Add(card);
                }
            }

            Players = new List<Player>();
        }
        public void AddPlayer()
        {
            Player newPlayer = new Player();

            newPlayer.Nickname = SetInformation.SetNickname();

            Players.Add(newPlayer);

            Console.WriteLine($"Игрок под ником {newPlayer.Nickname} был добавлен");
        }
        public void CardShuffling(int seed)
        {
            Random firstCardPosition = new Random();
            Random secondCardPosition = new Random(seed);
            Random randCount = new Random();

            int shuffelCount = randCount.Next(Constants.MIN_SHUFFEL_COUNT, Constants.MAX_SHUFFEL_COUNT);

            for(int i = 0; i < shuffelCount; i++)
            {
                int firstCard = firstCardPosition.Next(Constants.IN_DECK_CARD_COUNT);
                int secondCard = secondCardPosition.Next(Constants.IN_DECK_CARD_COUNT);

                Card temp = DeckOfCards[firstCard];
                DeckOfCards[firstCard] = DeckOfCards[secondCard];
                DeckOfCards[secondCard] = temp;
            }

        }
        public void ShowAllCards()
        {
            for(int i = 0; i < DeckOfCards.Count; i++)
            {
                Console.WriteLine(DeckOfCards[i].Type + " " + DeckOfCards[i].Lear);
            }
        }
        public void DistributionOfCards()
        {
            int count = DeckOfCards.Count / Players.Count;

            for(int i = 0; i < Players.Count; i++)
            {
                for(int j = 0; j < count; j++)
                {
                    Players[i].Cards.Add(DeckOfCards[i*count + j]);
                }
            }
        }
        public void DeletePlayer()
        {
            try
            {
                if (Players.Count != Constants.NULL)
                {
                    Console.WriteLine("Кого вы хотите удалить?");

                    for (int i = 0; i < Players.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {Players[i].Nickname}");
                    }

                    int chosenIndex;

                    if (int.TryParse(Console.ReadLine().Trim(), out chosenIndex))
                    {
                        if (chosenIndex > Constants.NULL && chosenIndex <= Players.Count)
                        {
                            Console.WriteLine($"Игрок {Players[chosenIndex-1].Nickname} был удален");

                            Players.RemoveAt(chosenIndex-1);

                            return;
                        }
                    }

                    throw new ArgumentException("Такого игрока нет");
                }
                else
                {
                    Console.WriteLine("Нет игроков");
                }
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                DeletePlayer();
            }
        }
        public void ShowAllPlayers()
        {
            if(Players.Count != Constants.NULL)
            {
                Console.WriteLine("====================================");
                for(int i = 0; i < Players.Count; i++)
                {
                    Console.WriteLine($"{i+1}. {Players[i].Nickname}");
                }
                Console.WriteLine("====================================");
            }
            else
            {
                Console.WriteLine("Нет игроков");
            }
        }

        public void GameProcess()
        {
            DistributionOfCards();

            bool isFinish = false;

            while (true)
            {
                for(int i = 0; i < Players.Count; i++)
                {
                    Console.WriteLine($"Ход {Players[i].Nickname}");
                    Console.WriteLine("==========================");

                    PlayerMove(Players[i]);

                    Console.WriteLine("==========================");
                }

                int winnerIndex = FindRoundWinner();

                Console.WriteLine($"Этот раунд выйграл {Players[winnerIndex].Nickname}");

                foreach(KeyValuePair<Player, Card> keyValue in Table)
                {
                    Players[winnerIndex].Cards.Add(keyValue.Value);
                }

                Table.Clear();

                for (int i = 0; i < Players.Count; i++)
                {
                    if(Players[i].Cards.Count == Constants.IN_DECK_CARD_COUNT)
                    {
                        isFinish = true;
                        Console.WriteLine($"Победитель игры {Players[i].Nickname}");
                        break;
                    }
                }

                if(isFinish == true)
                {
                    break;
                }
            }
        }
        public void PlayerMove(Player player)
        {
            try
            {
                Console.WriteLine("1. Положить карту");

                int chose;

                if (int.TryParse(Console.ReadLine().Trim(), out chose))
                {
                    Table.Add(player, player.Cards[Constants.FIRST_ELEMENT]);
                    player.Cards.RemoveAt(Constants.FIRST_ELEMENT);

                    return;
                }

                throw new ArgumentException("Нет такого действия");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                PlayerMove(player);
            }
        }
        public int FindRoundWinner()
        {
            Player winner = null;
            Card winnersCard = null;

            int i = 0;
            foreach(KeyValuePair<Player, Card> keyValue in Table)
            {
                if(winner is null)
                {
                    winner = keyValue.Key;
                    winnersCard = keyValue.Value;
                }
                else if(keyValue.Value > winnersCard)
                {
                    winner = keyValue.Key;
                    winnersCard = keyValue.Value;
                    ++i;
                }
            }

            return i;
        }
    }
}
