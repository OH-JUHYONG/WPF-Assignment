using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Property.Classes
{
    class Person
    {
        private int height;
        public int Height
        {
            get { return height; }
            set
            {
                if(value <= 0)
                {
                    Console.WriteLine("0보다 작은 값을 대입할 수 없습니다!");
                    return;
                }
                height = value;
            }
        }

        private int weight;
        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // 생성자
        public Person(int h, int w, string n)
        {
            this.Height = h;
            this.Weight = w;
            this.Name = n;
        }

        internal void Greetings(Person the_Guy)
        {
            Console.WriteLine("안녕하세요 " + the_Guy.Name + '!');
            return;
        }


    }
}
