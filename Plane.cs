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
        int[] col_ = new int[3];
        double x, y, z, rx, ry, rz;

        public Plane()
        {
            virt.AddRange(new double[] { 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0 });
            x = y = z = 0;
            rx = ry = rz = 0;
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

        // /////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void draw()
        {
            GL.PushMatrix();


            GL.EnableClientState(ArrayCap.VertexArray);   // Enable vertex arrays
            GL.EnableClientState(ArrayCap.NormalArray);   // Enable normal arrays
                                                          //glFrontFace(GL_CCW);

            GL.Color3(Color.FromArgb(col_[0], col_[1], col_[2]));
            GL.Translate(x, y, z);
            GL.Rotate(rx, 1.0f, .0f, .0f);      // Rotate On The X axis 
            GL.Rotate(ry, .0f, 1.0f, .0f);      // Rotate On The Y axis 
            GL.Rotate(rz, .0f, .0f, 1.0f);      // Rotate On The Z axis 

            GL.VertexPointer(3, VertexPointerType.Double, 0, virt.ToArray());
            // Normal pointer to normal array
            GL.NormalPointer(NormalPointerType.Double, 0, virt.ToArray());
            // setup Color
            //glColorPointer(3, GL_UNSIGNED_BYTE, 0, &col[0]);
            // Draw the triangles
            GL.DrawArrays(BeginMode.Triangles, 0, 2);

            GL.DisableClientState(ArrayCap.VertexArray);  // Disable vertex arrays
            GL.DisableClientState(ArrayCap.NormalArray);  // Disable normal arrays

            GL.PopMatrix();
        }

        // /////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void rot(double x, double y, double z)
        {
            rx = x;
            ry = y;
            rz = z;
        }

        // /////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void loc(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        // /////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void setColor(int R, int G, int B)
        {
            col_[0] = R % 256;
            col_[1] = G % 256;
            col_[2] = B % 256;
        }
    }
}
