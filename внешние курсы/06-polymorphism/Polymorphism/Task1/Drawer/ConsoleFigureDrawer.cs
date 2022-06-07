using System;

namespace Task1
{
    public class ConsoleFigureDrawer : FigureDrawer
    {
        public override void Draw(Figure figure)
        {
            Console.WriteLine(figure.GetPicture());
        }
    }
}
