// --- Task ---
// Given an array of numbers. Print all the pairs (2) of numbers in the array if the sum of those numbers is also present in the array.
// Input
// int a[] = {10, 5, 2, 7, 7, 49}
// Output (5,2)

using System;

 public class Test
{
    static void Main()
    {
        // First test run, with provided array
        var TestList1 = new TestList();
        var start = new DateTime();

        start = DateTime.Now;
        System.Console.WriteLine("Pairs: {0}",TestList.Pass1(TestList1.TestArray, true));
        System.Console.WriteLine("Time: {0}", DateTime.Now.Subtract(start).TotalSeconds);
        System.Console.WriteLine();

        start = DateTime.Now;
        System.Console.WriteLine("Pairs: {0}",TestList.Pass2(TestList1.TestArray, true));
        System.Console.WriteLine("Time: {0}", DateTime.Now.Subtract(start).TotalSeconds);
        System.Console.WriteLine();

        start = DateTime.Now;
        System.Console.WriteLine("Pairs: {0}",TestList.Pass3(TestList1.TestArray, true));
        System.Console.WriteLine("Time: {0}", DateTime.Now.Subtract(start).TotalSeconds);
        System.Console.WriteLine();

        start = DateTime.Now;
        System.Console.WriteLine("Pairs: {0}",TestList.Pass4(TestList1.TestArray, true));
        System.Console.WriteLine("Time: {0}", DateTime.Now.Subtract(start).TotalSeconds);
        System.Console.WriteLine();

        // Second test run, with random larger array
        var TestList2 = new TestList(100, 1, 1000);
        TestList2.PrintList();

        start = DateTime.Now;
        System.Console.WriteLine("Pairs: {0}",TestList.Pass1(TestList2.TestArray, false));
        System.Console.WriteLine("Time: {0}", DateTime.Now.Subtract(start).TotalSeconds);
        System.Console.WriteLine();

        start = DateTime.Now;
        System.Console.WriteLine("Pairs: {0}",TestList.Pass2(TestList2.TestArray, false));
        System.Console.WriteLine("Time: {0}", DateTime.Now.Subtract(start).TotalSeconds);
        System.Console.WriteLine();

        start = DateTime.Now;
        System.Console.WriteLine("Pairs: {0}",TestList.Pass3(TestList2.TestArray, false));
        System.Console.WriteLine("Time: {0}", DateTime.Now.Subtract(start).TotalSeconds);
        System.Console.WriteLine();

        start = DateTime.Now;
        System.Console.WriteLine("Pairs: {0}",TestList.Pass4(TestList2.TestArray, false));
        System.Console.WriteLine("Time: {0}", DateTime.Now.Subtract(start).TotalSeconds);
        System.Console.WriteLine();
    }
}
