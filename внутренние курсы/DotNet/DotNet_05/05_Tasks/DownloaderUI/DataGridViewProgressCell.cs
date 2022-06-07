using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DownloaderUI
{
    class DataGridViewProgressCell : DataGridViewImageCell
    {

        private static Image emptyImage;

        private static Color _progressBarColor = Color.Indigo;
        private static Color _boundColor = Color.DarkGray;
        private static Color _fieldColor = Color.WhiteSmoke;

        public Color ProgressBarColor
        {
            get { return _progressBarColor; }
            set { _progressBarColor = value; }
        }

        static DataGridViewProgressCell()
        {
            emptyImage = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }

        public DataGridViewProgressCell()
        {
            ValueType = typeof(int);
        }

        protected override object GetFormattedValue(object value,
            int rowIndex, ref DataGridViewCellStyle cellStyle,
            TypeConverter valueTypeConverter,
            TypeConverter formattedValueTypeConverter,
            DataGridViewDataErrorContexts context)
        {
            return emptyImage;
        }

        protected override void Paint(System.Drawing.Graphics g,
            System.Drawing.Rectangle clipBounds,
            System.Drawing.Rectangle cellBounds,
            int rowIndex,
            DataGridViewElementStates cellState,
            object value, object formattedValue,
            string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            int progressVal = (int)value;

            float percentage = (progressVal / 100.0f);

            base.Paint(g, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts & ~DataGridViewPaintParts.ContentForeground);

            if (percentage >= 0.0 && percentage < 1.0)
            {
                DrawProgress(_progressBarColor, g, cellBounds, percentage);
            }
            else if (percentage == 1.0)
            {
                DrawProgress(Color.DarkCyan, g, cellBounds, percentage);
            }
        }

        private void DrawProgress(Color progressColor, Graphics g, Rectangle cellBounds, float percentage)
        {
            int indentBoundX = 3;
            int indentBoundY = 2;

            int indentFieldX = 5;
            int indentFieldY = 4;

            int indentProgressX = 5;
            int indentProgressY = 4;

            DrawRectangleInProgressBar(_boundColor, g, cellBounds, indentBoundX, indentBoundY, 1);
            DrawRectangleInProgressBar(_fieldColor, g, cellBounds, indentFieldX, indentFieldY, 1);
            DrawRectangleInProgressBar(progressColor, g, cellBounds, indentProgressX, indentProgressY, percentage);
        }

        private void DrawRectangleInProgressBar(Color color, Graphics g, Rectangle cellBounds, int indentX, int indentY, float percentage)
        {
            g.FillRectangle(new SolidBrush(color), cellBounds.X + indentX, cellBounds.Y + indentY, Convert.ToInt32(percentage * cellBounds.Width - (indentX * 2)), cellBounds.Height - (indentY * 2 + 1));
        }

        public override object Clone()
        {
            DataGridViewProgressCell dataGridViewCell = base.Clone() as DataGridViewProgressCell;
            if (dataGridViewCell != null)
            {
                dataGridViewCell.ProgressBarColor = ProgressBarColor;
            }
            return dataGridViewCell;
        }

        internal void SetProgressBarColor(int rowIndex, Color value)
        {
            ProgressBarColor = value;
        }

    }
}