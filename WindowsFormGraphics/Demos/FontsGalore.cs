using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormGraphics
{
    public class MyClass : WFGMainWindow
    {
        public MyClass()
        {
            
        }

        public override void Draw(Graphics g)
        {

        }

        public override void Update()
        {

        }

        public override void OnResize(object sender, EventArgs eventArgs)
        {

        }

        public override void OnScrollWheel(object sender, ScrollEventArgs scrollEventArgs)
        {

        }

        public override void OnDragDrop(object sender, DragEventArgs dragEventArgs)
        {

        }

        public override void OnLoad(object sender, EventArgs eventArgs)
        {

        }

        public override void OnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {

        }

        public override void OnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {

        }

        public override void OnMouseUp(object sender, MouseEventArgs mouseEventArgs)
        {

        }

        public override void OnMouseDoubleClick(object sender, MouseEventArgs mouseEventArgs)
        {

        }

        public override void OnMouseClick(object sender, MouseEventArgs mouseEventArgs)
        {

        }

        public override void OnMouseDown(object sender, MouseEventArgs mouseEventArgs)
        {

        }

        public override void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            base.OnClosing(sender, cancelEventArgs);
        }

        public override void OnKeyPressed(object sender, KeyPressEventArgs eventArgs)
        {

        }
    }

    internal class FontsGalore : WFGMainWindow
    {
        private Font _myFont = new Font("Arial", 32);
        private Font _myFont2 = new Font("Arial", 22);
        private Font _myTexturedFont = new Font("Impact", 64);
        private Image _grassyImage = Image.FromFile("Demos/freeseams-10.jpg");
        private Font _myFont3 = new Font("Fixedsys", 64);

        private DateTime _datetimeNow;

        public FontsGalore() : base(Width: 800, Height: 600, BackgroundColour: Color.White, Title: "Fonts Demo - WFG")
        {
            
        }

        public override void Update()
        {
            _datetimeNow = DateTime.Now;
        }

        public override void Draw(Graphics g)
        {
            g.DrawString("Hello! Thank you for trying out WFG!", _myFont, new SolidBrush(Color.Black), 0, 0);
            g.DrawString("It is a simple library that wraps system.drawing functions in\na loop, allowing for animations to make games or whatever.", _myFont2, new SolidBrush(Color.DarkRed), 0, 50);
            g.DrawString("Grassy Impact!", _myTexturedFont, new TextureBrush(_grassyImage), 100, 105);
            g.DrawString(_datetimeNow.TimeOfDay.ToString(), _myFont3, new SolidBrush(Color.DimGray), 30, 220);
        }
    }
}
