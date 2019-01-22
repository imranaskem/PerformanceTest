using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PerformanceTest
{
    public static class PerfTest
    {
        public static long DoTest<TCol, TInput>(
            List<TInput> inputs,             // the inputs for the test
            Func<TCol> initCollection,      // initialize a new collection for the test
            Action<TCol, TInput> action,    // the action to perform against the input
            int numberOfRuns)               // how many times do we need to repeat the test?
            where TCol : class, new()
        {
            long totalTime = 0;
            var stopwatch = new Stopwatch();

            for (var i = 0; i < numberOfRuns; i++)
            {
                // get a new collection for this test run
                var collection = initCollection();

                // start the clock and execute the test
                stopwatch.Start();
                inputs.ForEach(n => action(collection, n));
                stopwatch.Stop();

                // add to the total time
                totalTime += stopwatch.ElapsedMilliseconds;

                // reset the stopwatch for the next run
                stopwatch.Reset();
            }

            var avgTime = totalTime / numberOfRuns;

            return avgTime;
        }
    }
}
