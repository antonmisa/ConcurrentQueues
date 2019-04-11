using System.Collections.Concurrent;

namespace ConcurrentQueuesClasses
{
    public class ConcurrentQueueWrapper<T>: QueueBase<T> where T: class
    {
        private readonly ConcurrentQueue<T> _queue = new ConcurrentQueue<T>();

        public override void Enqueue(T data)
        {
            _queue.Enqueue(data);
        }

        public override bool TryDequeue(out T data)
        {
            return _queue.TryDequeue(out data);
        }
    }
}
