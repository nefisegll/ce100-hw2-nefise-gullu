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





}