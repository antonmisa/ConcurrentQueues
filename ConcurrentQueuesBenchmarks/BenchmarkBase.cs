using System.Linq;
using System.Threading;
using ConcurrentQueuesClasses;

namespace ConcurrentQueuesBenchmarks
{
    public class BenchmarkBase
    {
        private int _iterations = 100000;

        public void TestEnqueue(QueueBase<string> queue, int threadCount)
        {
            var threads = Enumerable
                .Range(0, threadCount)
                .Select(
                    n => new Thread(
                        () =>
                        {
                            for (var i = 0; i < _iterations; i++)
                            {
                                queue.Enqueue(i.ToString());
                            }
                        }))
               .ToArray();

            foreach (var thread in threads)
            {
                thread.Start();
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }
        }

        public void TestEnqueueDequeue(QueueBase<string> queue, int threadCount)
        {
            var threads = Enumerable
                .Range(0, threadCount)
                .Select(
                    n => new Thread(
                        () =>
                        {
                            for (var i = 0; i < _iterations; i++)
                            {
                                queue.Enqueue(i.ToString());
                            }
                        }))
                .Concat(new[] { new Thread(() =>
                        {
                            var left = _iterations;
                            while (left > 0)
                            {
                                string res;
                                if (queue.TryDequeue(out res))
                                {
                                    left--;
                                }
                            }
                        })
                })
                .ToArray();

            foreach (var thread in threads)
            {
                thread.Start();
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }
        }
    }

}
