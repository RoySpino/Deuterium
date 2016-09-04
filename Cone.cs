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
    class Cone
    {
        double[] apex = new double[3], 
                 Base = new double[3];
        double rad, x, y, z,
                rx, ry, rz;
        int[] col_ = new int[4];
        List<double> vert;
        List<double> norm;
        int rez;

        public Cone()
        {
            redraw(0, 24, 0, 5, 24);
        }

        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void redraw(double ax, double ay, double az, double Rad, int Rez)
        {
            vert.Clear();

            rez = Rez;
            rad = Rad;
            apex[0] = ax;
            apex[1] = ay;
            apex[2] = az;

            col_[0] = 255;
            col_[1] = 255;
            col_[2] = 255;
            col_[3] = 70;

            setBase();
            setNormals();
        }

        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void setBase()
        {
            if (rad == 0)
                rad = 3;

            // get increment angle
            double angle = (6.28318531) / rez;

            // from incrimint agle trace along a circle
            for (int i = 0; i < rez; i++)
            {
                vert.Add(Math.Sin(angle * i) * rad);
                vert.Add(0);
                vert.Add(Math.Cos(angle * i) * rad);

                vert.Add(Math.Sin(angle * (i + 1)) * rad);
                vert.Add(0);
                vert.Add(Math.Cos(angle * (i + 1)) * rad);

                vert.Add(apex[0]);
                vert.Add(apex[1]);
                vert.Add(apex[2]);
            }
        }

        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void setNormals()
        {
            if (rad == 0)
                rad = 3;

            double[] c1 = new double[3],
                     c2 = new double[3];
            for (int i = 0; i < rez - 1; i++)
            {
                c1[0] = vert[(i * 3) + 0];
                c1[1] = vert[(i * 3) + 1];
                c1[2] = vert[(i * 3) + 2];

                c2[0] = vert[(i * 3) + 3];
                c2[1] = vert[(i * 3) + 4];
                c2[2] = vert[(i * 3) + 5];

                i += 3;
                calculateNormal(apex, c1, c2);
            }
        }

        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void draw()
        {
            GL.PushMatrix();

            GL.EnableClientState(ArrayCap.VertexArray);   // Enable vertex arrays
            //GLEnableClientState(ArrayCap.NormalArray);	// Enable normal arrays

            GL.Translate(x, y, z);

            GL.Rotate(rx, 1.0f, .0f, .0f);      // Rotate On The X axis 
            GL.Rotate(ry, .0f, 1.0f, .0f);      // Rotate On The Y axis 
            GL.Rotate(rz, .0f, .0f, 1.0f);      // Rotate On The Z axis 
            
            GL.Color3(Color.FromArgb(col_[0], col_[1], col_[2], col_[3]));
            // Vertex Pointer to triangle array
            GL.VertexPointer(3,VertexPointerType.Double, 0, vert.ToArray());
            // Normal pointer to normal array
            //glNormalPointer(GL_FLOAT, 0, norm.data());
            // Draw the triangles
            GL.DrawArrays(BeginMode.Triangles, 0, (rez * 3));
            GL.DisableClientState(ArrayCap.VertexArray);  // Disable vertex arrays
                                                    //glDisableClientState(GL_NORMAL_ARRAY);	// Disable normal arrays

            GL.PopMatrix();
        }
        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void calculateNormal(double[] coord1, double[] coord2, double[] coord3)
        {
            double[] va = new double[3],
                     vb = new double[3],
                     vr = new double[3];
            double val;

            va[0] = coord1[0] - coord2[0];
            va[1] = coord1[1] - coord2[1];
            va[2] = coord1[2] - coord2[2];

            vb[0] = coord1[0] - coord3[0];
            vb[1] = coord1[1] - coord3[1];
            vb[2] = coord1[2] - coord3[2];

            // cross product 
            vr[0] = va[1] * vb[2] - vb[1] * va[2];
            vr[1] = vb[0] * va[2] - va[0] * vb[2];
            vr[2] = va[0] * vb[1] - vb[0] * va[1];

            // normalization factor
            val = Math.Sqrt(vr[0] * vr[0] + vr[1] * vr[1] + vr[2] * vr[2]);

            norm.Add(vr[0] / val);
            norm.Add(vr[1] / val);
            norm.Add(vr[2] / val);

            return;
        }
        // ////////////////////////////////////////////////////////////////////////////
        public void loc(double ax, double ay, double az)
        {
            x = ax;
            y = ay;
            z = az;
        }
        // ////////////////////////////////////////////////////////////////////////////
        public void rot(double ax, double ay, double az)
        {
            rx = ax;
            ry = ay;
            rz = az;
        }
        // ///////////////////////////////////////////////////////////////////////////////////////////////
        public void setColor(int R, int G, int B)
        {
            col_[0] = R;// / 255.0;
            col_[1] = G;// / 255.0;
            col_[2] = B;// / 255.0;
        }
    }
}
