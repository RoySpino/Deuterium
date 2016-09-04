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
        public Render(int wid, int hei) : base(wid,hei)
        {

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
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit |  ClearBufferMask.DepthBufferBit);
            GL.ClearColor(Color.Black);

            this.SwapBuffers();
        }
    }
}
