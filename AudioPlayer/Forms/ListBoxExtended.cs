namespace AudioPlayer.Forms
{
    public class ListBoxExtended : ListBox
    {

        private readonly SolidBrush _brush = new(Color.White);
        private readonly Dictionary<int, Color> _overridenColors = new();

        public ListBoxExtended()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
        }

        public void OverrideColor(int index, Color color)
        {
            _overridenColors[index] = color;
            Invalidate();
        }

        public void ClearColor(int index)
        {
            _overridenColors.Remove(index);
            Invalidate();
        }

        public void ClearAllColors()
        {
            _overridenColors.Clear();
            Invalidate();
        }

        public void MoveItem(int index, int direction)
        {
            if (index < 0 || index >= Items.Count)
                throw new IndexOutOfRangeException();
            int newIndex = Math.Clamp(index + direction, 0, Items.Count - 1);
            if (index == newIndex)
                return;
            SwapColors(index, newIndex);
            object item = Items[index];
            Items.RemoveAt(index);
            Items.Insert(newIndex, item);
            SetSelected(newIndex, true);
        }

        public void MoveItemUp(int index) => MoveItem(index, -1);
        public void MoveItemDown(int index) => MoveItem(index, 1);

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index == -1)
                return;
            e.DrawBackground();

            Color color = _overridenColors.ContainsKey(e.Index) ? _overridenColors[e.Index] : ForeColor;
            _brush.Color = e.State.HasFlag(DrawItemState.Selected) ? Color.FromArgb(color.ToArgb() ^ 0xFFFFFF) : color;
            PointF point = new(e.Bounds.X, e.Bounds.Y);
            e.Graphics.DrawString(Items[e.Index].ToString(), e.Font!, _brush, point);

            e.DrawFocusRectangle();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (IndexFromPoint(e.Location) == -1)
                SelectedIndex = -1;
            base.OnMouseClick(e);
        }

        private void SwapColors(int index, int otherIndex)
        {
            if (_overridenColors.TryGetValue(index, out Color color))
            {
                if (_overridenColors.TryGetValue(otherIndex, out Color newColor))
                    _overridenColors[index] = newColor;
                else
                    _overridenColors.Remove(index);
                _overridenColors[otherIndex] = color;
            }
            else if (_overridenColors.TryGetValue(otherIndex, out color))
            {
                _overridenColors[index] = color;
                _overridenColors.Remove(otherIndex);
            }
        }
    }
}
