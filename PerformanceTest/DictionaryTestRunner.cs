using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PerformanceTest
{
    public class DictionaryTestRunner
    {
        private Dictionary<int, int> Dict { get; set; }

        public DictionaryTestRunner()
        {
            this.Dict = new Dictionary<int, int>();
        }

        public long AddTest(int number)
        {
            var sw = Stopwatch.StartNew();

            for (int i = 0; i < number; i++)
            {
                this.Dict.Add(i, i);
            }

            sw.Stop();

            return sw.ElapsedTicks;
        }

        public long KeyContainsTest(int number)
        {
            var sw = Stopwatch.StartNew();

            for (int i = 0; i < (number / 4); i++)
            {
                var rand = new Random();

                this.Dict.ContainsKey(rand.Next(number));
            }

            sw.Stop();

            return sw.ElapsedTicks;
        }

        public long ValueContainsTest(int number)
        {
            var sw = Stopwatch.StartNew();

            for (int i = 0; i < (number / 4); i++)
            {
                var rand = new Random();

                this.Dict.ContainsValue(rand.Next(number));
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

                this.Dict.Remove(rand.Next(number));
            }

            sw.Stop();

            return sw.ElapsedTicks;
        }
    }
}
