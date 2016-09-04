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
            deut.Run();
        }
    }
}
