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




}