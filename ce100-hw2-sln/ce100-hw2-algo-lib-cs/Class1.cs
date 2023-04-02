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

}
