using System.Threading;

namespace ConcurrentQueuesClasses
{
    public class LockFreeQueue<T>: QueueBase<T> where T: class
    {
        public LockFreeQueue()
        {
            _head = new Item();
            _tail = _head;
        }

        public override void Enqueue(T data)
        {
            Item item = new Item(data);

            Item oldTail = null;
            Item oldNext = null;

            bool update = false;
            while (!update)            
            {
                oldTail = _tail;
                oldNext = oldTail.Next;

                Thread.MemoryBarrier();
                
                if (_tail == oldTail)
                {
                    if (oldNext == null)
                    {
                        update = Interlocked.CompareExchange(ref _tail.Next, item, null) == null;
                    }
                    else
                    {
                        Interlocked.CompareExchange(ref _tail, oldNext, oldTail);
                    }
                }
            }
            Interlocked.CompareExchange(ref _tail, item, oldTail);
        }

        public override bool TryDequeue(out T data)
        {
            data = default(T);
            Item oldNext = null;
            bool advanced = false;

            while (!advanced)
            {
                Item oldHead = _head;
                Item oldTail = _tail;
                oldNext = oldHead.Next;

                Thread.MemoryBarrier();
                if (oldHead == _head)
                {
                    if (oldHead == oldTail)
                    {
                        if (oldNext != null)
                        {
                            Interlocked.CompareExchange(ref _tail, oldNext, oldTail);
                            continue;
                        }
                        data = default(T);
                        return false;
                    }
                    data = oldNext.Data;
                    advanced = Interlocked.CompareExchange(ref _head, oldNext, oldHead) == oldHead;
                }                
            }
            oldNext.Data = default(T);
            return true;
            
        }
    }
}
