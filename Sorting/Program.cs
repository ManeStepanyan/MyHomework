using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{/// <summary>
/// Sorting an array in ascending order by chosen algorithm
/// Where Algorithm N1 is Insertion Sort, N2 is Bubble Sort, N3 is Quick Sort
/// N4 is HeapSort and N5 is MergeSort
/// </summary>
    class Program
    {/// <summary>
    /// 
    /// </summary>
    /// <param name="arr"> Array which elements we want to be printed out on screen </param>
    /// <param name="n"> Size of our array </param>
        static void PrintArray(int[] arr, int n)
        {
            for (int i = 0; i < n - 1; i++)
            Console.Write(arr[i] + "," + " ");
            Console.Write(arr[n - 1]);
            Console.WriteLine();
        } /// <summary>
        /// Choosing an algorithm or algorithms to sort our array
        /// </summary>
        /// <param name="number"> The number of preffered algorithm </param>
        /// <param name="arr"> Array to be sorted </param>
        /// <param name="n"> Size of the array </param>
        /// <returns> Sorted Array by chosen algorithm </returns>
        static int[] ChooseAlgorithm(int number, int[] arr, int n)
        {
            if (number == 1)
            {
                InsertionSort i = new InsertionSort(); // Creating an instance of InsertionSort class for applying it's Sort method
                return i.Sort(arr, n); // Returning our array sorted by InsertionSort algorithm  
            }
            if (number == 2)
            {
                BubbleSort b = new BubbleSort(); // Creating an instance of BubbleSort class for applying it's Sort method
                return b.Sort(arr, n); //Returning our sorted array by BubbleSort algorithm  
            }
            if (number == 3)
            {
                QuickSort q = new QuickSort(); // Creating an instance of QuickSort class for applying it's Sort method
                return q.Sort(arr, 0, n - 1); //Returning our sorted array by QuickSort algorithm
            }
            if (number == 4)
            {
                HeapSort h = new HeapSort(); // Creating an instance of HeapSort class for applying it's Sort method
                return h.Sort(arr, n); // Returning our sorted array by HeapSort algorithm
            }
            if (number == 5)
            {
                MergeSort m = new MergeSort(); // Creating an instance of MergeSort class for applying it's Sort method
                return m.Sort(arr, 0, n - 1); // Returning our sorted array by HeapSort algorithm
            }
            else throw new Exception("Out of range"); // If number doesn't correspond to any of the algorithm numbers, throw an exception
            }
            static void Main(string[] args)
        {
            Console.WriteLine("Enter size of an array:  ");
            int n = Int32.Parse(Console.ReadLine()); //Converts the string representation of a number to its 32-bit signed integer equivalent.
            Random random = new Random();
            int[] arr = new int[n]; // Creating an array to be sorted
            int[] tempArr = new int[n]; // Array to hold the copy of arr
            tempArr = arr;
            for (int i = 0; i < n; i++)
            {
                arr[i] = random.Next(); //Initializing to our arr array random numbers
            }
            Console.WriteLine("Your random array is");
            PrintArray(arr, n);
            /// In Case of 1,2 algorithm N1 and N2 have to be applied. In case of 1-3, algorithm N1, N2, N3 and etc.
            Console.WriteLine("Choose the algorithm you want to apply ");
            string s = Console.ReadLine();
            List<int> list = new List<int>(); // List for holding the number of algorithms given by the user
            if (s.Contains(','))
            {
                list = s.Split(',').Select(int.Parse).ToList();  // Adding numbers separated by ',' to list
            }
            else if (s.Contains('-'))
            {
                
               var temp = s.Split('-').Select(int.Parse);
               for (int i = temp.First(); i <= temp.Last(); i++) // E.g. for 1-3 we'll have 1, 2, 3
                {

                    list.Add(i);
                }
            }
            else list.Add(int.Parse(s)); // For one number, just add it
            int k = 0; // Temporary variable for holding the index of current element in list
            long min = 0; // Variable for holding the fastest running time in miliseconds
            List<long> tempList = new List<long>(); // List for running time of every algorithm
            while (k < list.Count)
            {
                tempArr = arr; //passing copy of the array for each class's sort function every time when loop has started
                int j = list[k]; // j holds current element of list
                k++;
                var sw = new Stopwatch(); // calculating the running time
                sw.Start();
                ChooseAlgorithm(j, tempArr, n); // Finally applying the algorithm needed
                sw.Stop(); 
                tempList.Add(sw.ElapsedMilliseconds); //tempList contains running times of choses algorithms
                for (int i = 0; i < tempList.Count; i++) // Finding the fastest algorithm
                {
                    if (tempList[i] < min)
                        min = tempList[i];
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                

                    Console.WriteLine("Running time of algorithm number  " + list[i] + " in milliseconds is " + tempList[i]);
                    if(list[i]!=5)// Not merge sort
                    Console.WriteLine("Used memory is " + n*4  + "byte"); // Space Complexity
                    // Attention!! Local variables are not included in this calculation
                    else Console.WriteLine("Used memory is " + 2 * n * 4 + "byte"); // As MergeSort used additional memory space 
                    Console.WriteLine("Result is");
                if (tempList[i] == min) // In case of the Fastest Running Algorithm print array in green color
                {

                    Console.ForegroundColor = ConsoleColor.Green;
                    PrintArray(arr, n);
                    Console.ResetColor();
                }

                else
                {
              
                    PrintArray(arr, n);
                }
            }


        }
    }
}




