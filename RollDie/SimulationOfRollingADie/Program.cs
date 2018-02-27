using DieRolling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationOfRollingADie
{
    class Program
    {
        public static void TwoSixInARowHandler(DieArgs die1, DieArgs die2)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("two sixes in a row as" + " die1 is " + die1.DieValue + " and die2 is " + die2.DieValue);
            Console.ResetColor();
        }
        public static void SumOf5TossesHandler(DieArgs die1, DieArgs die2, DieArgs die3, DieArgs die4, DieArgs die5)
        {
            Console.WriteLine("Which is greater than or equal to 20");
            Console.WriteLine("die1 is:" + die1.DieValue);
            Console.WriteLine("die2 is:" + die2.DieValue);
            Console.WriteLine("die3 is:" + die3.DieValue);
            Console.WriteLine("die4 is:" + die4.DieValue);
            Console.WriteLine("die5 is:" + die5.DieValue);
        }
        static void Main(string[] args)
        {
            DieRoll diceRoll = new DieRoll();
            diceRoll.TwoSixesInARow += TwoSixInARowHandler;
            diceRoll.SumOf5Tosses += SumOf5TossesHandler;
            for (int i = 0; i < 50; i++)
            {
                diceRoll.Roll();
            }
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Count of two six in a row is equal to " + DieRoll.Count);
            Console.ResetColor();
        }
    }


}