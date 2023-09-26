namespace Unit_Testing_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrixA = { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] matrixB = { { 2, 3, 4 }, { 2, 3, 4 } };
            int[,] matrixC = MatrixOperations.Add(matrixA, matrixB);
            int[,] matrixD = MatrixOperations.Subtract(matrixA, matrixB);

            foreach (int x in matrixC)
            {
                Console.WriteLine(x);

            }
            foreach (int x in matrixD)
            {
                Console.WriteLine(x);
            }
        }
    }
}