using System;

namespace Vector
{
    public class ThreeDimensionalVector
    {
        public double X { get; private set; }

        public double Y { get; private set; }

        public double Z { get; private set; }

        public ThreeDimensionalVector(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            X = x2 - x1;
            Y = y2 - y1;
            Z = z2 - z1;
        }

        public ThreeDimensionalVector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static ThreeDimensionalVector operator +(ThreeDimensionalVector vectorA, ThreeDimensionalVector vectorB)
        {
            if (vectorA is null)
                return vectorB;

            if (vectorB is null)
                return vectorA;

            return new ThreeDimensionalVector(vectorA.X + vectorB.X,
                                              vectorA.Y + vectorB.Y,
                                              vectorA.Z + vectorB.Z);
        }

        public static ThreeDimensionalVector operator -(ThreeDimensionalVector vectorA, ThreeDimensionalVector vectorB)
        {
            if (vectorB is null)
                return vectorA;

            if (vectorA is null)
                return new ThreeDimensionalVector(-vectorB.X,
                                                  -vectorB.Y,
                                                  -vectorB.Z);

            return new ThreeDimensionalVector(vectorA.X - vectorB.X,
                                              vectorA.Y - vectorB.Y,
                                              vectorA.Z - vectorB.Z);
        }

        public static double operator *(ThreeDimensionalVector vectorA, ThreeDimensionalVector vectorB)
        {
            if (vectorA is null )
                throw new ArgumentNullException("Vector A is null argument!");

            if (vectorB is null)
                throw new ArgumentNullException("Vector B is null argument!");

            return vectorA.X * vectorB.X 
                + vectorA.Y * vectorB.Y 
                + vectorA.Z * vectorB.Z;
        }

        public static ThreeDimensionalVector operator &(ThreeDimensionalVector vectorA, ThreeDimensionalVector vectorB)
        {
            if (vectorA is null)
                throw new ArgumentNullException("Vector A is null argument!");

            if (vectorB is null)
                throw new ArgumentNullException("Vector B is null argument!");

            return new ThreeDimensionalVector(vectorA.Y * vectorB.Z - vectorA.Z * vectorB.Y,
                                              vectorA.Z * vectorB.X - vectorA.X * vectorB.Z,
                                              vectorA.X * vectorB.Y - vectorA.Y * vectorB.X);
        }

        public static bool operator ==(ThreeDimensionalVector vectorA, ThreeDimensionalVector vectorB)
        {
            if (vectorA is null)
                return vectorB is null;

            if (vectorB is null)
                return vectorA is null;

            return vectorA.Equals(vectorB);
        }

        public static bool operator !=(ThreeDimensionalVector vectorA, ThreeDimensionalVector vectorB)
        {
            return !(vectorA == vectorB);
        }

        public override bool Equals(object vector)
        {
            if (vector is null)
            {
                return false;
            }

            return this.X == ((ThreeDimensionalVector)vector).X
                && this.Y == ((ThreeDimensionalVector)vector).Y
                && this.Z == ((ThreeDimensionalVector)vector).Z;
        }

        public override int GetHashCode()
        {
            return ((X + Y) - (Y / Z)).GetHashCode();
        }

        public override string ToString()
        {
            return $"({X},{Y},{Z})";
        }
    }
}