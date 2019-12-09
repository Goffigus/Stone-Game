using System;
using static System.Console;

namespace Stone_Game
{
    class Program
    {
        static void Main(string[] args)
        {

            string player1;
            string player2; 

            int pile1;
            int pile2;
            int pile3;

            Random rand = new Random();

            pile1 = rand.Next(5, 50);
            pile2 = rand.Next(5, 50);
            pile3 = rand.Next(5, 50);

            player1 = playerNameMethod();
            player2 = playerNameMethod();


            bool newGame = true;
            while (newGame)
            {
                pile1 = rand.Next(5, 50);
                pile2 = rand.Next(5, 50);
                pile3 = rand.Next(5, 50);

                bool win = false;
                while (!win)
                {
                    if (!win)
                    {
                        while (!playerPick(player1, ref pile1, ref pile2, ref pile3))
                        {
                            WriteLine("Invalid move! Please try again");
                        }

                        win = winConditon(player1, pile1, pile2, pile3);
                    }

                    if (!win)
                    {
                        while (!playerPick(player2, ref pile1, ref pile2, ref pile3))
                        {
                            WriteLine("Invalid move! Please try again");
                        }
                        win = winConditon(player2, pile1, pile2, pile3);
                    }
                    
                }

                WriteLine("Would you like to play again? (y/n)");
                string newGameInput = ReadLine();
                if(newGameInput == "n")
                {
                    WriteLine("Stopping game, goodbye.");
                    newGame = false;
                }
            }

        }

        public static string playerNameMethod()
        {
            WriteLine("What is the player's name?");
            string player = ReadLine();
            WriteLine("Welcome {0}", player);
            return player;
        }
        public static bool winConditon(string player, int pile1, int pile2, int pile3)
        {
            bool win;

            

            if (pile1 == 0 && pile2 == 0 && pile3 == 0)
            {
                win = true;
                WriteLine("{0} Wins!", player);
            }
            else
            {
                win = false;
            }


            return win;
        }
        public static bool playerPick(string player, ref int pile1, ref int pile2, ref int pile3)
        {
            
            bool allowedMove = false;


            WriteLine("First pile has {0} Second pile has {1} Third pile has {2}", pile1, pile2, pile3);
            WriteLine("{0}, how many rocks would you like to take?", player);
            string playerPick = ReadLine();
            WriteLine("Which piles would {0} like to take from? (Write 1, 2, 3, 12, 13, 23, or 123 for the piles you want)", player);
            string pilesPick = ReadLine();

            int pick = Convert.ToInt32(playerPick);

            bool pile1Picked;
            bool pile2Picked;
            bool pile3Picked;

            if (pilesPick.IndexOf("1") > -1)
                pile1Picked = true;
            else
                pile1Picked = false;
            if (pilesPick.IndexOf("2") > -1)
                pile2Picked = true;
            else
                pile2Picked = false;
            if (pilesPick.IndexOf("3") > -1)
                pile3Picked = true;
            else
                pile3Picked = false;


            if (pile1Picked)
            {
                pile1 -= pick; // pile1 -= pick; 

            }

            if (pile2Picked)
            {
                pile2 -= pick;
                
            }

            if (pile3Picked)
            {
                pile3 -= pick; 
            }

            if(pile1 >= 0 && pile2 >= 0 && pile3 >= 0)
            {
                allowedMove = true;
            }

            if (!allowedMove)//undoes the move if the move is not allowed
            {
                WriteLine("Move Not Allowed");
                if (pile1Picked)
                    pile1 = pile1 + pick;
                if (pile2Picked)
                    pile2 = pile2 + pick;
                if (pile3Picked)
                    pile3 = pile3 + pick;
            }

            return allowedMove;
          
        }
    }
}
