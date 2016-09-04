using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace Deuterium
{
    class Plane
    {
        List<double> virt = new List<double>();

        public Plane()
        {
            virt.AddRange(new double[] { 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0 });

        }

        // /////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void redraw(double llx, double lly, double llz,
                           double lrx, double lry, double lrz,
                           double urx, double ury, double urz,
                           double ulx, double uly, double ulz)
        {
            virt.Clear();
            virt.AddRange(new double[] { llx, lly, llz,
                                         lrx, lry, lrz,
                                         urx, ury, urz,
                                         ulx, uly, ulz });
        }
        // /////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void redraw(double[] ll, double[] lr, double[] ur, double[] ul)
        {
            virt.Clear();
            virt.AddRange(new double[] { ll[0], ll[1], ll[2],
                                         lr[0], lr[1], lr[2],
                                         ur[0], ur[1], ur[2],
                                         ul[0], ul[1], ul[2] });
        }
        // /////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void redraw(Vec ll, Vec lr, Vec ur, Vec ul)
        {
            virt.Clear();
            virt.AddRange(new double[] { ll.x, ll.y, ll.z,
                                         lr.x, lr.y, lr.z,
                                         ur.x, ur.y, ur.z,
                                         ul.x, ul.y, ul.z });
        }
    }
}
