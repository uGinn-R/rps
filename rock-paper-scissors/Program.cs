using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace rock_paper_scissors
{
    class Program
    {
        public static Logic logic = new Logic();
        static void Main(string[] args)
        {
            bool ArgsHasDuplicates = args.GroupBy(n => n).Any(c => c.Count() > 1); // TRUE if args has duplicates
            bool argsAreOdd(string[] args) { return (args.Length % 2 == 0) ? false : true; }  // TRUE if number of arguments is Odd

            if (args.Length < 3)
            {
                string error_message = $"Number of arguments can't be {args.Length}, run with minimum 3 non-repeated parameters";
                Console.WriteLine(error_message);
                return;
            }
            else
            {
                if (ArgsHasDuplicates)
                {
                    Console.WriteLine("Arguments can't be repeated, run without duplicates.");
                    return;
                }
                else if (!argsAreOdd(args))
                {
                    Console.WriteLine("Number of arguments is NOT odd, try again.");
                    return;
                }
            }

            foreach (var item in args)
            {
                Logic.moves.Add(item); // putting all User moves to List
            }

            Console.WriteLine($"HMAC: { Crypto.GetHash(Logic.cpuMakeMove()) }");

            ShowMenu();

            logic.indexOfCpuMove = Logic.moves.FindIndex(a => a.Contains(Logic.cpumove));
            
            if (Logic.moves.Count-1 < logic.indexOfUserMove || logic.indexOfUserMove < 0)
            {
                Console.WriteLine("Entered index is out of range, check list of available moves!");
                return;
            }

            Console.WriteLine($"Your move: {Logic.moves[logic.indexOfUserMove]}\nCPU move: {Logic.moves[logic.indexOfCpuMove]}");
            Console.WriteLine(Logic.DoMath(logic.indexOfCpuMove,logic.indexOfUserMove));
            Console.WriteLine($"HMAC Key: {Crypto.key}");
            Console.ReadLine();
        }
        public static void ShowMenu()
        {    
            Console.WriteLine("Available moves: \n[index] - 'move'\n");
            for (int i = 0; i < Logic.moves.Count; i++)
            {
                Console.WriteLine($"[{i}] - '{Logic.moves[i]}'"); // item
            }
            Console.WriteLine("\n'q' - quit game\n'h' - show help table\n");
            Console.WriteLine("Enter index of your move or select menu item:");
            string input = Console.ReadLine();
            try
            {
                logic.indexOfUserMove = int.Parse(input);
            }
            catch (Exception e)
            {
                if (input.Equals("q"))
                {
                    Console.WriteLine("Bye!");
                    Thread.Sleep(500);
                    Environment.Exit(0);
                }
                else if (input.Equals("h"))
                {
                    Table.ShowTable();
                    ShowMenu(); // recursion is bad...
                }
                else { Console.WriteLine($"{e.Message} (Must be an index or menu parameter from the list above)"); Environment.Exit(0); }  
            }
        }
    }
}
