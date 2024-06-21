using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul8.Task.RecentlyUsedList
{
    public class RecentlyUsedList
    {
        private readonly LinkedList<string> _list;
        private readonly int _capacity;

        public RecentlyUsedList(int capacity = 5)
        {
            _capacity = capacity;
            _list = new LinkedList<string>();
        }

        public string this[int index]
        {
            get
            {
                if (index < 0 || index >= _list.Count)
                {
                    throw new IndexOutOfRangeException("Index out of bounds of the list.");
                }
                return _list.ElementAt(index);
            }
        }

        public void Add(string item)
        {
            if (string.IsNullOrEmpty(item))
            {
                throw new ArgumentNullException(nameof(item));
            }

            _list.Remove(item);
            _list.AddFirst(item);

            if (_list.Count > _capacity)
            {
                _list.RemoveLast();
            }
        }

        public int Count => _list.Count;
    }
}
