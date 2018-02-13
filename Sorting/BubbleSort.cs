using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{ /// <summary>
/// Description of BubbleSort algorithm
/// </summary>
    class BubbleSort
    { /// <summary>
      /// Method for sorting given array
      /// </summary>
      /// <param name="arr"> The array</param>
      /// <param name="n"> The size </param>
      /// <returns></returns>
        public int[] Sort(int[] arr, int n)
        {
            int temp;
            int i, j;
            for (i = 0; i < n - 1; i++)

                // Last i elements are already in place   
                for (j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                } return arr;
        }
    }
}
