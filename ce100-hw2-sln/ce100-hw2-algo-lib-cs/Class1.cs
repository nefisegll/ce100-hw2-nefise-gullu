using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce100_hw2_algo_lib_cs
{
    public class HeapSortAlgorithm
    {        
        public static int HeapSort(int[] inputArray, ref int[] outputArray, bool enableDebug = false)
        {
            int n = inputArray.Length;
            int[] heapArray = new int[n + 1];
            
            for (int i = 0; i < n; i++)
            {
                heapArray[i + 1] = inputArray[i];
                if (enableDebug)
                {
                    Console.WriteLine("Inserted element " + heapArray[i + 1] + " into heap");
                }
            }
            
            for (int i = n / 2; i >= 1; i--)
            {
                MaxHeapify(heapArray, i, n, enableDebug);
            }
            
            for (int i = n; i >= 1; i--)
            {
                outputArray[i - 1] = heapArray[1];
                heapArray[1] = heapArray[i];
                if (enableDebug)
                {
                    Console.WriteLine("Extracted element " + outputArray[i - 1] + " from heap");
                }
                MaxHeapify(heapArray, 1, i - 1, enableDebug);
            }

            return 0;
        }
        
        private static void MaxHeapify(int[] arr, int i, int n, bool enableDebug)
        {
            int largest = i;
            int left = 2 * i;
            int right = 2 * i + 1;

            if (left <= n && arr[left] > arr[largest])
            {
                largest = left;
            }
            if (right <= n && arr[right] > arr[largest])
            {
                largest = right;
            }

            if (largest != i)
            {
                int temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;
                if (enableDebug)
                {
                    Console.WriteLine("Swapped elements " + arr[i] + " and " + arr[largest]);
                }
                MaxHeapify(arr, largest, n, enableDebug);
            }
        }
    }
}
