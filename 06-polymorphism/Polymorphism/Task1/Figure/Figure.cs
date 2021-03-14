namespace Task1
{
    public abstract class Figure
    {
        public double X;

        public double Y;        

        public Figure(double x, double y)
        {
            X = x;
            Y = y;
        }
        
        public virtual string GetPicture()
        {
            return "Type: " + this.GetType().Name + "\n"
                + "X: " + X + "\n"
                + "Y: " + Y + "\n";
        }

        public abstract void Draw(FigureDrawer drawer);
        
    }
}
