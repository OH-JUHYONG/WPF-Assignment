using System;
using Interface_Inheritance.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Inheritance.Classes
{
    class Circle : IShape
    {
        private int radius;
        public int Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public Circle(int r)
        {
            this.Radius = r;
        }

        public double perimeter()
        {
            // 소수점 2번째 자리까지 출력
            return Math.Round(2 * Math.PI * Radius, 2);
        }

        public double area()
        {
            return Math.Round(Math.PI * Radius * Radius, 2);
        }

    }
}
