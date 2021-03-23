using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
			var points = new TwoDPoint[] { 
				new TwoDPoint(1, 1),
				new TwoDPoint(10, 10), 
				new TwoDPoint(10, 1), 
				new TwoDPoint(1, 10), 
				new TwoDPoint(1, 1) };

			Compare(points);
        }
		
		public static void Compare(TwoDPoint[] points)
        {
			for(int i = 0; i < points.Length; i++)
            {
				for (int j = i + 1; j < points.Length; j++)
                {
					Console.WriteLine("{0} == {1} ( {2} )",
                       points[i],
                       points[j],
                       points[i].GetHashCode() == points[j].GetHashCode());
                }
            }
        }
    }

	class TwoDPoint : Object
	{
		public readonly int x, y;

		public TwoDPoint(int x, int y)  //constructor
		{
			this.x = x;
			this.y = y;
		}

		public override bool Equals(Object obj)
		{
			// If parameter is null return false.
			if (obj == null)
			{
				return false;
			}

			// If parameter cannot be cast to Point return false.
			TwoDPoint p = obj as TwoDPoint;
			if ((Object)p == null)
			{
				return false;
			}

			// Return true if the fields match:
			return (x == p.x) && (y == p.y);
		}

		public bool Equals(TwoDPoint p)
		{
			// If parameter is null return false:
			if ((object)p == null)
			{
				return false;
			}

			// Return true if the fields match:
			return (x == p.x) && (y == p.y);
		}

		public static bool operator ==(TwoDPoint a, TwoDPoint b)
		{
			// If both are null, or both are same instance, return true.
			if (ReferenceEquals(a, b))
			{
				return true;
			}

			// If one is null, but not both, return false.
			if (((object)a == null) || ((object)b == null))
			{
				return false;
			}

			// Return true if the fields match:
			return a.x == b.x && a.y == b.y;
		}

		public static bool operator !=(TwoDPoint a, TwoDPoint b)
		{
			return !(a == b);
		}

		public override string ToString()
		{
			return string.Format("x:{0} y:{1}", x, y);
		}

        public override int GetHashCode()
        {
			return Tuple.Create(x, y).GetHashCode();
        }
    }

}
