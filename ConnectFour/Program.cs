using System;

namespace ConnectFour
{
    class Program
    {
        static void Main(string[] args)
        {
            string namePlayer = Welcome();            
            HumanPlayer player = new HumanPlayer(namePlayer);
            ComputerPlayer computer = new ComputerPlayer();
            ExplanationGame(namePlayer, computer.Name);
            bool playAgain = true;

            while (playAgain)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Board board = new Board();
                board.FillBoard(board.NumberOfColumns);
                board.PrintBoard(board.NumberOfRows);
                PlayGame(player, computer, board);
                playAgain = PlayAgain();
            }         
           
        }

        static string Welcome()
        {
            Console.WriteLine("Welcome to CONNECT4!");
            Console.Write("What is your name?: ");
            string namePlayer = Console.ReadLine();
            Console.WriteLine();            
            return namePlayer;
        }        
        static void ExplanationGame(string namePlayer, string nameComputer)
        {
            string isEverythingClear = "0";
            while (isEverythingClear != "1") 
            {
                Console.WriteLine($"Welcome {namePlayer}!!!");
                Console.WriteLine();
                Console.WriteLine($"You will be playing against our automated computerplayer, which we'll call {nameComputer}.");
                Console.WriteLine("Here are the rules of game:");
                Console.WriteLine();
                Console.WriteLine($"The Connect4 game will randomly choose who starts the game; either you or {nameComputer}.");                
                Console.WriteLine("Before each move, the board will be displayed, and after either you or the computer makes a move; the board" +
                    " will be updated and displayed again.");                
                Console.WriteLine("Please enter a number between 1-7 indicating where you wish to place your chip.");
                Console.WriteLine();
                Console.WriteLine("A move made by you, will be indicated by the letter 'H' (H for Human).");
                Console.WriteLine($"A move made by {nameComputer} will be indicated by the letter 'C' (C for Computer). ");
                Console.WriteLine();
                Console.Write("If everything is clear; please press 1 to start the game: ");
                isEverythingClear = Console.ReadLine();
                Console.Clear();
            }            
        }        
        static void PlayGame(HumanPlayer player, ComputerPlayer computer, Board board)
        {
            bool isThereAWinner = false;
            int wieStart = DetermineWhoStartsTheGame();
            string winnaar = "";
            bool staleMate = false;
            if (wieStart == 1)
            {
                while (!isThereAWinner && !staleMate)
                {
                    MoveHuman(board, player);
                    isThereAWinner = IsThereAWinner(board);
                    if (isThereAWinner)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(player.Name + " congratulations!!! You have beaten " + computer.Name + " !!!");
                    }

                    else if (!isThereAWinner)
                    {
                        MoveComputer(board, computer);
                        isThereAWinner = IsThereAWinner(board);
                        if (isThereAWinner)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(computer.Name + " is the winner. Better luck next time!");
                        }
                    }

                    staleMate = DetermineStaleMate(board);
                    if (staleMate)
                    {
                        Console.WriteLine("Stalemate!");
                        
                    }
                }
            }
            else
            {
                while (!isThereAWinner && !staleMate)
                {
                    MoveComputer(board, computer);
                    isThereAWinner = IsThereAWinner(board);
                    if (isThereAWinner)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(computer.Name + " is the winner. Better luck next time!");
                    }

                    else if (!isThereAWinner)
                    {
                        MoveHuman(board, player);
                        isThereAWinner = IsThereAWinner(board);
                        if (isThereAWinner)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(player.Name + " congratulations!!! You have beaten " + computer.Name + " !!!");
                        }
                    }

                    staleMate = DetermineStaleMate(board);
                    if (staleMate)
                    {
                        Console.WriteLine("Stalemate!");                        
                    }
                }
            }
            
            
        }
        static void MoveHuman(Board board, HumanPlayer player)
        {
            bool humanMove = true;
            bool moveIsCorrect = false;
            int move = 0;
            Console.ForegroundColor = ConsoleColor.White;
            while (!moveIsCorrect || move < 1 || move > 7)
            {
                Console.Write($"{player.Name}, please enter a column number for your next move (1-7): ");
                moveIsCorrect = int.TryParse(Console.ReadLine(), out move);
                bool isMovePossible = IsMovePossible(move, board);
                if (!isMovePossible)
                {
                    Console.WriteLine("Column is full. Please select a different column");
                    moveIsCorrect=false;
                }
            }  
            board.UpdateBoard(move, board, humanMove );
            board.PrintBoard(board.NumberOfRows);
        }
        static void MoveComputer (Board board, ComputerPlayer computer)
        {
            bool humanMove = false;
            Console.ForegroundColor = ConsoleColor.White;
            bool isMovePossible = false;
            int move = 0;
            while (!isMovePossible)
            {
                Random rnd = new Random();
                move = rnd.Next(1, board.NumberOfColumns + 1);
                //int move = rnd.Next(7, 8);//To test
                isMovePossible = IsMovePossible(move, board);
            }            
            Console.WriteLine($"{computer.Name} chooses column {move}.  ");
            board.UpdateBoard(move, board, humanMove);
            board.PrintBoard(board.NumberOfRows);

        }
        static bool DetermineStaleMate(Board board)
        {
            bool isStaleMate = false;   
            string woord1 = board.row1[0] + board.row1[1] + board.row1[2] + board.row1[3] + board.row1[4] + board.row1[5] + board.row1[6];
            string woord2 = board.row2[0] + board.row2[1] + board.row2[2] + board.row2[3] + board.row2[4] + board.row2[5] + board.row2[6];
            string woord3 = board.row3[0] + board.row3[1] + board.row3[2] + board.row3[3] + board.row3[4] + board.row3[5] + board.row3[6];
            string woord4 = board.row4[0] + board.row4[1] + board.row4[2] + board.row4[3] + board.row4[4] + board.row4[5] + board.row4[6];
            string woord5 = board.row5[0] + board.row5[1] + board.row5[2] + board.row5[3] + board.row5[4] + board.row5[5] + board.row5[6];
            string woord6 = board.row6[0] + board.row6[1] + board.row6[2] + board.row6[3] + board.row6[4] + board.row6[5] + board.row6[6];
            bool winnerHorizontally = WinnerHorizontally(board);
            bool winnerVertically = WinnerVertically(board);
            bool winnerDiagonallyBottemToTop = WinnerDiagonallyBottemToTop(board);
            bool winnerDiagonallyTopToBottem = WinnerDiagonallyToptoBottem(board);

            if (!woord1.Contains("0") && !woord2.Contains("0") && !woord3.Contains("0") && !woord4.Contains("0") && !woord5.Contains("0") 
                && !woord6.Contains("0") && !winnerHorizontally && !winnerVertically && !winnerDiagonallyBottemToTop && !winnerDiagonallyTopToBottem)
            {
                isStaleMate = true;
            }
            else
            {
                isStaleMate = false;
            }

            return isStaleMate;
        }
        static bool IsThereAWinner(Board board)
        {
            bool winner = false;
            if (!winner)
            {
               winner = WinnerHorizontally(board);
                if (!winner)
                {
                    winner = WinnerVertically(board);
                    if (!winner)
                    {
                        winner = WinnerDiagonallyBottemToTop(board);
                        if (!winner)
                            winner = WinnerDiagonallyToptoBottem(board);
                    }
                }
            }
            return winner;            
        }
        static bool WinnerHorizontally(Board board)
        {
            bool winner = false;
            string woord1 = board.row1[0] + board.row1[1] + board.row1[2] + board.row1[3] + board.row1[4] + board.row1[5] + board.row1[6];
            string woord2 = board.row2[0] + board.row2[1] + board.row2[2] + board.row2[3] + board.row2[4] + board.row2[5] + board.row2[6];
            string woord3 = board.row3[0] + board.row3[1] + board.row3[2] + board.row3[3] + board.row3[4] + board.row3[5] + board.row3[6];
            string woord4 = board.row4[0] + board.row4[1] + board.row4[2] + board.row4[3] + board.row4[4] + board.row4[5] + board.row4[6];
            string woord5 = board.row5[0] + board.row5[1] + board.row5[2] + board.row5[3] + board.row5[4] + board.row5[5] + board.row5[6];
            string woord6 = board.row6[0] + board.row6[1] + board.row6[2] + board.row6[3] + board.row6[4] + board.row6[5] + board.row6[6];
            if (woord1.Contains("HHHH") || woord2.Contains("HHHH") || woord3.Contains("HHHH") || woord4.Contains("HHHH") ||
                woord5.Contains("HHHH") || woord6.Contains("HHHH"))
            {
                winner = true;
            }
            else if (woord1.Contains("CCCC") || woord2.Contains("CCCC") || woord3.Contains("CCCC") || woord4.Contains("CCCC") ||
                woord5.Contains("CCCC") || woord6.Contains("CCCC"))
            {
                winner = true;
            }
            else
                winner = false;

                return winner;
        }
        static bool WinnerVertically(Board board)
        {
            bool winner = false;
            string woord1 = board.row1[0] + board.row2[0] + board.row3[0] + board.row4[0] + board.row5[0] + board.row6[0];
            string woord2 = board.row1[1] + board.row2[1] + board.row3[1] + board.row4[1] + board.row5[1] + board.row6[1];
            string woord3 = board.row1[2] + board.row2[2] + board.row3[2] + board.row4[2] + board.row5[2] + board.row6[2];
            string woord4 = board.row1[3] + board.row2[3] + board.row3[3] + board.row4[3] + board.row5[3] + board.row6[3];
            string woord5 = board.row1[4] + board.row2[4] + board.row3[4] + board.row4[4] + board.row5[4] + board.row6[4];
            string woord6 = board.row1[5] + board.row2[5] + board.row3[5] + board.row4[5] + board.row5[5] + board.row6[5];
            string woord7 = board.row1[6] + board.row2[6] + board.row3[6] + board.row4[6] + board.row5[6] + board.row6[6];

            if (woord1.Contains("HHHH") || woord2.Contains("HHHH") || woord3.Contains("HHHH") || woord4.Contains("HHHH") ||
                woord5.Contains("HHHH") || woord6.Contains("HHHH") || woord7.Contains("HHHH")) 
            {
                winner = true;
            }
            else if (woord1.Contains("CCCC") || woord2.Contains("CCCC") || woord3.Contains("CCCC") || woord4.Contains("CCCC") ||
                woord5.Contains("CCCC") || woord6.Contains("CCCC") || woord7.Contains("CCCC"))
            {
                winner |= true;
            }
            else
                winner = false;

            return winner;
        }
        static bool WinnerDiagonallyBottemToTop(Board board)
        {
            bool winner = false;
            string woord1 = board.row3[0] + board.row4[1] + board.row5[2] + board.row6[3];
            string woord2 = board.row2[0] + board.row3[1] + board.row4[2] + board.row5[3] + board.row6[4];
            string woord3 = board.row1[0] + board.row2[1] + board.row3[2] + board.row4[3] + board.row5[4] + board.row6[5];
            string woord4 = board.row1[1] + board.row2[2] + board.row3[3] + board.row4[4] + board.row5[5] + board.row6[6];
            string woord5 = board.row1[2] + board.row2[3] + board.row3[4] + board.row4[5] + board.row5[6];
            string woord6 = board.row1[3] + board.row2[4] + board.row3[5] + board.row4[6];

            if (woord1.Contains("HHHH") || woord2.Contains("HHHH") || woord3.Contains("HHHH") || woord4.Contains("HHHH") ||
               woord5.Contains("HHHH") || woord6.Contains("HHHH"))
            {
                winner = true;
            }
            else if (woord1.Contains("CCCC") || woord2.Contains("CCCC") || woord3.Contains("CCCC") || woord4.Contains("CCCC") ||
                woord5.Contains("CCCC") || woord6.Contains("CCCC"))
            {
                winner |= true;
            }
            else
                winner = false;

            return winner;
        }
        static bool WinnerDiagonallyToptoBottem(Board board)
        {
            bool winner = false;
            string woord1 = board.row6[3] + board.row5[4] + board.row4[5] + board.row3[6];
            string woord2 = board.row6[2] + board.row5[3] + board.row4[4] + board.row3[5] + board.row2[6];
            string woord3 = board.row6[1] + board.row5[2] + board.row4[3] + board.row3[4] + board.row2[5] + board.row1[6];
            string woord4 = board.row6[0] + board.row5[1] + board.row4[2] + board.row3[3] + board.row2[4] + board.row1[5];
            string woord5 = board.row5[0] + board.row4[1] + board.row3[2] + board.row2[3] + board.row1[4];
            string woord6 = board.row4[0] + board.row3[1] + board.row2[2] + board.row3[3];

            if (woord1.Contains("HHHH") || woord2.Contains("HHHH") || woord3.Contains("HHHH") || woord4.Contains("HHHH") ||
              woord5.Contains("HHHH") || woord6.Contains("HHHH"))
            {
                winner = true;
            }
            else if (woord1.Contains("CCCC") || woord2.Contains("CCCC") || woord3.Contains("CCCC") || woord4.Contains("CCCC") ||
                woord5.Contains("CCCC") || woord6.Contains("CCCC"))
            {
                winner |= true;
            }
            else
                winner = false;
            return winner;
        }
        static int DetermineWhoStartsTheGame()
        {
            Random rnd = new Random();
            int getal = rnd.Next(1, 3);
            return getal;
        }
        static bool IsMovePossible(int move, Board board)
        {
            int moveMinusOne = move - 1;
            if (board.row6[moveMinusOne] == "0" )
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        static bool PlayAgain()
        {
            bool choice = false;
            bool inputCorrect = false;
            while (!inputCorrect)
            {
                Console.WriteLine("Do you want to play one more time? Enter 'Y' for yes - or 'N' for no: ");
                string playAgain = Console.ReadLine().ToLower().Trim();
                if (playAgain == "y")
                {
                    choice = true;
                    inputCorrect = true;
                }
                    
                else if (playAgain == "n")
                {
                    choice = false;
                    inputCorrect = true;
                }
                else
                    inputCorrect = false;     
            }
            

            return choice;
        }

        







    }
}
