using System;

namespace Task1
{
    public class Line : Figure
    {
        public double X1;

        public double Y1;

        public double Length { get { return Math.Sqrt(Math.Pow((X1 - X), 2) + Math.Pow((Y1 - Y), 2)); } }

        public Line(double x0, double y0, double x1, double y1) : base(x0, y0)
        {
            X1 = x1;
            Y1 = y1;
        }

        public override string GetPicture()
        {
            return base.GetPicture()
                + "X1: " + X1 + "\n"
                + "Y1: " + Y1 + "\n";
        }
        public override void Draw(FigureDrawer drawer)
        {
            drawer.Draw(this);
        }
    }
}
