using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using ConcurrentQueuesClasses;
using System;

namespace ConcurrentQueuesBenchmarks
{
    public class ConcurrentQueueEnqueueDequeueBenchmark : BenchmarkBase
    {
        [Benchmark(Description = "QueueWrapper enqueue/dequeue with 2 threads")]
        public void QueueWrapperDequeueW2Threads()
        {
            QueueBase<string> queue = new QueueWrapper<string>();
            base.TestEnqueueDequeue(queue, 2);
        }

        [Benchmark(Description = "LockFreeQueue enqueue/dequeue with 2 threads")]
        public void LockFreeQueueDequeueW2Threads()
        {
            QueueBase<string> queue = new LockFreeQueue<string>();
            base.TestEnqueueDequeue(queue, 2);
        }

        [Benchmark(Description = "ConcurrentQueueWrapper enqueue/dequeue with 2 threads")]
        public void ConcurrentQueueWrapperDequeueW2Threads()
        {
            QueueBase<string> queue = new ConcurrentQueueWrapper<string>();
            base.TestEnqueueDequeue(queue, 2);
        }

        [Benchmark(Description = "QueueWrapper enqueue/dequeue with 4 threads")]
        public void QueueWrapperDequeueW4Threads()
        {
            QueueBase<string> queue = new QueueWrapper<string>();
            base.TestEnqueueDequeue(queue, 4);
        }

        [Benchmark(Description = "LockFreeQueue enqueue/dequeue with 4 threads")]
        public void LockFreeQueueDequeueW4Threads()
        {
            QueueBase<string> queue = new LockFreeQueue<string>();
            base.TestEnqueueDequeue(queue, 4);
        }

        [Benchmark(Description = "ConcurrentQueueWrapper enqueue/dequeue with 4 threads")]
        public void ConcurrentQueueWrapperDequeueW4Threads()
        {
            QueueBase<string> queue = new ConcurrentQueueWrapper<string>();
            base.TestEnqueueDequeue(queue, 4);
        }
    }

    public class ConcurrentQueueEnqueueBenchmark : BenchmarkBase
    {
        [Benchmark(Description = "QueueWrapper enqueue with 2 threads")]
        public void QueueWrapperEnqueueW10Threads()
        {
            QueueBase<string> queue = new QueueWrapper<string>();
            base.TestEnqueue(queue, 2);
        }

        [Benchmark(Description = "LockFreeQueue enqueue with 2 threads")]
        public void LockFreeQueueEnqueueW10Threads()
        {
            QueueBase<string> queue = new LockFreeQueue<string>();
            base.TestEnqueue(queue, 2);
        }

        [Benchmark(Description = "ConcurrentQueueWrapper enqueue with 2 threads")]
        public void ConcurrentQueueWrapperEnqueueW10Threads()
        {
            QueueBase<string> queue = new ConcurrentQueueWrapper<string>();
            base.TestEnqueue(queue, 2);
        }

        [Benchmark(Description = "QueueWrapper enqueue with 4 threads")]
        public void QueueWrapperEnqueueW100Threads()
        {
            QueueBase<string> queue = new QueueWrapper<string>();
            base.TestEnqueue(queue, 4);
        }

        [Benchmark(Description = "LockFreeQueue enqueue with 4 threads")]
        public void LockFreeQueueEnqueueW100Threads()
        {
            QueueBase<string> queue = new LockFreeQueue<string>();
            base.TestEnqueue(queue, 4);
        }

        [Benchmark(Description = "ConcurrentQueueWrapper enqueue with 4 threads")]
        public void ConcurrentQueueWrapperEnqueueW100Threads()
        {
            QueueBase<string> queue = new ConcurrentQueueWrapper<string>();
            base.TestEnqueue(queue, 4);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ConcurrentQueueEnqueueBenchmark>();
            BenchmarkRunner.Run<ConcurrentQueueEnqueueDequeueBenchmark>();
        }
    }
}
