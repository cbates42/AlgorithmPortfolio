//Visualgo.net and Stephens, Rod. Essential Algorithms referenced for sorting algorithms

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Markup;

namespace SortingExample
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
            Run();
        }

        public void Run()
        {

            Stopwatch stopwatch = Stopwatch.StartNew();
            List<int> bubbleResult = bubbleSort(data);
            stopwatch.Stop();
            Console.WriteLine($"Bubble Sort: {stopwatch.Elapsed.TotalMilliseconds} ms");
            Console.WriteLine("Worst-case: O(n^2), best-case: O(1)");

            stopwatch.Restart();
            List<int> insertRes = insertSort(data);
            stopwatch.Stop();
            Console.WriteLine($"\nInsertion Sort: {stopwatch.Elapsed.TotalMilliseconds} ms");
            Console.WriteLine("Worst-case: O(n^2), best-case: O(n)");

            stopwatch.Restart();
            List<int> selectResult = selectSort(data);
            stopwatch.Stop();
            Console.WriteLine($"\nSelection Sort: {stopwatch.Elapsed.TotalMilliseconds} ms");
            Console.WriteLine("Worst-case: O(n^2), best-case: O(1)");
        }
        
        public List<int> bubbleSort(List<int> list)
        {
            Console.WriteLine("BubbleSort: Starts at the beginning, and swaps the first two if the first is larger. Keeps doing this for \neach pair in the dataset.");
            bool keepGoing = true;
            while (keepGoing)
            {
                keepGoing = false;

                //start from 1
                for(int i = 1; i < list.Count; i++)
                {
                    if (list[i] < list[i - 1])
                    {

                        //swap the data if the earlier item is larger
                        int temp = list[i];
                        list[i] = list[i - 1];
                        list[i - 1] = temp;

                        keepGoing = true;
                    }

                }    
            }
            return list;
        }
        public List<int> insertSort(List<int> list)
        {

            Console.WriteLine("InsertionSort: Builds sorted set one at a time, looking through already sorted items and moving them +1 if\n need be.");
            for(int i = 0; i < list.Count; i++)
            {
                int item = list[i];
                int j = i - 1;
                
                //find where item needs to be placed
                while (j >= 0 && list[j] > item)
                {
                    //make room for the item
                    list[j + 1] = list[j];
                    j--;
                }

                //insert
                list[j + 1] = item;
            }

            return list;
        }

        public List<int> selectSort(List<int> list)
        {
            Console.WriteLine("Selection Sort: Essentailly sorts by repeatedly adding the larger piece of data further in,\nlooking for the smallest item over and over.");

            for(int i = 0; i < list.Count - 1; i++)
            {
                //assume first item is the smallest
                int smallest = i;

                //find actual smallest
                for(int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[smallest])
                    {
                        smallest = j;
                    }
                }

                //if smallest isn't the smallest, switch it with what is considered the smallest right now.
                if(smallest != i)
                {
                    int temp = list[i];
                    list[i] = list[smallest];
                    list[smallest] = temp;
                }

            }


            return list;
        }
    }
}
