using ce100_hw2_algo_lib_cs;

namespace ce100_hw2_algo_test_cs
{
    [TestClass]
    public class HeapSortAlgorithmTests
    {
        [TestMethod]
        public void TestHeapSortWithBestCaseInput()
        {
            // Arrange
            int[] inputArray = { 1, 2, 3, 4, 5 };
            int[] expectedOutput = { 1, 2, 3, 4, 5 };
            int[] outputArray = new int[inputArray.Length];

            // Act
            int result = HeapSortAlgorithm.HeapSort(inputArray, ref outputArray, enableDebug: false);

            // Assert
            Assert.AreEqual(0, result);
            CollectionAssert.AreEqual(expectedOutput, outputArray);
        }

        [TestMethod]
        public void TestHeapSortWithWorstCaseInput()
        {
            // Arrange
            int[] inputArray = { 5, 4, 3, 2, 1 };
            int[] expectedOutput = { 1, 2, 3, 4, 5 };
            int[] outputArray = new int[inputArray.Length];

            // Act
            int result = HeapSortAlgorithm.HeapSort(inputArray, ref outputArray, enableDebug: false);

            // Assert
            Assert.AreEqual(0, result);
            CollectionAssert.AreEqual(expectedOutput, outputArray);
        }

        [TestMethod]
        public void TestHeapSortWithAverageCaseInput()
        {
            // Arrange
            int[] inputArray = { 3, 5, 2, 1, 4 };
            int[] expectedOutput = { 1, 2, 3, 4, 5 };
            int[] outputArray = new int[inputArray.Length];

            // Act
            int result = HeapSortAlgorithm.HeapSort(inputArray, ref outputArray, enableDebug: false);

            // Assert
            Assert.AreEqual(0, result);
            CollectionAssert.AreEqual(expectedOutput, outputArray);
        }
    }

    [TestClass]
    public class MatrixChainMultiplicationDPTests
    {
        [TestMethod]
        public void TestMatrixChainMultiplicationDP_BestCase()
        {
            int[] matrixDimensionArray = new int[] { 30, 35, 15, 5, 10, 20, 25 };
            string expectedMatrixOrder = "((A1 (A2 A3)) ((A4 A5) A6))";
            int expectedOperationCount = 40;

            string matrixOrder = "";
            int operationCount = 0;
            int result = MatrixChainMultiplicationDP.Mcmdp(matrixDimensionArray, ref matrixOrder, ref operationCount);

            Assert.AreEqual(expectedMatrixOrder, matrixOrder);
            Assert.AreEqual(expectedOperationCount, operationCount);
            Assert.AreEqual(15125, result);
        }

        [TestMethod]
        public void TestMatrixChainMultiplicationDP_WorstCase()
        {
            int[] matrixDimensionArray = new int[] { 10, 20, 30, 40, 50 };
            string expectedMatrixOrder = "(((A1 A2) A3) A4)";
            int expectedOperationCount = 13;

            string matrixOrder = "";
            int operationCount = 0;
            int result = MatrixChainMultiplicationDP.Mcmdp(matrixDimensionArray, ref matrixOrder, ref operationCount);

            Assert.AreEqual(expectedMatrixOrder, matrixOrder);
            Assert.AreEqual(expectedOperationCount, operationCount);
            Assert.AreEqual(38000, result);
        }

        [TestMethod]
        public void TestMatrixChainMultiplicationDP_AverageCase()
        {
            int[] matrixDimensionArray = new int[] { 5, 10, 3, 12, 5, 50 };
            string expectedMatrixOrder = "(((A1 A2) (A3 A4)) A5)";
            int expectedOperationCount = 24;

            string matrixOrder = "";
            int operationCount = 0;
            int result = MatrixChainMultiplicationDP.Mcmdp(matrixDimensionArray, ref matrixOrder, ref operationCount);

            Assert.AreEqual(expectedMatrixOrder, matrixOrder);
            Assert.AreEqual(expectedOperationCount, operationCount);
            Assert.AreEqual(1655, result);
        }
    }

