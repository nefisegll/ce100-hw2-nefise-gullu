using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce100_hw2_algo_lib_cs
{
    public class HeapSortAlgorithm
    {
        /// <summary>
        /// Sorts an array of integers using the Heap Sort algorithm.
        /// </summary>
        /// <param name="inputArray">The input integer array to be sorted.</param>
        /// <param name="outputArray">Output integer array will contain sorted items.</param>
        /// <param name="enableDebug">If true, debug info will be printed to the console.</param>
        /// <returns>Returns 0 upon sorting is completed successfully.</returns>
        public static int HeapSort(int[] inputArray, ref int[] outputArray, bool enableDebug = false)
        {
            // Get the length of the input array.
            int n = inputArray.Length;

           // Create a new array of length n + 1 to be used as the heap.
            int[] heapArray = new int[n + 1];

            // Fill the heap array with elements from input array.
            for (int i = 0; i < n; i++)
            {
                heapArray[i + 1] = inputArray[i];
                if (enableDebug)
                {
                    Console.WriteLine("Inserted element " + heapArray[i + 1] + " into heap");
                }
            }

            // Create a max heap from the heap array.
            for (int i = n / 2; i >= 1; i--)
            {
                MaxHeapify(heapArray, i, n, enableDebug);
            }

            //Extract the maximum element from the heap and put it into output array till heap is empty.
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

            // Return 0 after the sorting completes successfully.
            return 0;
        }

        /// <summary>
        /// Persists the max-heap property of the input array.
        /// </summary>
        /// <param name="arr">The input integer array which needs to persist the max-heap property.</param>
        /// <param name="i">The root index of the subtree.</param>
        /// <param name="n">The size of the heap.</param>
        /// <param name="enableDebug">If true, debug info will be printed to the console.</param>
        private static void MaxHeapify(int[] arr, int i, int n, bool enableDebug)
        {
     
            // Consider the root node as the largest.
            int largest = i;

            // Calculate indices of left and right child nodes.
            int left = 2 * i;
            int right = 2 * i + 1;

            // If left child is larger than root, mark it as largest.
            if (left <= n && arr[left] > arr[largest])
            {
                largest = left;
            }

            // If right child is larger than root, mark it as largest.
            if (right <= n && arr[right] > arr[largest])
            {
                largest = right;
            }

            // In case the largest node is the root node or not swap them and persist the max-heap property.
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

    public class MatrixChainMultiplicationDP
    {
        public static int Mcmdp(int[] matrixDimensionArray, ref string matrixOrder, ref int operationCount, bool enableDebug = false)
        {
            int n = matrixDimensionArray.Length - 1;
            int[,] m = new int[n, n];
            int[,] s = new int[n, n];

            for (int len = 2; len <= n; len++)
            {
                for (int i = 0; i <= n - len; i++)
                {
                    int j = i + len - 1;
                    m[i, j] = int.MaxValue;

                    for (int k = i; k < j; k++)
                    {
                        int cost = m[i, k] + m[k + 1, j] + matrixDimensionArray[i] * matrixDimensionArray[k + 1] * matrixDimensionArray[j + 1];

                        if (cost < m[i, j])
                        {
                            m[i, j] = cost;
                            s[i, j] = k;
                        }

                        if (enableDebug)
                        {
                            Console.WriteLine($"M[{i},{j}] = {m[i, j]}");
                        }

                        operationCount++;
                    }
                }
            }

            matrixOrder = BuildMatrixOrder(s, 0, n - 1);
            operationCount += n - 1;

            return m[0, n - 1];
        }

        public static string BuildMatrixOrder(int[,] s, int i, int j)
        {
            if (i == j)
            {
                return $"A{i + 1}";
            }
            else
            {
                return $"({BuildMatrixOrder(s, i, s[i, j])} {BuildMatrixOrder(s, s[i, j] + 1, j)})";
            }
        }
    }

    public class MatrixChainMultiplicationMemorizedRec
    {
        public static int mcmrem(int[] matrixDimensionArray, ref string matrixOrder, ref int operationCount)
        {
            int n = matrixDimensionArray.Length - 1;
            int[,] S = new int[n + 1, n + 1];
            int[,] M = new int[n + 1, n + 1];
            for (int i = 1; i <= n; i++)
            {
                M[i, i] = 0;
            }

            mcmremHelper(matrixDimensionArray, S, M, 1, n);

            operationCount = M[1, n];
            matrixOrder = parenthesize(S, 1, n);

            if (operationCount == 0)
            {
                return -1; // failed
            }
            return 0; // succeed
        }

        public static int mcmremHelper(int[] p, int[,] S, int[,] M, int i, int j)
        {
            if (M[i, j] > 0)
            {
                return M[i, j];
            }

            if (i == j)
            {
                return 0;
            }

            int minCount = int.MaxValue;
            int minK = -1;
            for (int k = i; k < j; k++)
            {
                int leftCount = mcmremHelper(p, S, M, i, k);
                int rightCount = mcmremHelper(p, S, M, k + 1, j);
                int count = leftCount + rightCount + p[i - 1] * p[k] * p[j];
                if (count < minCount)
                {
                    minCount = count;
                    minK = k;
                }
            }

            M[i, j] = minCount;
            S[i, j] = minK;

            return minCount;
        }

        public static string parenthesize(int[,] S, int i, int j)
        {
            if (i == j)
            {
                return "A" + i;
            }

            int k = S[i, j];
            string left = parenthesize(S, i, k);
            string right = parenthesize(S, k + 1, j);

            return "(" + left + "." + right + ")";
        }

    }
    public class LongestCommonSubsequence
    {
        public static int Lcs(string inputArray1, string inputArray2, out string outputLcs, out int outputLcslength, bool enableDebug = false)
        {
            int m = inputArray1.Length;
            int n = inputArray2.Length;
            int[,] lcsArray = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        lcsArray[i, j] = 0;
                    }
                    else if (inputArray1[i - 1] == inputArray2[j - 1])
                    {
                        lcsArray[i, j] = lcsArray[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        lcsArray[i, j] = Math.Max(lcsArray[i - 1, j], lcsArray[i, j - 1]);
                    }
                }
            }

            outputLcslength = lcsArray[m, n];
            outputLcs = "";
            int index = outputLcslength;
            int k = m, l = n;
            while (k > 0 && l > 0)
            {
                if (inputArray1[k - 1] == inputArray2[l - 1])
                {
                    outputLcs += inputArray1[k - 1];
                    k--;
                    l--;
                    index--;
                }
                else if (lcsArray[k - 1, l] > lcsArray[k, l - 1])
                {
                    k--;
                }
                else
                {
                    l--;
                }
            }
            outputLcs = new string(outputLcs.Reverse().ToArray());

            if (enableDebug)
            {
                Console.WriteLine($"LCS Length: {outputLcslength}");
                Console.WriteLine($"LCS String: {outputLcs}");
            }

            return 0;
        }
    }
    public class TheKnapsackProblem
    {
        public static int Knapsackdp(int[] Weights, int[] Values, ref int[] SelectedIndices, ref int maxBenefit, bool enableDebug = false)
        {
            int n = Weights.Length;
            int W = maxBenefit;

            // Create a table to store sub-problems
            int[,] K = new int[n + 1, W + 1];

            // Build table K[][] in bottom up manner
            for (int i = 0; i <= n; i++)
            {
                for (int w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                    {
                        K[i, w] = 0;
                    }
                    else if (Weights[i - 1] <= w)
                    {
                        K[i, w] = Math.Max(Values[i - 1] + K[i - 1, w - Weights[i - 1]], K[i - 1, w]);
                    }
                    else
                    {
                        K[i, w] = K[i - 1, w];
                    }
                }
            }

            // Get the maximum benefit
            maxBenefit = K[n, W];

            // Backtrack to find selected items
            int j = W;
            for (int i = n; i > 0 && maxBenefit > 0; i--)
            {
                if (maxBenefit == K[i - 1, j])
                {
                    continue;
                }
                else
                {
                    // Add the index of selected item to the output array
                    SelectedIndices[i - 1] = i - 1;

                    // Subtract weight and benefit of selected item
                    maxBenefit -= Values[i - 1];
                    j -= Weights[i - 1];
                }
            }

            // If debug mode is enabled, print the table K[][]
            if (enableDebug)
            {
                for (int i = 0; i <= n; i++)
                {
                    for (int w = 0; w <= W; w++)
                    {
                        Console.Write(K[i, w] + " ");
                    }
                    Console.WriteLine("");
                }
            }

            return 0;
        }
    }
}
