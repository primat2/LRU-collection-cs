using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeastRecentlyUsedCollection
{
    class LRU<T>
    {
        ListLRU<T> list;
        Dictionary<int, Node<T>> dict;

        public T this[int i]
        {
            get
            {
                if (!dict.ContainsKey(i))
                    throw new IndexOutOfRangeException();
                return Get(i);
            }
            set { Add(i, value); }
        }

        public void Add(int key, T value)
        {
            var newNode = list.Add(value, key);
            dict[key] = newNode;
        }

        public T Get(int key)
        {
            if (!dict.ContainsKey(key))
                throw new IndexOutOfRangeException();

            var nodeToGet = dict[key];
            return list.Get(nodeToGet);
        }

        public void RemoveLastUsed()
        {
            int key = list.RemoveLastUsed();
            dict.Remove(key);
        }

    }
}
