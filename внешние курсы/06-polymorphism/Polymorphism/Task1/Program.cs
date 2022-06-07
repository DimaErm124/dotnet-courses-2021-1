using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            FigureDrawer drawer = new ConsoleFigureDrawer();

            Figure[] figures = new Figure[] {new Line(1,2,3,4),
                                             new Circle(1,4,5),
                                             new Round(2,3,4),
                                             new Ring(4,5,8,4),
                                             new Rectangle(5,1,6,3)};
            DrawFigures(figures, drawer);
            
        }

        public static void DrawFigures(Figure[] figures, FigureDrawer drawer)
        {
            for(int i = 0; i < figures.Length; i++)
            {
                figures[i].Draw(drawer);
            }
        }
    }
}
