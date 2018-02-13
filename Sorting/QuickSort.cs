using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    /// <summary>
    /// Description of QuickSort algorithm
    /// </summary>
    class QuickSort
    { /// <summary>
    /// Finding the pivot
    /// </summary>
    /// <param name="arr"> The array</param>
    /// <param name="low"> Starting index </param>
    /// <param name="high"> Final index </param>
    /// <returns></returns>
       public int Partition(int []arr, int low, int high)
        {
            int pivot = arr[high];
            int i = (low - 1); // index of smaller element
            for (int j = low; j < high; j++)
            {
                // If current element is smaller than or
                // equal to pivot
                if (arr[j] <= pivot)
                {
                    i++;

                    // swap arr[i] and arr[j]
                    int temp1 = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp1;
                }
            }

            // swap arr[i+1] and arr[high] (or pivot)
            int temp = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp;

            return i + 1;
        }


        /* The main function that implements QuickSort()
          arr[] --> Array to be sorted,
          low  --> Starting index,
          high  --> Ending index */
       public  int[] Sort(int []arr, int low, int high)
        {
            if (low < high)
            {
                /* pi is partitioning index, arr[pi] is 
                  now at right place */
                int pi = Partition(arr, low, high);

                // Recursively sort elements before
                // partition and after partition
                Sort(arr, low, pi - 1);
                Sort(arr, pi + 1, high);
            } return arr;
        }
    }
}
