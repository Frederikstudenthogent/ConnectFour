using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    public class Board
    {
        public int NumberOfRows { get; } = 6;
        public int NumberOfColumns { get; } = 7;

        public List<string> row6 = new();
        public List<string> row5 = new();
        public List<string> row4 = new();
        public List<string> row3 = new();
        public List<string> row2 = new();
        public List<string> row1 = new();

        public void FillBoard(int numberOfColumns)
        {
            for (int i = 0; i < numberOfColumns; i++)
            {
                row1.Add("0");
                row2.Add("0");
                row3.Add("0");
                row4.Add("0");
                row5.Add("0");
                row6.Add("0");
            }            
        }

        public void PrintBoard(int numberOfRows)
        {
            Console.WriteLine("Current state of the board: ");
            for (int i = 0; i < row6.Count(); i++)
            {
                if (row6[i] == "H")
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (row6[i] == "C")
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                else
                    Console.ForegroundColor = ConsoleColor.White;
                Console.Write(row6[i]);             
            }

            Console.WriteLine();

            for (int i = 0; i < row5.Count(); i++)
            {
                if (row5[i] == "H")
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (row5[i] == "C")
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                else
                    Console.ForegroundColor = ConsoleColor.White;
                Console.Write(row5[i]);
            }

            Console.WriteLine();

            for (int i = 0; i < row4.Count(); i++)
            {
                if (row4[i] == "H")
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (row4[i] == "C")
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                else
                    Console.ForegroundColor = ConsoleColor.White;
                Console.Write(row4[i]);
            }

            Console.WriteLine();

            for (int i = 0; i < row3.Count(); i++)
            {
                if (row3[i] == "H")
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (row3[i] == "C")
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                else
                    Console.ForegroundColor = ConsoleColor.White;
                Console.Write(row3[i]);
            }

            Console.WriteLine();

            for (int i = 0; i < row2.Count(); i++)
            {
                if (row2[i] == "H")
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (row2[i] == "C")
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                else
                    Console.ForegroundColor = ConsoleColor.White;
                Console.Write(row2[i]);
            }

            Console.WriteLine();

            for (int i = 0; i < row1.Count(); i++)
            {
                if (row1[i] == "H")
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (row1[i] == "C")
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                else
                    Console.ForegroundColor = ConsoleColor.White;
                Console.Write(row1[i]);
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public void UpdateBoard(int move, Board board, bool humanMove)
        {
            int moveMinus1 = move - 1;            
            if (humanMove)
            {
                if (board.row1[moveMinus1] == "0")
                {                    
                    board.row1[moveMinus1] = "H";
                }
                else if (board.row2[moveMinus1] == "0")
                {
                    board.row2[moveMinus1] = "H";
                }
                else if (board.row3[moveMinus1] == "0")
                {
                    board.row3[moveMinus1] = "H";
                }
                else if (board.row4[moveMinus1] == "0")
                {
                    board.row4[moveMinus1] = "H";
                }
                else if (board.row5[moveMinus1] == "0")
                {
                    board.row5[moveMinus1] = "H";
                }
                else 
                {
                    board.row6[moveMinus1] = "H";
                }
            }
            else
            {
                if (board.row1[moveMinus1] == "0")
                {
                    board.row1[moveMinus1] = "C";
                }
                else if (board.row2[moveMinus1] == "0")
                {
                    board.row2[moveMinus1] = "C";
                }
                else if (board.row3[moveMinus1] == "0")
                {
                    board.row3[moveMinus1] = "C";
                }
                else if (board.row4[moveMinus1] == "0")
                {
                    board.row4[moveMinus1] = "C";
                }
                else if (board.row5[moveMinus1] == "0")
                {
                    board.row5[moveMinus1] = "C";
                }
                else
                {
                    board.row6[moveMinus1] = "C";
                }
            }
            
        }

    }

    
}
