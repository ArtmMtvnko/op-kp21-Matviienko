using System;

namespace OP_Sem_2_Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Deque<int> deque = new Deque<int>();

            Console.WriteLine(deque.IsEmpty());
            Console.WriteLine(deque.Size());

            deque.AddLast(1);
            deque.AddLast(2);
            deque.AddLast(3);

            Console.WriteLine(deque.IsEmpty());
            Console.WriteLine(deque.Size());
        }
    }

    class Deque<T>
    {
        LinkedList<T> list;

        public Deque() => list = new LinkedList<T>();

        public void AddFirst(T item)
        {
            list.AddFirst(item);
        }

        public void AddLast(T item)
        {
            list.AddLast(item);
        }

        public void RemoveFirst()
        {
            list.RemoveFirst();
        }

        public void RemoveLast()
        {
            list.RemoveLast();
        }

        public int Size()
        {
            return list.Count;
        }

        public bool IsEmpty()
        {
            return list.First == null ? true : false;
        }

        private class IteratorImpl : IIterator<T>
        {

            bool HasNext { get; }

            bool IIterator<T>.HasNext => throw new NotImplementedException();

            public T MoveNext()
            {
                return default(T);
            }
        }

    }

    interface IIterable<T>
    {
        public IIterator<T> Iterator();
    }

    interface IIterator<T>
    {
        bool HasNext { get; }
        T MoveNext();
    }
}