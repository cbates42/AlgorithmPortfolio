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
                            Console.WriteLine($"non-int line: {line}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
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

            //literally just loop through the dataset until you find the target.
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
            
            //keep looping until you've looked through the whole dataset
            while(L <= R)
            {
                //find the middle
                int m = L + (R - L) / 2;

                 //if the target is higher than the middle, narrows the search
                if (list[m] < target)
                {
                    L = m + 1;
                }

                //if higher, narrows the search.
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

            //keep looping, and make sure target is between the low/high ranges
            while(low <= high && target >= list[low] && target <= list[high])
            {
                if(low == high)
                {
                    //if theres only one value left check if it's the target.
                    if (list[low] == target)
                        return low;

                    else
                    return -1;
                }

                //interpolation formula to estimate the target's position
                int pos = low + (((high - low) / (list[high] - list[low])) * (target - list[low]));

                //checks to see if the target is at the estimated position
                if (list[pos] == target)
                    return pos;

                //if target is higher than estimation, check the higher half
                if (list[pos] < target)
                    low = pos + 1;
                else
                    high = pos - 1;
                //if target is lower, check the lower half
            }
            return -1;

        }
    }

  
}
