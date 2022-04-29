using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Button_Event_Simulation.Classes
{
    delegate void ButtonClick(string buttonName);

    class Button
    {
        private int x, y, width, height;
        private string name;

        // 생성자
        public Button(int _x, int _y, int _w, int _h, string _n)
        {
            this.x = _x;
            this.y = _y;
            this.width = _w;
            this.height = _h;
            this.name = _n;
        }

        public event ButtonClick callback;
        public void MouseClickedAt(int xpos, int ypos)
        {
            if ((xpos > this.x && xpos < this.x + this.width) && (ypos > this.y && ypos < this.y + this.height))
            {
                callback(name);
            }
        }

    }
}
