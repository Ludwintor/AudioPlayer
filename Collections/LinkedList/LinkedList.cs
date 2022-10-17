using System.Collections;

namespace Collections
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private LinkedListItem<T>? _head;
        private int _count = 0;

        public LinkedListItem<T>? First => _head;
        public LinkedListItem<T>? Last => _head?.Prev;

        public int Count => _count;

        public void Add(T item)
        {
            AppendLast(item);
        }

        public T this[int index] 
        { 
            get => GetNode(index).Value; 
            set => GetNode(index).Value = value; 
        }

        public LinkedListItem<T> AppendFirst(T item)
        {
            LinkedListItem<T> result = new(item);
            if (_head == null)
            {
                InsertNodeEmptyList(result);
            }
            else
            {
                InsertNodeBefore(_head, result);
                _head = result;
            }
            return result;
        }

        public LinkedListItem<T> AppendLast(T item)
        {
            LinkedListItem<T> result = new(this, item);
            if (_head == null)
            {
                InsertNodeEmptyList(result);
            }
            else
            {
                InsertNodeBefore(_head, result);
            }
            return result;
        }

        public LinkedListItem<T> AppendBefore(LinkedListItem<T> node, T item)
        {
            ValidateNode(node);
            LinkedListItem<T> result = new(this, item);
            InsertNodeBefore(node, result);
            if (node == _head)
                _head = result;
            return result;
        }

        public LinkedListItem<T> AppendAfter(LinkedListItem<T> node, T item)
        {
            ValidateNode(node);
            LinkedListItem<T> result = new(item);
            InsertNodeBefore(node.Next!, result);
            return result;
        }

        public LinkedListItem<T>? Find(T item)
        {
            return FindNode(item, out _);
        }

        public void Remove(T item)
        {
            LinkedListItem<T>? node = Find(item);
            Remove(node!);
        }

        public void Remove(LinkedListItem<T> node)
        {
            ValidateNode(node);
            if (node == node.Next)
            {
                _head = null;
            }
            else
            {
                node.Next!.Prev = node.Prev;
                node.Prev!.Next = node.Next;
                if (_head == node)
                    _head = node.Next;
            }
            node.Reset();
            _count--;
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public LinkedListItem<T> GetNode(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();
            LinkedListItem<T> node = _head!;
            while (index > 0)
            {
                node = node.Next!;
                index--;
            }
            return node;
        }

        public int IndexOf(T item)
        {
            FindNode(item, out int result);
            return result;
        }

        public void Reverse()
        {
            if (_head == null)
                return;
            _head = _head.Prev!;
            LinkedListItem<T> currentNode = _head;
            LinkedListItem<T> prevNode = _head.Prev!;
            do
            {
                currentNode.Prev = currentNode.Next;
                currentNode.Next = prevNode;
                prevNode = prevNode.Prev!; 
                currentNode = currentNode.Next;
            } while (currentNode != _head);
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_head == null)
                yield break;
            LinkedListItem<T> node = _head;
            do
            {
                yield return node.Value!;
                node = node.Next!;
            } while (node != _head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", this)}]";
        }

        protected void ValidateNode(LinkedListItem<T> node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));
            if (node.List != this)
                throw new InvalidOperationException("This node from another list");
        }

        private void InsertNodeEmptyList(LinkedListItem<T> newNode)
        {
            newNode.Next = newNode;
            newNode.Prev = newNode;
            _head = newNode;
            _count++;
        }

        private void InsertNodeBefore(LinkedListItem<T> node, LinkedListItem<T> newNode)
        {
            newNode.Next = node;
            newNode.Prev = node.Prev;
            node.Prev!.Next = newNode;
            node.Prev = newNode;
            _count++;
        }

        private LinkedListItem<T>? FindNode(T item, out int index)
        {
            index = -1;
            if (_head == null)
                return null;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            LinkedListItem<T> node = _head;
            do
            {
                index++;
                if (comparer.Equals(node.Value, item))
                    return node;
                node = node.Next!;
            } while (node != _head);
            index = -1;
            return null;
        }
    }
}
