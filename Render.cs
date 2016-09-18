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
        Cube cub = new Cube();
        Vec[] flsize = new Vec[4];
        float[] spec = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
        float[] shine = new float[] { 50.0f };
        float[] lightPos = new float[] { 1.0f, 1.0f, 1.0f, 0.0f };
        float[] ambiant = new float[] { 0.1484f, 0.0f, 0.5781f };
        float aspect;
        int xres, yres;
        Matrix4 lookat;
        double rtri = 0;
        double fl = 20000.0;

        public Render(int wid, int hei) : base(wid, hei)
        {
            xres = wid;
            yres = hei;

            cub.setColor(100, 0, 0);

            /*
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
            */

            //floor.redraw(flsize[0], flsize[1], flsize[2], flsize[3]);
            aspect = wid / hei;
        }

        // ///////////////////////////////////////////////////////////////////////////////////
        private void init()
        {
            GL.Enable(EnableCap.DepthTest);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
        }

        // ///////////////////////////////////////////////////////////////////////////////////
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            init();
        }

        // ///////////////////////////////////////////////////////////////////////////////////
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            var keyboard = OpenTK.Input.Keyboard.GetState();
            if (keyboard[OpenTK.Input.Key.Escape])
            {
                this.Exit();
            }
        }

        // ///////////////////////////////////////////////////////////////////////////////////
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(ClientRectangle);
            Matrix4 projection_matrix;
            Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, aspect, 0.0001f, 640000, out projection_matrix);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection_matrix);

            xres = X;
            yres = Y;
        }

        // ///////////////////////////////////////////////////////////////////////////////////
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();
            Display2D();


            GL.Disable(EnableCap.Texture2D);
            GL.LoadIdentity();
            GL.PushMatrix();
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.FromArgb(22, 86, 70));
            GL.Vertex2(0, yres / 2);
            GL.Color3(Color.FromArgb(22, 86, 70));
            GL.Vertex2(xres, yres / 2);
            GL.Color3(Color.Black);
            GL.Vertex2(xres, yres);
            GL.Color3(Color.Black);
            GL.Vertex2(0, yres);
            GL.End();
            GL.PopMatrix();


            Display3D();

            /*
            GL.LoadIdentity();

            GL.LoadIdentity();
            GL.Color3(Color.Black);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(fl, 0,fl);
            GL.Vertex3(fl, 0, -fl);
            GL.Vertex3(-fl, 0, -fl);
            GL.Vertex3(-fl, 0, fl);
            GL.End();
            */
            cub.loc(0, 0, -6);
            cub.rot(0, rtri, 0);
            cub.draw();


            rtri += 0.2f;                               // rotation angle
            this.SwapBuffers();
        }
        // ///////////////////////////////////////////////////////////////////////////////////
















        void HUD()
        {
        }
        // ///////////////////////////////////////////////////////////////////////////////////
        private void Display3D()
        {
            /*
            lookat = Matrix4.LookAt((float)rtri, 0, 16, 0, 0, 10000, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            GL.Enable(EnableCap.Lighting);
            GL.ShadeModel(ShadingModel.Smooth);


            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Specular, spec);
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Shininess, shine);
            GL.Light(LightName.Light0, LightParameter.Position, lightPos);

            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            */




            //OpenGL initialization
            // move the camera
            GL.Viewport(ClientRectangle);
            //Initialize matrices
            GL.MatrixMode(MatrixMode.Projection); GL.LoadIdentity();
            GL.MatrixMode(MatrixMode.Modelview); GL.LoadIdentity();
            //This sets 2D mode (no perspective)
            //GL.Ortho(0, xres, 0, yres, -1, 1);
            //GL.Clear(GL_COLOR_BUFFER_BIT);
            //Do this to allow fonts
            //GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            //

            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);      // This Will Clear The Background Color To Black
            GL.ClearDepth(1.0);                         // Enables Clearing Of The Depth Buffer
            GL.DepthFunc(DepthFunction.Less);           // The Type Of Depth Test To Do
            GL.Enable(EnableCap.DepthTest);             // Enables Depth Testing
            GL.ShadeModel(ShadingModel.Smooth);         // Enables Smooth Color Shading

            /*
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();              // Reset The Projection Matrix
            */
            Matrix4 projection_matrix;
            Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, aspect, 0.0001f, 640000, out projection_matrix);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection_matrix);

            // apply the shinynes, specular and light position
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Specular, spec);
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Shininess, shine);
            GL.Light(LightName.Light0, LightParameter.Position, lightPos);
            GL.Light(LightName.Light0, LightParameter.Ambient, ambiant);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);
        }
        // ///////////////////////////////////////////////////////////////////////////////////
        void Display2D()
        {
            GL.Disable(EnableCap.DepthTest);
            GL.Disable(EnableCap.Lighting);
            GL.Viewport(ClientRectangle);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, xres, 0, yres, -1, 1);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
        }
    }
}