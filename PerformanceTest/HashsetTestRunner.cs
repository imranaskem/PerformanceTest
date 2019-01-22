using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PerformanceTest
{
    public class HashsetTestRunner
    {
        private HashSet<int> Hash { get; set; }

        public HashsetTestRunner()
        {
            this.Hash = new HashSet<int>();
        }

        public long AddTest(int number)
        {
            var sw = Stopwatch.StartNew();

            for (int i = 0; i < number; i++)
            {
                this.Hash.Add(i);
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

                this.Hash.Contains(rand.Next(number));
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

                this.Hash.Remove(rand.Next(number));
            }

            sw.Stop();

            return sw.ElapsedTicks;
        }
    }
}
