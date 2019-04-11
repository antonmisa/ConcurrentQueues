using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConcurrentQueuesClasses;

namespace ConcurrentQueuesTest
{
    [TestClass]
    public class UnitTestQueueWrapper: UnitTestBase
    {
        private readonly QueueBase<string> enc_queue = new QueueWrapper<string>();
        private readonly QueueBase<string> dec_queue = new QueueWrapper<string>();

        public UnitTestQueueWrapper()
        {
            base.TestEnqueue(dec_queue);
        }

        [TestMethod]
        public void TestEnqueue()
        {
            base.TestEnqueue(enc_queue);
        }

        [TestMethod]
        public void TestDequeue()
        {
            base.TestDequeue(dec_queue);
            Assert.IsTrue(dec_queue.IsEmpty, @"Queue must be empty!");                
        }
    }

    [TestClass]
    public class UnitTestLockFreeQueue : UnitTestBase
    {
        private readonly QueueBase<string> enc_queue = new LockFreeQueue<string>();
        private readonly QueueBase<string> dec_queue = new LockFreeQueue<string>();

        public UnitTestLockFreeQueue()
        {
            base.TestEnqueue(dec_queue);
        }

        [TestMethod]
        public void TestEnqueue()
        {
            base.TestEnqueue(enc_queue);
        }

        [TestMethod]
        public void TestDequeue()
        {
            base.TestDequeue(dec_queue);
            Assert.IsTrue(dec_queue.IsEmpty, @"Queue must be empty!");
        }
    }

    [TestClass]
    public class UnitTestConcurrentQueueWrapper : UnitTestBase
    {
        private readonly QueueBase<string> enc_queue = new ConcurrentQueueWrapper<string>();
        private readonly QueueBase<string> dec_queue = new ConcurrentQueueWrapper<string>();

        public UnitTestConcurrentQueueWrapper()
        {
            base.TestEnqueue(dec_queue);
        }

        [TestMethod]
        public void TestEnqueue()
        {
            base.TestEnqueue(enc_queue);
        }

        [TestMethod]
        public void TestDequeue()
        {
            base.TestDequeue(dec_queue);
            Assert.IsTrue(dec_queue.IsEmpty, @"Queue must be empty!");
        }
    }
}
