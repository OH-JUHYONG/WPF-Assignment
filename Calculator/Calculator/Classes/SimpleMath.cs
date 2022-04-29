using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator.Classes
{
    class SimpleMath
    {
        public static double Add(double num1, double num2)
        {

            return num1+ num2;
        }

        public static double Sub(double num1, double num2)
        {
            return num1 - num2;
        }

        public static double Mul(double num1, double num2)
        {
            return num1 * num2;
        }

        public static double Div(double num1, double num2)
        {
            if(num2 == 0)
            {
                MessageBox.Show("0으로 나눌 수 없습니다.", "잘못된 연산", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return num1 / num2;
        }

    }
}
