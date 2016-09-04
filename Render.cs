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
    class Render : GameWindow
    {
        Plane floor = new Plane();
        Vec[] flsize = new Vec[4];
        int xres, yres;
        double rquad=0;

        public Render(int wid, int hei) : base(wid,hei)
        {
            xres = wid;
            yres = hei;

            flsize[0] = new Vec();
            flsize[1] = new Vec();
            flsize[2] = new Vec();
            flsize[3] = new Vec();

            flsize[0].x = -1000000;
            flsize[0].y = 0.2;
            flsize[0].z = -1000000;

            flsize[1].x = 1000000;
            flsize[1].y = 0.2;
            flsize[1].z = -1000000;
        
            flsize[2].x = 1000000;
            flsize[2].y = 0.2;
            flsize[2].z = 1000000;

            flsize[3].x = -1000000;
            flsize[3].y = 0.2;
            flsize[3].z = 1000000;


            floor.redraw(flsize[0], flsize[1], flsize[2], flsize[3]);
        }

        // ///////////////////////////////////////////////////////////////////////////////////
        private void init()
        {
            GL.ShadeModel(ShadingModel.Smooth);                              // enable smooth shading
            GL.ClearColor(Color.Black);                    // black background
            GL.ClearDepth(1.0f);                                      // depth buffer setup
            GL.Enable(EnableCap.DepthTest);                              // enables depth testing
            GL.DepthFunc(DepthFunction.Lequal);                               // type of depth testing
            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);	// nice perspective calculations
        }

        // ///////////////////////////////////////////////////////////////////////////////////
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        // ///////////////////////////////////////////////////////////////////////////////////
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        // ///////////////////////////////////////////////////////////////////////////////////
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4.Perspective(45.0f, (float)xres / (float)yres, 0.01f, 10000.0f);
            //Matrix4.CreatePerspectiveFieldOfView(45.0f, (float)xres / (float)yres, 0.1f, 100.0f);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
        }

        // ///////////////////////////////////////////////////////////////////////////////////
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            init();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.ClearColor(Color.Black);


            GL.LoadIdentity();                            // reset the current modelview matrix
            //GL.PushMatrix();
            //GL.Translate(0, 0, -0.50f);             // move 1.5 Units right and 6 Units into the screen
            GL.Rotate(rquad, 1.0f, 1.0f, 0.0f);              // rotate the triangle on the X-axis
            rquad -= 0.15;                // decrease the rotation variable 
            GL.Color3(0.5f, 0.5f, 1.0f);                 // blue 
            GL.Begin(PrimitiveType.Quads);                        // start drawing a quad
            GL.Vertex3(-1.0f, 1.0f, 0.0f);               // top left of the quad
            GL.Vertex3(1.0f, 1.0f, 0.0f);                // top right of the quad
            GL.Vertex3(1.0f, -1.0f, 0.0f);               // bottom right of the quad
            GL.Vertex3(-1.0f, -1.0f, 0.0f);              // bottom left of the quad
            GL.End();
            

            this.SwapBuffers();
        }
    }
}
