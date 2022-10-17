using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer.Extensions
{
    public static class ListBoxExtensions
    {
        public static void MoveItemUp(this ListBox list, int index) => list.MoveItem(index, -1);
        public static void MoveItemDown(this ListBox list, int index) => list.MoveItem(index, 1);

        private static void MoveItem(this ListBox list, int index, int direction)
        {
            if (index < 0 || index >= list.Items.Count)
                throw new IndexOutOfRangeException();
            int newIndex = index + direction;
            if (newIndex < 0 || newIndex >= list.Items.Count)
                return;

            object item = list.Items[index];
            list.Items.RemoveAt(index);
            list.Items.Insert(newIndex, item);
            list.SetSelected(newIndex, true);
        }
    }
}
