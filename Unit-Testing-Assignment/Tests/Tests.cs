using NUnit.Framework;
using Unit_Testing_Assignment;

namespace Tests
{

    [TestFixture]
    public class MatrixOperationsTests
    {
        [Test]
        public void MatrixAddition_WhenValidInput_ReturnsCorrectResult()
        {
            int[,] matrixA = { { 1, 2 }, { 3, 4 } };
            int[,] matrixB = { { 5, 6 }, { 7, 8 } };

            int[,] result = MatrixOperations.Add(matrixA, matrixB);

            int[,] expected = { { 6, 8 }, { 10, 12 } };

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MatrixSubtraction_WhenValidInput_ReturnsCorrectResult()
        {
            int[,] matrixA = { { 1, 2 }, { 3, 4 } };
            int[,] matrixB = { { 5, 6 }, { 7, 8 } };

            int[,] result = MatrixOperations.Subtract(matrixA, matrixB);

            int[,] expected = { { -4, -4 }, { -4, -4 } };

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MatrixAddition_WhenDimensionsMismatch_ThrowsException()
        {
            int[,] matrixA = { { 1, 2 }, { 3, 4 } };
            int[,] matrixB = { { 5, 6 } };

            Assert.Throws<ArgumentException>(() => MatrixOperations.Add(matrixA, matrixB));
        }

        [Test]
        public void MatrixSubtraction_WhenDimensionsMismatch_ThrowsException()
        {
            int[,] matrixA = { { 1, 2 }, { 3, 4 } };
            int[,] matrixB = { { 5, 6 } };

            Assert.Throws<ArgumentException>(() => MatrixOperations.Subtract(matrixA, matrixB));
        }
    }
}