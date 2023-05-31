using System;
using System.Collections.Generic;

namespace OP_Sem_2_Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomizedQueue<string> queue = new RandomizedQueue<string>();

            Console.WriteLine("Is Queue empty? " + queue.IsEmpty());
            Console.WriteLine("Size of queue: " + queue.Size());

            queue.Enqueue("test1");
            queue.Enqueue("random");
            queue.Enqueue("queue");

            Console.WriteLine("Is Queue empty? " + queue.IsEmpty());
            Console.WriteLine("Size of queue: " + queue.Size());

            queue.Iterator();
        }
    }

    class RandomizedQueue<T> : IIterable<T>
    {
        private LinkedList<T> _list;

        public RandomizedQueue() => _list = new LinkedList<T>();

        public void Enqueue(T item)
        {
            _list.AddFirst(item);
        }

        public T Dequeue()
        {
            return default(T);
        }

        public T Sample()
        {
            return default(T);
        }

        public int Size()
        {
            return _list.Count;
        }

        public bool IsEmpty()
        {
            return _list.First == null ? true : false;
        }

        public void Iterator()
        {
            IteratorImpl iterator = new IteratorImpl(_list);

            if (_list.Count == 0)
                iterator.HasNext = false;

            while (iterator.HasNext)
            {
                Console.WriteLine(iterator.MoveNext());
            }
        }

        private class IteratorImpl : IIterator<T>
        {
            private LinkedListNode<T> _currentNode;

            public IteratorImpl(LinkedList<T> list)
            {
                _currentNode = list.First;
            }

            public bool HasNext { get; set; } = true;

            //bool IIterator<T>.HasNext => throw new NotImplementedException();

            public T MoveNext()
            {
                T result = _currentNode.Value;

                if (_currentNode.Next == null)
                {
                    HasNext = false;
                }
                else
                {
                    _currentNode = _currentNode.Next;
                }

                return result;
            }
        }

    }

    interface IIterable<T>
    {
        public void Iterator();
    }

    interface IIterator<T>
    {
        bool HasNext { get; }
        T MoveNext();
    }
}