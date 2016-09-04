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
    class Cube
    {
        double height, width, x, y, z,
            rx, ry, rz,
            PI = 3.141592653589793238462643;
        int[] col_;
        List<double> virt = new List<double>();
        List<double> nor = new List<double>();
        List<Vec> v = new List<Vec>();

        public Cube()
        {
            height = 1;
            width = 1;
            resize(height, width);
            col_[0] = col_[1] = col_[2] = 0;
            x = y = z = 0;
        }

        // ///////////////////////////////////////////////////////////////////////////////////
        public Cube(double h, double w)
        {
            height = h;
            width = w;
            resize(height, width);
            col_[0] = col_[1] = col_[2] = 0;
            x = y = z = 0;
        }

        // ///////////////////////////////////////////////////////////////////////////////////
        private void resize(double h, double w)
        {
            virt.Clear();
            v.Clear();
            Vec tmp = new Vec();
            double x, y, z;
            height = h;
            width = w;

            // normals
            for (int i = 0; i < 12; i++)
            {
                y = (i < 6 || i > 30) ? 1 : 0;
                y *= (i < 18) ? 1 : -1;

                x = (i >= 6 || i < 18) ? 1 : 0;
                x *= (i < 18) ? 1 : -1;

                z = (i >= 12 && i < 24) ? 1 : 0;
                z *= (i < 18) ? 1 : -1;

                nor.Add(x);
                nor.Add(y);
                nor.Add(z);
            }

            // create bottom side of the cube
            virt.Add(tmp.x = .5 * w);
            virt.Add(tmp.y = 0);
            virt.Add(tmp.z = .5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = -.5 * w);
            virt.Add(tmp.y = 0);
            virt.Add(tmp.z = .5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = -.5 * w);
            virt.Add(tmp.y = 0);
            virt.Add(tmp.z = -.5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = .5 * w);
            virt.Add(tmp.y = 0);
            virt.Add(tmp.z = .5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = -.5 * w);
            virt.Add(tmp.y = 0);
            virt.Add(tmp.z = -.5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = .5 * w);
            virt.Add(tmp.y = 0);
            virt.Add(tmp.z = -.5 * w);
            v.Add(tmp);


            // create right side of the cube
            virt.Add(tmp.x = .5 * w);
            virt.Add(tmp.y = h);
            virt.Add(tmp.z = .5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = .5 * w);
            virt.Add(tmp.y = 0);
            virt.Add(tmp.z = .5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = .5 * w);
            virt.Add(tmp.y = 0);
            virt.Add(tmp.z = -.5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = .5 * w);
            virt.Add(tmp.y = h);
            virt.Add(tmp.z = .5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = .5 * w);
            virt.Add(tmp.y = 0);
            virt.Add(tmp.z = -.5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = .5 * w);
            virt.Add(tmp.y = h);
            virt.Add(tmp.z = -.5 * w);
            v.Add(tmp);


            // create front side of the cube
            virt.Add(tmp.x = .5 * w);
            virt.Add(tmp.y = 0);
            virt.Add(tmp.z = .5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = -.5 * w);
            virt.Add(tmp.y = 0);
            virt.Add(tmp.z = .5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = -.5 * w);
            virt.Add(tmp.y = h);
            virt.Add(tmp.z = .5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = -.5 * w);
            virt.Add(tmp.y = h);
            virt.Add(tmp.z = .5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = .5 * w);
            virt.Add(tmp.y = h);
            virt.Add(tmp.z = .5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = .5 * w);
            virt.Add(tmp.y = 0);
            virt.Add(tmp.z = .5 * w);
            v.Add(tmp);

            // create left side of the cube
            virt.Add(tmp.x = -.5 * w);
            virt.Add(tmp.y = 0);
            virt.Add(tmp.z = -.5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = -.5 * w);
            virt.Add(tmp.y = h);
            virt.Add(tmp.z = -.5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = -.5 * w);
            virt.Add(tmp.y = 0);
            virt.Add(tmp.z = .5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = -.5 * w);
            virt.Add(tmp.y = h);
            virt.Add(tmp.z = -.5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = -.5 * w);
            virt.Add(tmp.y = h);
            virt.Add(tmp.z = .5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = -.5 * w);
            virt.Add(tmp.y = 0);
            virt.Add(tmp.z = .5 * w);
            v.Add(tmp);

            // create back side of the cube
            virt.Add(tmp.x = .5 * w);
            virt.Add(tmp.y = h);
            virt.Add(tmp.z = -.5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = -.5 * w);
            virt.Add(tmp.y = 0);
            virt.Add(tmp.z = -.5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = .5 * w);
            virt.Add(tmp.y = 0);
            virt.Add(tmp.z = -.5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = .5 * w);
            virt.Add(tmp.y = h);
            virt.Add(tmp.z = -.5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = -.5 * w);
            virt.Add(tmp.y = h);
            virt.Add(tmp.z = -.5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = -.5 * w);
            virt.Add(tmp.y = 0);
            virt.Add(tmp.z = -.5 * w);
            v.Add(tmp);


            // create Top side of the cube
            virt.Add(tmp.x = .5 * w);
            virt.Add(tmp.y = h);
            virt.Add(tmp.z = .5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = -.5 * w);
            virt.Add(tmp.y = h);
            virt.Add(tmp.z = .5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = -.5 * w);
            virt.Add(tmp.y = h);
            virt.Add(tmp.z = -.5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = .5 * w);
            virt.Add(tmp.y = h);
            virt.Add(tmp.z = .5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = -.5 * w);
            virt.Add(tmp.y = h);
            virt.Add(tmp.z = -.5 * w);
            v.Add(tmp);

            virt.Add(tmp.x = .5 * w);
            virt.Add(tmp.y = h);
            virt.Add(tmp.z = -.5 * w);
            v.Add(tmp);
        }
        // //////////////////////////////////////////////////////////////////////////||////////////////////
        void draw()
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

            GL.VertexPointer(3,VertexPointerType.Double, 0, virt.ToArray());
            // Normal pointer to normal array
            GL.NormalPointer(NormalPointerType.Double, 0, virt.ToArray());
            // setup Color
            //glColorPointer(3, GL_UNSIGNED_BYTE, 0, &col[0]);
            // Draw the triangles
            GL.DrawArrays(BeginMode.Triangles, 0, 36);

            GL.DisableClientState(ArrayCap.VertexArray);  // Disable vertex arrays
            GL.DisableClientState(ArrayCap.NormalArray);  // Disable normal arrays

            GL.PopMatrix();
        }
        // ///////////////////////////////////////////////////////////////////////////////////////////////
        void setColor(int R, int G, int B)
        {
            col_[0] = R;// / 255.0;
            col_[1] = G;// / 255.0;
            col_[2] = B;// / 255.0;
        }
        // ///////////////////////////////////////////////////////////////////////////////////////////////
        void rot(double x, double y, double z)
        {
            rx = (x * PI) / 180;
            ry = (y * PI) / 180;
            rz = (z * PI) / 180;
        }
    }
}
