using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deuterium
{
    class Program
    {
        static void Main(string[] args)
        {
            Render deut = new Render(640, 400);
            deut.X = 100;
            deut.Y = 100;
            deut.Title = "Deuterium";
            deut.Run();
        }
    }
}
