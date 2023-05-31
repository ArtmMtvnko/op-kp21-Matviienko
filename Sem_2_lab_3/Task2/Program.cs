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
            queue.Enqueue("test2");
            queue.Enqueue("test3");
            queue.Enqueue("test4");
            queue.Enqueue("test5");

            Console.WriteLine("Is Queue empty? " + queue.IsEmpty());
            Console.WriteLine("Size of queue: " + queue.Size());

            queue.Iterator();

            var DeletedItem = queue.Dequeue();
            var ReturnetItem = queue.Sample();

            Console.WriteLine("\nDeleted and returned item: " + DeletedItem);
            Console.WriteLine("Only returned item: " + ReturnetItem + "\n");

            queue.Iterator();
        }
    }

    class RandomizedQueue<T> : IIterable<T>
    {
        private LinkedList<T> _list;
        private Random random = new Random();

        public RandomizedQueue() => _list = new LinkedList<T>();

        public void Enqueue(T item)
        {
            _list.AddFirst(item);
        }


        public T Dequeue()
        {
            LinkedListNode<T> currentNode = _list.First;

            if (currentNode == null)
                return default(T);

            int index = random.Next(1, _list.Count + 1);

            for (int i = 1; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            _list.Remove(currentNode);

            return currentNode.Value;
        }

        public T Sample()
        {
            LinkedListNode<T> currentNode = _list.First;

            if (currentNode == null)
                return default(T);

            int index = random.Next(1, _list.Count + 1);

            for (int i = 1; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            return currentNode.Value;
        }

        public int Size()
        {
            return _list.Count;
        }

        public bool IsEmpty()
        {
            return _list.First == null ? true : false;
        }

        private void ShuffleLinkedList<T>(LinkedList<T> list)
        {
            T[] array = list.ToArray();

            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                T temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }

            LinkedListNode<T> currentNode = list.First;
            foreach (T item in array)
            {
                currentNode.Value = item;
                currentNode = currentNode.Next;
            }
        }

        public void Iterator()
        {
            ShuffleLinkedList(_list);
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