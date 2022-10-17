using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class LinkedListItem<T>
    {
        public LinkedListItem(T value)
        {
            Value = value;
        }

        internal LinkedListItem(LinkedList<T> list, T value) : this(value)
        {
            List = list;
        }

        public T Value { get; set; }

        public LinkedListItem<T>? Next { get; internal set; }

        public LinkedListItem<T>? Prev { get; internal set; }

        internal LinkedList<T>? List { get; set; }

        internal void Reset()
        {
            List = null;
            Next = null;
            Prev = null;
        }
    }
}
