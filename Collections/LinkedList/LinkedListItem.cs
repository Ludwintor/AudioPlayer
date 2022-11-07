namespace Collections
{
    /// <summary>
    /// Represents linked list node
    /// </summary>
    /// <typeparam name="T">Type to store in node</typeparam>
    public class LinkedListItem<T>
    {
        /// <summary>
        /// Creates new node for linked list
        /// </summary>
        /// <param name="value">value to store</param>
        public LinkedListItem(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Creates new node for provided linked list
        /// </summary>
        /// <param name="list">list in which node will be contained</param>
        /// <param name="value">value to store</param>
        internal LinkedListItem(LinkedList<T> list, T value) : this(value)
        {
            List = list;
        }

        /// <summary>
        /// Stored value
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Next node in a linked list
        /// </summary>
        public LinkedListItem<T>? Next { get; internal set; }

        /// <summary>
        /// Previous node in a linked list
        /// </summary>
        public LinkedListItem<T>? Prev { get; internal set; }

        /// <summary>
        /// Linked list associated with this node
        /// </summary>
        internal LinkedList<T>? List { get; set; }

        /// <summary>
        /// Invalidates node
        /// </summary>
        internal void Reset()
        {
            List = null;
            Next = null;
            Prev = null;
        }
    }
}
