using ConcurrentQueuesClasses;
using System.Linq;
using System.Threading;

namespace ConcurrentQueuesTest
{
    public class UnitTestBase
    {
        private int _threadCount = 4;
        private int _iterations = 10000;

        public int ThreadCount
        {
            get { return _threadCount; }
            set { _threadCount = value; }
        }

        public int Iterations
        {
            get { return _iterations; }
            set { _iterations = value; }
        }

        public void TestEnqueue(QueueBase<string> queue)
        {
            var threads = Enumerable
                .Range(0, _threadCount)
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

        public void TestDequeue(QueueBase<string> queue)
        {
            var threads = Enumerable
                .Range(0, _threadCount)
                .Select(
                    n => new Thread(
                        () =>
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
    }
}
