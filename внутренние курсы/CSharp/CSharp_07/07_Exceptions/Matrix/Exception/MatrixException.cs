using System;
using System.Runtime.Serialization;

namespace Matrix
{
    [Serializable]
    public class MatrixException : Exception
    {
        public int RowCount { get; private set; }

        public int ColumnCount { get; private set; }

        public MatrixException()
        {
        }

        public MatrixException(string message, int m, int n) : base(message)
        {
            RowCount = m;
            ColumnCount = n;
        }

        public MatrixException(string message, Exception innerException, int m, int n) : base(message, innerException)
        {
            RowCount = m;
            ColumnCount = n;
        }

        protected MatrixException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            if (info != null)
            {
                this.RowCount = Int32.Parse(info.GetString(nameof(RowCount)));
                this.ColumnCount = Int32.Parse(info.GetString(nameof(ColumnCount)));
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(nameof(RowCount), this.RowCount);
            info.AddValue(nameof(ColumnCount), this.ColumnCount);
        }
    }
}