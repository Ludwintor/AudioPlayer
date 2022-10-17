using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer.Forms
{
    public class ListBoxColored : ListBox
    {

        private readonly SolidBrush _brush = new(Color.White);
        private readonly Dictionary<int, Color> _overridenColors = new();

        public ListBoxColored()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
        }

        public void OverrideColor(int index, Color color)
        {
            if (!_overridenColors.TryAdd(index, color))
                _overridenColors[index] = color;
            Refresh();
        }

        public void ClearColor(int index)
        {
            _overridenColors.Remove(index);
            Refresh();
        }

        public void ClearAllColors()
        {
            _overridenColors.Clear();
            Refresh();
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();

            Color color = _overridenColors.ContainsKey(e.Index) ? _overridenColors[e.Index] : ForeColor;
            _brush.Color = e.State.HasFlag(DrawItemState.Selected) ? Color.FromArgb(color.ToArgb() ^ 0xFFFFFF) : color;
            PointF point = new(e.Bounds.X, e.Bounds.Y);
            e.Graphics.DrawString(Items[e.Index].ToString(), e.Font!, _brush, point);

            e.DrawFocusRectangle();
        }
    }
}
