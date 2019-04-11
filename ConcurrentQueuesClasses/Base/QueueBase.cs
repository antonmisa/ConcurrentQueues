namespace ConcurrentQueuesClasses
{
    public abstract class QueueBase<T>
    {
        protected Item _head;
        protected Item _tail;

        protected class Item
        {
            public T Data;
            public Item Next;            

            public Item()
            {

            }

            public Item(T data)
            {
                Data = data;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return _head == _tail;
            }
        }

        public abstract void Enqueue(T data);

        public abstract bool TryDequeue(out T data);
    }
}
