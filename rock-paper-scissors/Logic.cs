using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace rock_paper_scissors
{
    class Logic
    {
        public static string cpumove = string.Empty; // randomly made CPU move
        public static List<string> moves = new List<string>();
        
        public int indexOfCpuMove; // index of CPU selected move in "Moves List"
        public int indexOfUserMove; // index of User selected move in "Moves List"
        
        public static string cpuMakeMove() // random CPU move
        {
            Random r = new Random();
            int index = r.Next(0 , moves.Count);
            cpumove = moves[index];
            return cpumove;
        }
        
        public static string DoMath(int _indexOfCpuMove, int _indexOfUserMove)
        {
            int winningRange = (moves.Count-1) / 2; // "range" of win\lose moves
            int startPosition = _indexOfUserMove + 1;
            int endPosition = Math.Abs(moves.Count - (startPosition + winningRange));
            if (_indexOfCpuMove == _indexOfUserMove)
            {
                return "DRAW";
            }
            bool isInRange = moves.Count - (startPosition + winningRange) < 0 ? false : true;
            if (isInRange)
            {
                for (int i = startPosition; i <= _indexOfUserMove + winningRange; i++)
                {
                    if (i == _indexOfCpuMove)
                    {
                        return "WIN!";
                    }
                }
                return "LOOSE!";
            }
            else
            {
                for(int i = startPosition; i <= moves.Count-1; i++)
                {
                    if (i == _indexOfCpuMove)
                    {
                        return "WIN!";
                    }
                } 

                for (int i = 0; i < endPosition; i++)
                {
                    if (i == _indexOfCpuMove)
                    {
                        return "WIN!";
                    }
                }
                return "LOOSE!";
            }
            
        }
    }
}
