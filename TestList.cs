using System;

public class TestList
{
    static int[] arr = {10, 5, 2, 7, 7, 49};
    
    public int[] TestArray;

    // Default constructor generates provided example list
    public TestList()
    {
        TestArray = arr;
    }

    // Secondary constructor generates random list of specified length, between specified values, in order to better test performance of implementations
    public TestList(int length, int min, int max)
    {
        int [] randArray = new int[length];
        Random rand = new Random();
        for (int i = 0; i < randArray.Length; i++)
        {
            randArray[i] = rand.Next(min, max);
        }

        TestArray = randArray;
    }

    public void PrintList()
    {
        System.Console.Write("{");
        for( int i =0; i < TestArray.Length; i ++)
        {
            System.Console.Write("{0}", TestArray[i]);
            if (i < TestArray.Length - 1)
                System.Console.Write(", ");
        }
        System.Console.WriteLine("}");
    }


    // First, simplest way of finding pairs; For each element in array, passes all other elements and calculates sum.
    // For each sum, passes all elements and returns pair if equal. This has the unwanted effect of doubling identified pairs
    public static int Pass1(int[] arr, bool printPairs)
    {
        int cnt = 0;
        System.Console.WriteLine("Pass 1");
        for (int i = 0;i < arr.Length; i++)
        {
            for (int j = 0; j < arr.Length; j++)
            {
                for (int k = 0; k < arr.Length; k++)
                {
                    if ((arr[k] == arr[i] + arr[j]) & (i != j))
                    {
                        cnt ++;
                        if (printPairs)
                        {
                            System.Console.WriteLine("({0},{1}) = {2}", arr[i], arr[j], arr[k]);
                        }
                    }
                }
            }
        }
        return cnt;
    }

    // Improvement on first pass is to sort the array beforehand, so that searching the sum doesn't need to pass all the array,
    // just the numbers larger than arr[i]
    public static int Pass2(int[] arr, bool printPairs)
    {
        int cnt = 0;
        System.Console.WriteLine("Pass 2");
        var _arr = arr;
        Array.Sort(_arr);

        for (int i = 0;i < _arr.Length; i++)
        {
            for (int j = 0; j < _arr.Length; j++)
            {
                for (int k = i; k < _arr.Length; k++)
                {
                    if ((_arr[k] == _arr[i] + _arr[j]) & (i != j))
                    {
                        cnt ++;
                        if (printPairs)
                        {
                            System.Console.WriteLine("({0},{1}) = {2}", _arr[i], _arr[j], _arr[k]);
                        }
                    }
                }
            }
        }
        return cnt;
    }

    // To eliminate duplicates, j does not need to search the whole sorted array again, just the numbers that have not beed tested yet
    // Results still appear multiple times, but that is intentional to indicate there is more than one instance of either sum or elements in array
    public static int Pass3(int[] arr, bool printPairs)
    {
        int cnt = 0;
        System.Console.WriteLine("Pass 3");
        var _arr = arr;
        Array.Sort(_arr);

        for (int i = 0;i < _arr.Length; i++)
        {
            for (int j = i; j < _arr.Length; j++)
            {
                for (int k = j; k < _arr.Length; k++)
                {
                    if ((_arr[k] == _arr[i] + _arr[j]) & (i != j))
                    {
                        cnt ++;
                        if (printPairs)
                        {
                            System.Console.WriteLine("({0},{1}) = {2}", _arr[i], _arr[j], _arr[k]);
                        }
                    }
                }
            }
        }
        return cnt;
    }

    // An alternative solution is to use a hash table to determine the frequency of each element. The hash table is then read from both directions
    // to determine if progressively closer elements have a sum already hashed
    public static int Pass4(int[] arr, bool printPairs)
    {
        int cnt = 0;
        System.Console.WriteLine("Pass 4");
        int[] hash = new int[arr.Max()];
        
        for (int i = 0; i < arr.Length; i++)
        {
            hash[arr[i]]++;
        }

        for (int i = 0; i <= hash.Length; i++)
        {
            for (int j = hash.Length; j > i; j--)
            {
                if ((hash[i] > 0) & (hash[j] > 0) & (i + j <= arr.Max()))
                {
                    if (hash[i+j] > 0)
                    {
                        cnt += Math.Max(hash[i+j], Math.Max(hash[i], hash[j]));
                        if (printPairs)
                        {
                            System.Console.WriteLine("({0},{1}) = {2}", i, j, i + j);
                        }
                    }
                } 
            }
        }
        return cnt;
    }
}