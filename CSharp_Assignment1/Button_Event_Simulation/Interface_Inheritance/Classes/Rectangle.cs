using System;
using Interface_Inheritance.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Inheritance.Classes
{
    class Rectangle : IShape
    {
        private int width;
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        private int height;
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        // 생성자
        public Rectangle(int w, int h)
        {
            this.Width = w;
            this.Height = h;
        }

        public double perimeter()
        {
            return 2 * (Height + Width);
        }

        public double area()
        {
            return Height * Width;
        }
    }
}
