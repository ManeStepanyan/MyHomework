using System;
using System.Collections.Generic;

namespace DieRolling
{
    public delegate void TwoSixes(DieArgs die1, DieArgs die2);
    public delegate void SumOfTosses(DieArgs die1, DieArgs die2, DieArgs die3, DieArgs die4, DieArgs die5);
    public class DieRoll
    {   // to hold sum of last 5 tossed dies
        public int sumOf5Tosses;
        // list for last 5 dies
        List<DieArgs> ListForSum;
        // number of times "two six in a row" appears
        public static int Count { get; private set; } = 0;
        // random object for a die value
        private readonly Random random;
        // Tossed dies
        private readonly List<DieArgs> Dies;
        // event to be triggered when two sixes in a row appear
        public event TwoSixes TwoSixesInARow;
        //event to be triggered when sum of last 5 tosses are greater than or equal to 20
        public event SumOfTosses SumOf5Tosses;
        /// <summary>
        /// Creates a new die
        /// </summary>
        public DieRoll()
        {
            random = new Random();
            Dies = new List<DieArgs>();
        }
        /// <summary>
        /// Rolling
        /// </summary>
        public void Roll()
        {
            sumOf5Tosses = 0;
            int x = random.Next(1, 7);
            DieArgs dieArgs = new DieArgs(x);
            Dies.Add(dieArgs);
            // at least two dies tossed
            if (Dies.Count > 1)
            {
                if (x == 6 && Dies[Dies.Count - 2] == dieArgs)
                {
                    Count++;
                    CallingAnEventForTwoSixes();
                }
            }
            // at least 5 dies tossed
            if (Dies.Count >= 5)
            {
                ListForSum = new List<DieArgs>();
                for (int i = 0; i < 5; i++)
                {
                    ListForSum.Add(Dies[Dies.Count - 1 - i]);
                    sumOf5Tosses += ListForSum[i].DieValue;
                }
                if (sumOf5Tosses >= 20)
                    CallingAnEventForSum();

            }
        }
        // Trigger an event when two sixes in a row appear
        public void CallingAnEventForTwoSixes()
        {
            Console.WriteLine($"Toss number {Dies.Count}");
            Console.WriteLine(new string('-', 50));
            TwoSixesInARow(Dies[Dies.Count - 2], Dies[Dies.Count - 1]);
        }
        // Trigger an event when sum of last 5 tosses is <=20
        public void CallingAnEventForSum()
        {
            Console.WriteLine($"Toss number {Dies.Count}");
            Console.WriteLine($"Sum of last 5 tosses = {sumOf5Tosses} ");
            SumOf5Tosses(ListForSum[4], ListForSum[3], ListForSum[2], ListForSum[1], ListForSum[0]);
        }

    }
}


