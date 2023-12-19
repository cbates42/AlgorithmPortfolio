using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingExample
{
    internal class App
    {
        List<int> data = new List<int>();
        public App()
        {
            var path = Directory.GetCurrentDirectory() + @"\scores.txt";
            Console.WriteLine("Reading from: " + path);


            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (int.TryParse(line, out int num))
                        {
                            data.Add(num);
                        }
                        else
                        {
                            Console.WriteLine($"Non-integer line encountered: {line}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading the file: {ex.Message}");
            }

            data.Sort();
            Run();
        }

        public void Run()
        {

            Stopwatch stopwatch = Stopwatch.StartNew();
            int linearResult = LinearSearch(data, 71);
            stopwatch.Stop();
            Console.WriteLine($"LinearSearch: {stopwatch.Elapsed.TotalMilliseconds} ms");

            stopwatch.Restart();
            int binaryRes = BinarySearch(data, 71);
            stopwatch.Stop();
            Console.WriteLine($"BinarySearch: {stopwatch.Elapsed.TotalMilliseconds} ms");

            stopwatch.Restart();
            int InterpolRes = InterpolationSearch(data, 71);
            stopwatch.Stop();
            Console.WriteLine($"InterpolationSearch: {stopwatch.Elapsed.TotalMilliseconds} ms");
            Console.ReadLine();
        }

        public int LinearSearch(List<int> list, int target)
        {
            Console.WriteLine("LinearSearch: Checks the dataset in sequential order, no matter whether it is sorted or not, until the target is found.");
            Console.WriteLine("Worst-case: O(n)\n Best-case: O(1)\n Average: O(n/2)");
            int n = list.Count;

            for(int i = 0; i < n; i++)
            {
                if (list[i] == target)
                {
                    return i;
                }
            }

            return -1;
        }

        public int BinarySearch(List<int> list, int target) 
        {

            Console.WriteLine("BinarySearch: Requires a sorted dataset. Checks if the target is lower or higher than the median of the dataset,\n then searches the other half of the least, repeating this over and over until it finds the target.");
            Console.WriteLine("Worst-case: O(log n)\n Best-case: O(1)");
            int L = 0;
            int R = list.Count - 1;
            
            while(L <= R)
            {
                int m = L + (R - L) / 2;

                if (list[m] < target)
                {
                    L = m + 1;
                }

                else if (list[m] > target)
                {
                    R = m - 1;
                }
                else 
                {
                    //it found the target, return it
                    return m;
                }
            }

            return -1;
            //couldnt find target
        }
        public int InterpolationSearch(List<int> list, int target)
        {
            Console.WriteLine("InterpolationSearch: Similar to BinarySearch but instead of starting at the middle it can search various positions.");
            Console.WriteLine("Worst-case: O(n)\n Best-case: O(1)");
            int low = 0;
            int high = list.Count - 1;

            while(low <= high && target >= list[low] && target <= list[high])
            {
                if(low == high)
                {
                    if (list[low] == target)
                        return low;

                    else
                    return -1;
                }

                int pos = low + (((high - low) / (list[high] - list[low])) * (target - list[low]));

                if (list[pos] == target)
                    return pos;

                if (list[pos] < target)
                    low = pos + 1;
                else
                    high = pos - 1;
            }
            return -1;

        }
    }

  
}
