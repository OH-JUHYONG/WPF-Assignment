using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Calculator.Classes;

namespace Calculator
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum SelectedOperator
        {
            Addition,
            Subtraction,
            Multiplication,
            Division
        }

        // 마지막 숫자 저장하기 위한 변수 생성
        double LastNum;
        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();

            negateButton.Click += NegateButton_Click;
            acButton.Click += AcButton_Click;
            percentButton.Click += PercentButton_Click;
            delButton.Click += DelButton_Click;
            sqrtButton.Click += SqrtButton_Click;
            squarButton.Click += SquarButton_Click;
            reciprocButton.Click += ReciprocButton_Click;
        }

        private void NegateButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLable.Content.ToString(), out LastNum))
            {
                LastNum = -1 * LastNum;
                resultLable.Content = LastNum.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLable.Content = "0";
        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLable.Content.ToString(), out LastNum))
            {
                LastNum = LastNum / 100.0;
                resultLable.Content = LastNum.ToString();
            }
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLable.Content.ToString(), out LastNum))
            {
                LastNum = (int)LastNum / 10;
                if(LastNum == 0)
                {
                    resultLable.Content = "0";
                }
                else resultLable.Content = LastNum.ToString();
            }
        }

        private void SqrtButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLable.Content.ToString(), out LastNum))
            {
                if (!resultLable.Content.ToString().Contains("-"))
                {
                    resultLable.Content = Math.Sqrt(LastNum);
                }
            }
            
        }

        private void SquarButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLable.Content.ToString(), out LastNum))
            {
                LastNum = LastNum * LastNum;
                resultLable.Content = LastNum.ToString();
            } 
        }

        private void ReciprocButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLable.Content.ToString(), out LastNum))
            {
                LastNum = 1/LastNum;
                resultLable.Content = LastNum.ToString();
            }
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button currentButton = (Button)sender;

            if(resultLable.Content.ToString() == "0")
            {
                resultLable.Content = currentButton.Content;
            }
            else
            {
                resultLable.Content = $"{resultLable.Content}{currentButton.Content}";
            }
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLable.Content.ToString(), out LastNum))
            {
                resultLable.Content = "0";
            }

            if (sender == addButton)
                selectedOperator = SelectedOperator.Addition;
            if (sender == subButton)
                selectedOperator = SelectedOperator.Subtraction;
            if (sender == mulButton)
                selectedOperator = SelectedOperator.Multiplication;
            if (sender == diviButton)
                selectedOperator = SelectedOperator.Division;
        }

        

        private void DotButton_Click(object sender, RoutedEventArgs e)
        {
            if(!resultLable.Content.ToString().Contains("."))
            {
                resultLable.Content = $"{resultLable.Content}.";
            }
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double NewNum;

            // 결과값을 저장해주는 변수
            double result = 0;

            if(double.TryParse(resultLable.Content.ToString(), out NewNum))
            {
                switch(selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(LastNum, NewNum);
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Sub(LastNum, NewNum);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Mul(LastNum, NewNum);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Div(LastNum, NewNum);
                        break;
                }
            }
            resultLable.Content = result.ToString();
        }

        
    }
}
