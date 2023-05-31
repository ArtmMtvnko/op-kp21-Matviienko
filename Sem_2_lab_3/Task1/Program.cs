using System;
using System.Collections.Generic;

namespace OP_Sem_2_Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Deque<string> deque = new Deque<string>();

            Console.WriteLine("Is Queue Empty? " + deque.IsEmpty());
            Console.WriteLine("Queue size: " + deque.Size());

            deque.AddLast("test");
            deque.AddFirst("generic");
            deque.AddFirst("s t r i n g");
            deque.AddLast("asdaasdfasdfasdfasdfasdf");
            deque.AddLast("final");

            Console.WriteLine("Is Queue Empty? " + deque.IsEmpty());
            Console.WriteLine("Queue size: " + deque.Size());

            deque.Iterator();
        }
    }

    class Deque<T> : IIterable<T>
    {
        private LinkedList<T> _list;

        public Deque() => _list = new LinkedList<T>();

        public void AddFirst(T item)
        {
            _list.AddFirst(item);
        }

        public void AddLast(T item)
        {
            _list.AddLast(item);
        }

        public void RemoveFirst()
        {
            _list.RemoveFirst();
        }

        public void RemoveLast()
        {
            _list.RemoveLast();
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