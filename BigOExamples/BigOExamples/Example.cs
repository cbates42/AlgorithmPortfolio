using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigOExamples
{
    internal class Example
    {
        private List<string> i = new List<string>();
        void ConstantTime()
        {

            //No matter what is input, this method will always only look for the first item
            Console.WriteLine(i[0]);
        }

        void LinearTime()
        {
            foreach(string item in i)
            {
                //Method will run once for each item in the list
                Console.WriteLine(item);
            }
        }

        void QuadraticTime()
        {
            foreach(string item in i)
            {
                foreach(string item2 in i)
                {

                    //Because of the nested loop, method will run an amount of times for each time the 
                    //outer loop ran
                    Console.WriteLine(item, item2);
                }
            }
        }
    }
}
