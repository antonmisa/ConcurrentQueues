using System.Collections.Generic;

namespace ConcurrentQueuesClasses
{
    public class QueueWrapper<T> : QueueBase<T> where T: class
    {
        private readonly object _syncRoot = new object();
        private readonly Queue<T> _queue = new Queue<T>();

        public override void Enqueue(T data)
        {
            lock(_syncRoot)
            {
                _queue.Enqueue(data);
            }
        }

        public override bool TryDequeue(out T data)
        {
            if (_queue.Count > 0)
            {
                lock (_syncRoot)
                {
                    if (_queue.Count > 0)
                    {
                        data = _queue.Dequeue();
                        return true;
                    }
                }
            }
            data = default(T);
            return false;
        }

        public new bool IsEmpty
        {
            get { return _queue.Count == 0; }
        }
    }
}
