using System;

//task №6 (Game 21)

namespace _1st_LR
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] deck = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int player = 0, computer = 0, card, playerCount = 0, сomputerCount = 0, deduct;
            string ace, selection;
            bool exit2 = false;

            Stirring(rand, ref deck);

            while (!exit2)
            {
                playerCount = 0;
                Console.Clear();
                string choice;
                bool exit1 = false;
                while (!exit1)
                {
                    card = deck[0];
                    if (card == 11)
                    {
                        playerCount++;
                    }
                    Stirring(rand, ref deck);

                    player = CheckScore(player, card);

                    if (player > 21)
                    {
                        Console.WriteLine("You lost. Your score is above 21.");
                        if (playerCount == 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You have some spare aces. You can get rid of them to avoid overflow.\nDo you want to do this?(Yes/No)\n");
                            ace = SymbolCkeck();

                            if (ace == "Yes")
                            {
                                Console.WriteLine($"You have {playerCount} spare aces. How many would you like to get rid of?\nEnter your number: ");
                                deduct = InputCheck(1, playerCount);

                                for (int i = 0; i < deduct; i++)
                                {
                                    player -= 10;
                                    playerCount--;
                                }

                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    Console.Write("Do you want to take another card?(Yes/No)\n");
                    choice = SymbolCkeck();
                    if (choice == "No")
                    {
                        exit1 = true;
                    }
                }

                Console.WriteLine("\n");

                if (player <= 21)
                {
                    Console.WriteLine("Computer cards: ");
                    do
                    {
                        Stirring(rand, ref deck);
                        card = deck[0];
                        Console.WriteLine(card);
                        computer += card;
                        if (card == 11)
                        {
                            сomputerCount++;
                        }

                    } while (computer <= 17);

                    if (computer > 21)
                    {
                        if (сomputerCount != 0)
                        {
                            int debt = rand.Next(0, 1);
                            if (debt == 0)
                            {
                                while (computer > 21 && сomputerCount > 0)
                                {
                                    computer -= 10;
                                    сomputerCount--;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    Console.WriteLine($"\nThe Computer's score is: {computer}");
                    WinnerCheck(player, computer);
                }

                player = computer = card = 0;
                Console.Write("Do you want to play one more time?(Yes/No)\n");
                selection = SymbolCkeck();
                if (selection == "No")
                {
                    exit2 = true;
                }
            }
        }

        private static int CheckScore(int player, int card)
        {
            Console.WriteLine("Your card is {0}", card);
            player += card;
            Console.WriteLine($"Your score is: {player}");
            return player;
        }

        static string SymbolCkeck()
        {
            string variety;
            while (true)
            {
                variety = Console.ReadLine();
                if (variety == "Yes" || variety == "No")
                {
                    break;
                }
                Console.WriteLine("Error! Character entered incorrectly. Try again.");
            }
            return variety;
        }

        static int InputCheck(int LowValue, int HighValue)
        {
            int check;
            while (true)
            {
                while (!int.TryParse(Console.ReadLine(), out check))
                {
                    Console.WriteLine("Error! Character entered incorrectly. Try again.");
                }
                if (check >= LowValue && check <= HighValue)
                {
                    break;
                }
                Console.WriteLine("Error! Character entered incorrectly. Try again.");
            }

            return check;
        }

        static void WinnerCheck(int player, int computer)
        {
            string result = "ERROR";
            if (player > computer)
            {
                result = "you won";
            }
            else if (player == computer)
            {
                result = "tie";
            }
            else if (player < computer && computer <= 21)
            {
                result = "you lost";
            }
            else if (player < computer && computer >= 21)
            {
                result = "you won";
            }
            Console.WriteLine("\nGame outcome:" + result + "\n");
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void Stirring(Random a, ref int[] deck)
        {
            for (int i = 0; i < deck.Length; i++)
            {
                var randomIndex1 = a.Next(0, deck.Length);
                var randomIndex2 = a.Next(0, deck.Length);
                Swap(ref deck[randomIndex1], ref deck[randomIndex2]);
            }
        }
    }
}
