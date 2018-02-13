using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{ /// <summary>
/// Description of MergeSort algorithm
/// </summary>
    class MergeSort
    {  // Merges two subarrays of arr[].
       // First subarray is arr[l..m]
       // Second subarray is arr[m+1..r]
      public void Merge(int []arr, int l, int m, int r)
        {
            // Find sizes of two subarrays to be merged
            int n1 = m - l + 1;
            int n2 = r - m;

            /* Create temp arrays */
            int []L = new int[n1];
            int []R = new int[n2];

            /*Copy data to temp arrays*/
            for (int t = 0; t < n1; ++t)
                L[t] = arr[l + t];
            for (int s = 0; s < n2; ++s)
                R[s] = arr[m + 1 + s];


            /* Merge the temp arrays */

            // Initial indexes of first and second subarrays
            int i = 0, j = 0;

            // Initial index of merged subarry array
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            /* Copy remaining elements of L[] if any */
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            /* Copy remaining elements of R[] if any */
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        // Main function that sorts arr[l..r] using
        // merge()
      public  int[] Sort(int []arr, int l, int r)
        {
            if (l < r)
            {
                // Find the middle point
                int m = (l + r) / 2;

                // Sort first and second halves
                Sort(arr, l, m);
                Sort(arr, m + 1, r);

                // Merge the sorted halves
                Merge(arr, l, m, r);
            } return arr;
        }
    }
}
