using System;
using System.Collections.Generic;
using System.Text;

namespace rock_paper_scissors
{
    class Table
    {
        public static string[,] MovesTable = new string[Logic.moves.Count+1, Logic.moves.Count+1];
        public static void ShowTable()
        {
            for (int i = 1; i < Logic.moves.Count + 1; i++)
            {
                MovesTable[0, i] = Logic.moves[i - 1];
                for (int j = 1; j < Logic.moves.Count + 1; j++)
                {
                    MovesTable[j, 0] = Logic.moves[j - 1];
                    MovesTable[i, j] = Logic.DoMath(j - 1, i - 1);
                }
            }
            Console.WriteLine("TABLE OF POSSIBLE MOVES:\n");
            for (int i = 0; i < MovesTable.GetLength(0); i++)
            {
                for (int j = 0; j < MovesTable.GetLength(1); j++)
                {
                    Console.Write(MovesTable[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}
