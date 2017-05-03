using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormGraphics
{
    public abstract class WFGMainWindow
    {
        private Graphics _frontBuffer;
        private Graphics _backBuffer;
        private Bitmap _backBufferBitmap;

        private Thread _drawThread;
        private Thread _formThread;

        protected int Width, Height;
        protected Color BackgroundColour;
        protected string Title;

        protected Form Form;

        public WFGMainWindow(int Width = 400, int Height = 300, Color BackgroundColour = default(Color), string Title = "WFG")
        {
            this.Width = Width;
            this.Height = Height;
            this.BackgroundColour = BackgroundColour;
            this.Title = Title;

            _formThread = new Thread(CreateForm);
            _formThread.Start();
        }

        private void CreateForm()
        {
            this.Form = new Form();
            {
                this.Form.Width = Width;
                this.Form.Height = Height;
                this.Form.Text = Title;

                // create the frontbuffer.
                _frontBuffer = this.Form.CreateGraphics();

                // create a backbuffer from an empty bitmap to draw to.
                _backBufferBitmap = new Bitmap(this.Form.Width + 20, this.Form.Height + 45);
                _backBuffer = Graphics.FromImage(_backBufferBitmap);
                _backBuffer.CompositingQuality = CompositingQuality.HighQuality;

                // begin the thread that draws to the back buffer.
                _drawThread = new Thread(InnerDraw);
                _drawThread.Start();

                this.Form.Load += OnLoad;
                this.Form.Closing += OnClosing;
                this.Form.DragDrop += OnDragDrop;
                this.Form.Resize += OnResize;

                this.Form.MouseDown += OnMouseDown;
                this.Form.MouseClick += OnMouseClick;
                this.Form.MouseDoubleClick += OnMouseDoubleClick;
                this.Form.MouseUp += OnMouseUp;
                this.Form.Scroll += OnScrollWheel;

                this.Form.KeyPress += OnKeyPressed;
                this.Form.KeyDown += OnKeyDown;
                this.Form.KeyUp += OnKeyUp;

                this.Form.ShowDialog();
            }
        }

        #region callbacks
        public virtual void Draw(Graphics g)
        {

        }

        public virtual void Update()
        {

        }

        public virtual void OnResize(object sender, EventArgs eventArgs)
        {

        }

        public virtual void OnScrollWheel(object sender, ScrollEventArgs scrollEventArgs)
        {

        }

        public virtual void OnDragDrop(object sender, DragEventArgs dragEventArgs)
        {

        }

        public virtual void OnLoad(object sender, EventArgs eventArgs)
        {

        }

        public virtual void OnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {

        }

        public virtual void OnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {

        }

        public virtual void OnMouseUp(object sender, MouseEventArgs mouseEventArgs)
        {

        }

        public virtual void OnMouseDoubleClick(object sender, MouseEventArgs mouseEventArgs)
        {

        }

        public virtual void OnMouseClick(object sender, MouseEventArgs mouseEventArgs)
        {

        }

        public virtual void OnMouseDown(object sender, MouseEventArgs mouseEventArgs)
        {

        }

        public virtual void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            _drawThread.Abort();
        }

        public virtual void OnKeyPressed(object sender, KeyPressEventArgs eventArgs)
        {

        }

#endregion

        private void InnerDraw()
        {
            while (true)
            {
                this.Update();

                _backBuffer.Clear(Color.White);

                this.Draw(_backBuffer);

                // copy the data to the frontbuffer.
                _frontBuffer.DrawImage(_backBufferBitmap, new Point(0, 0));
                Thread.Sleep(17);
            }
        }
    }
}