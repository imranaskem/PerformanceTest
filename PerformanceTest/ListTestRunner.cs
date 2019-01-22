using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PerformanceTest
{
    public class ListTestRunner
    {
        private List<int> List { get; set; }

        public ListTestRunner()
        {
            this.List = new List<int>();
        }

        public long AddTest(int number)
        {
            var sw = Stopwatch.StartNew();

            for (int i = 0; i < number; i++)
            {
                this.List.Add(i);
            }

            sw.Stop();

            return sw.ElapsedTicks;
        }

        public long ContainsTest(int number)
        {
            var sw = Stopwatch.StartNew();

            for (int i = 0; i < (number / 4); i++)
            {
                var rand = new Random();                
                this.List.Contains(rand.Next(number));
            }

            sw.Stop();

            return sw.ElapsedTicks;
        }

        public long RemoveTest(int number)
        {
            var sw = Stopwatch.StartNew();

            for (int i = 0; i < (number / 4); i++)
            {
                var rand = new Random();
                this.List.Remove(rand.Next(number));
            }

            sw.Stop();

            return sw.ElapsedTicks;
        }
    }
}
