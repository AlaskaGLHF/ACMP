using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
       
        var input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);
        var permutation = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var result = BlockSort(n, k, permutation);
        Console.WriteLine(string.Join(" ", result));
        
    }

    static List<int> BlockSort(int n, int k, int[] permutation)
    {
        int maxIndex = 0;
        var blockLengths = new List<int>();
        int currentLength = 0;

        for (int i = 0; i < n; i++)
        {
            currentLength++;
            maxIndex = Math.Max(maxIndex, permutation[i]);
            
            if (maxIndex == i + 1)
            {
                blockLengths.Add(currentLength);
                currentLength = 0;
            }
        }
        
        if (blockLengths.Count < k || (blockLengths.Count == k && currentLength > 0))
        {
            return new List<int> { -1 };
        }
        
        while (blockLengths.Count > k)
        {
            blockLengths[blockLengths.Count - 2] += blockLengths[blockLengths.Count - 1];
            blockLengths.RemoveAt(blockLengths.Count - 1);
        }

        return blockLengths;
    }
}