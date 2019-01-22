using System;
using System.Collections.Generic;
using System.Linq;

namespace PerformanceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            const int addsToPerform = 100000;

            var answers = new Dictionary<string, long>();
            var listTest = new ListTestRunner();
            var hashTest = new HashsetTestRunner();
            var dictTest = new DictionaryTestRunner();

            Console.WriteLine("Collection performance tester");

            Console.WriteLine($"Test: Add performance of adding {addsToPerform} ints to each collection");
                       
            answers.Add("List", listTest.AddTest(addsToPerform));
            
            answers.Add("Hashset", hashTest.AddTest(addsToPerform));            
                       
            answers.Add("Dictionary", dictTest.AddTest(addsToPerform));      

            PrintGraph(answers);

            answers.Clear();

            Console.WriteLine($"Test: Contains performance for {addsToPerform / 4} ints in each collection");

            answers.Add("List", listTest.ContainsTest(addsToPerform));

            answers.Add("Hashset", hashTest.ContainsTest(addsToPerform));

            answers.Add("Dictionary(Key)", dictTest.KeyContainsTest(addsToPerform));

            answers.Add("Dictionary(Value)", dictTest.ValueContainsTest(addsToPerform));
            
            PrintGraph(answers);

            answers.Clear();

            Console.WriteLine($"Test: Remove performance for {addsToPerform / 4} ints in each collection");

            answers.Add("List", listTest.RemoveTest(addsToPerform));

            answers.Add("Hashset", hashTest.RemoveTest(addsToPerform));

            answers.Add("Dictionary", dictTest.RemoveTest(addsToPerform));

            PrintGraph(answers);
        }

        private static void PrintGraph(Dictionary<string, long> answers)
        {
            Console.WriteLine(@"
-------------------------------
Collection          Ticks
");

            foreach (var item in answers)
            {
                Console.WriteLine($"{item.Key, -18}  {item.Value, -1}");
            }
            Console.WriteLine("-------------------------------");

            Console.ReadLine();
        }
    }
}