    [TestClass]
    public class MatrixChainMultiplicationMemorizedRecTests
    {
        [TestMethod]
        public void TestMCMRemBestCase()
        {
            // Arrange
            int[] matrixDimensionArray = { 30, 35, 15, 5, 10, 20, 25 };
            int operationCount = 0;
            string matrixOrder = null;

            // Act
            int result = MatrixChainMultiplicationMemorizedRec.mcmrem(matrixDimensionArray, ref matrixOrder, ref operationCount);

            // Assert
            Assert.AreEqual(0, result);
            Assert.AreEqual("((A1.(A2.A3)).((A4.A5).A6))", matrixOrder);
            Assert.AreEqual(15125, operationCount);
        }

        [TestMethod]
        public void TestMCMRemWorstCase()
        {
            // Arrange
            int[] matrixDimensionArray = { 10, 20, 30, 40, 50, 60 };
            int operationCount = 0;
            string matrixOrder = null;

            // Act
            int result = MatrixChainMultiplicationMemorizedRec.mcmrem(matrixDimensionArray, ref matrixOrder, ref operationCount);

            // Assert
            Assert.AreEqual(0, result);
            Assert.AreEqual("((((A1.A2).A3).A4).A5)", matrixOrder);
            Assert.AreEqual(68000, operationCount);
        }

        [TestMethod]
        public void TestMCMRemAverageCase()
        {
            // Arrange
            int[] matrixDimensionArray = { 20, 30, 40, 10, 5, 30 };
            int operationCount = 0;
            string matrixOrder = null;

            // Act
            int result = MatrixChainMultiplicationMemorizedRec.mcmrem(matrixDimensionArray, ref matrixOrder, ref operationCount);

            // Assert
            Assert.AreEqual(0, result);
            Assert.AreEqual("((A1.(A2.(A3.A4))).A5)", matrixOrder);
            Assert.AreEqual(14000, operationCount);
        }
    }

    [TestClass]
    public class LongestCommonSubsequenceTests
    {
        [TestMethod]
        public void Lcs_BestCase_ShouldReturnExpectedResult()
        {
            string inputArray1 = "abcd";
            string inputArray2 = "abcd";
            string expectedOutputLcs = "abcd";
            int expectedOutputLcslength = 4;

            string outputLcs;
            int outputLcslength;
            int result = LongestCommonSubsequence.Lcs(inputArray1, inputArray2, out outputLcs, out outputLcslength);

            Assert.AreEqual(expectedOutputLcslength, outputLcslength);
            Assert.AreEqual(expectedOutputLcs, outputLcs);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Lcs_WorstCase_ShouldReturnExpectedResult()
        {
            string inputArray1 = "a";
            string inputArray2 = "b";
            string expectedOutputLcs = "";
            int expectedOutputLcslength = 0;

            string outputLcs;
            int outputLcslength;
            int result = LongestCommonSubsequence.Lcs(inputArray1, inputArray2, out outputLcs, out outputLcslength);

            Assert.AreEqual(expectedOutputLcslength, outputLcslength);
            Assert.AreEqual(expectedOutputLcs, outputLcs);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Lcs_AverageCase_ShouldReturnExpectedResult()
        {
            string inputArray1 = "AGGTAB";
            string inputArray2 = "GXTXAYB";
            string expectedOutputLcs = "GTAB";
            int expectedOutputLcslength = 4;

            string outputLcs;
            int outputLcslength;
            int result = LongestCommonSubsequence.Lcs(inputArray1, inputArray2, out outputLcs, out outputLcslength);

            Assert.AreEqual(expectedOutputLcslength, outputLcslength);
            Assert.AreEqual(expectedOutputLcs, outputLcs);
            Assert.AreEqual(0, result);
        }
    }



}









