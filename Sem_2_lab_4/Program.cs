using System;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<string, int> table = new HashTable<string, int>();

            using (StreamReader sr = new StreamReader(@"D:\Microsoft Visual Studio\Projects\OP_Sem_2_Lab_4\OP_Sem_2_Lab_4\Words.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    table.Add(line, 12);
                }
            }

            //table.ShowHashTable();

            //table.Remove("Cat");
            //table.Remove("Sun");
            //table.Remove("TTTTT");

            //Console.WriteLine("\n");

            //table.ShowHashTable();

            //Console.WriteLine("\n Contains? " + table.Contains("Tree"));
            //Console.WriteLine("\n Contains? " + table.Contains("Treexx"));

            //Console.WriteLine("\n Get " + table.Get("Tree"));
            //Console.WriteLine("\n Get " + table.Get("Tr"));

            //Console.WriteLine("\n" + table.Size());

            //table.Clear();

            //Console.WriteLine("\n" + table.Size());

            //table.ShowHashTable();
            table.ShowHashTable();

            Ispell<int> ispell = new Ispell<int>(table);

            string state = "";

            while (state != "end")
            {
                state = ispell.EnterCommand();
                Console.WriteLine(state);
            }

        }
    }

    class HashTable<TKey, TValue>
    {
        private KeyValuePair<TKey, TValue>[] _buckets;
        private int defaultCapacity = 127;
        public HashTable() => _buckets = new KeyValuePair<TKey, TValue>[defaultCapacity];

        public HashTable(int intialCapacity) => _buckets = new KeyValuePair<TKey, TValue>[intialCapacity];

        public void Add(TKey key, TValue value)
        {
            int hashCode = key.GetHashCode();
            int hash;
            int size = _buckets.Length;

            for (int i = 0; i < size; i++)
            {
                hash = (Math.Abs(hashCode) + i * i) % size;
                if (_buckets[hash].Equals(default(KeyValuePair<TKey, TValue>)))
                {
                    _buckets[hash] = new KeyValuePair<TKey, TValue>(key, value);
                    break;
                }
            }
        }

        public void Remove(TKey key)
        {
            int hashCode = key.GetHashCode();
            int hash;
            int size = _buckets.Length;

            for (int i = 0; i < size; i++)
            {
                hash = (Math.Abs(hashCode) + i * i) % size;
                if (_buckets[hash].Key == null)
                    break;
                if (_buckets[hash].Key.ToString() == key.ToString())
                {
                    _buckets[hash] = default(KeyValuePair<TKey, TValue>);
                    break;
                }
            }
        }

        public TValue Get(TKey key)
        {
            int hashCode = key.GetHashCode();
            int hash;
            int size = _buckets.Length;

            for (int i = 0; i < size; i++)
            {
                hash = (Math.Abs(hashCode) + i * i) % size;
                if (_buckets[hash].Key == null)
                    return default(TValue);
                if (_buckets[hash].Key.ToString() == key.ToString())
                {
                    return _buckets[hash].Value;
                }
            }

            return default(TValue);
        }

        public bool Contains(TKey key)
        {
            int hashCode = key.GetHashCode();
            int hash;
            int size = _buckets.Length;

            for (int i = 0; i < size; i++)
            {
                hash = (Math.Abs(hashCode) + i * i) % size;
                if (_buckets[hash].Key == null)
                    return false;
                if (_buckets[hash].Key.ToString() == key.ToString())
                {
                    return true;
                }
            }

            return false;
        }

        public void Clear() { _buckets = new KeyValuePair<TKey, TValue>[_buckets.Length]; }

        public int Size()
        {
            int count = 0;

            foreach (var bucket in _buckets)
            {
                if (!bucket.Equals(default(KeyValuePair<TKey, TValue>)))
                {
                    count++;
                }
            }

            return count;
        }

        public int Length() { return _buckets.Length; }

        public void ShowHashTable()
        {
            foreach (var bucket in _buckets)
            {
                if (!bucket.Equals(default(KeyValuePair<TKey, TValue>)))
                {
                    Console.WriteLine(bucket.ToString());
                }
            }
        }
    }

    class Ispell<TValue>
    {
        private HashTable<string, TValue> table;

        public Ispell(HashTable<string, TValue> hashTable) => table = hashTable;
        public string EnterCommand()
        {
            string key = Console.ReadLine().Replace(" ", "");

            if (key.ToLower() == "end") return "end";

            return table.Contains(key) ? "OK" : "Wrong Spelling";
        }
    }
}