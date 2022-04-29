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
            Division,
        }
        // 마지막 숫자 저장하기 위한 변수 생성
        double LastNum = 0;

        // 처음 계산임을 식별하기 위한 변수 설정
        int firstOperator = 0;

        // 이전에 연산자와 = 을 눌렀는지 식별해주는 변수
        int pastRecord = 0;

        SelectedOperator selectedOperator;
        SelectedOperator tempselectedOperator; // Operaotr 버튼을 저장하기 위한 변수

        Button tempSelOper1; // Operator 버튼의 +,-,*,/ 문자열을 저장하기 위한 변수
        Button tempSelOper2;

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
            dotButton.Click += DotButton_Click;
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
            firstOperator = 0;
            pastRecord = 0;
            tempselectedOperator = 0;
            tempSelOper1 = null;
            tempSelOper2 = null;
            resultLable.Content = "0";
            midResult.Content = "";
        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLable.Content.ToString(), out LastNum))
            {
                LastNum = LastNum / 100.0;
                resultLable.Content = LastNum.ToString();
            }
        }

        private void DotButton_Click(object sender, RoutedEventArgs e)
        {
            if (!resultLable.Content.ToString().Contains("."))
            {
                resultLable.Content = $"{resultLable.Content}.";
            }
        }

        // 새로 추가한 버튼
        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLable.Content.ToString().Length == 1)
            {
                resultLable.Content = "0";
            }
            else resultLable.Content = resultLable.Content.ToString().Remove(resultLable.Content.ToString().Length - 1);
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

        // 숫자 버튼
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button currentButton = (Button)sender;

            if(firstOperator == 0)
            {
                resultLable.Content = currentButton.Content;
                firstOperator++;
            }
            else
            {
                if(pastRecord == 0)
                {
                    resultLable.Content = $"{resultLable.Content}{currentButton.Content}";
                }
                else
                {
                    if (resultLable.Content.ToString() == "0")
                    {
                        resultLable.Content = currentButton.Content;
                    }
                    else
                    {
                        resultLable.Content = $"{resultLable.Content}{currentButton.Content}";
                    }
                }  
            }
        }

        // 연산자 버튼
        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            if (pastRecord == 0)
            {
                double.TryParse(resultLable.Content.ToString(), out LastNum);

                if (sender == addButton)
                    selectedOperator = SelectedOperator.Addition; 
                if (sender == subButton)
                    selectedOperator = SelectedOperator.Subtraction;
                if (sender == mulButton)
                    selectedOperator = SelectedOperator.Multiplication;
                if (sender == diviButton) 
                    selectedOperator = SelectedOperator.Division;

                pastRecord++;
                tempSelOper1 = (Button)sender;
                tempselectedOperator = selectedOperator;
                midResult.Content = $"{resultLable.Content.ToString()} {tempSelOper1.Content}";
            }
            else
            {
                double NewNum = 0;
                double.TryParse(resultLable.Content.ToString(), out NewNum);
                double result = 0;

                if (sender == addButton)
                    selectedOperator = SelectedOperator.Addition;
                if (sender == subButton)
                    selectedOperator = SelectedOperator.Subtraction;
                if (sender == mulButton)
                    selectedOperator = SelectedOperator.Multiplication;
                if (sender == diviButton)
                    selectedOperator = SelectedOperator.Division;

                tempSelOper2 = (Button)sender;

                switch (tempselectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(LastNum, NewNum);
                        listState.Items.Insert(0, $"{LastNum.ToString()} + {NewNum.ToString()} = {result.ToString()}");
                        midResult.Content = $"{result.ToString()} {tempSelOper2.Content}";
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Sub(LastNum, NewNum);
                        listState.Items.Insert(0, $"{LastNum.ToString()} - {NewNum.ToString()} = {result.ToString()}");
                        midResult.Content = $"{result.ToString()} {tempSelOper2.Content}";
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Mul(LastNum, NewNum);
                        listState.Items.Insert(0, $"{LastNum.ToString()} * {NewNum.ToString()} = {result.ToString()}");
                        midResult.Content = $"{result.ToString()} {tempSelOper2.Content}";
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Div(LastNum, NewNum);
                        listState.Items.Insert(0, $"{LastNum.ToString()} / {NewNum.ToString()} = {result.ToString()}");
                        midResult.Content = $"{result.ToString()} {tempSelOper2.Content}";
                        break;
                }

                tempselectedOperator = selectedOperator;
                resultLable.Content = result.ToString();
                LastNum = result;
            }
            firstOperator = 0;
        }


        // = 버튼  
        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {      
            if(pastRecord != 0)
            {
                double NewNum = 0;
                double result = 0;

                if (double.TryParse(resultLable.Content.ToString(), out NewNum))
                {
                    switch (selectedOperator)
                    {
                        case SelectedOperator.Addition:
                            result = SimpleMath.Add(LastNum, NewNum);
                            listState.Items.Insert(0, midResult.Content.ToString() + " " + NewNum + " = " + result.ToString());
                            midResult.Content = $"{LastNum.ToString()} + {NewNum.ToString()} =";
                            break;
                        case SelectedOperator.Subtraction:
                            result = SimpleMath.Sub(LastNum, NewNum);
                            listState.Items.Insert(0, midResult.Content.ToString() + " " + NewNum + " = " + result.ToString());
                            midResult.Content = $"{LastNum.ToString()} - {NewNum.ToString()} =";
                            break;
                        case SelectedOperator.Multiplication:
                            result = SimpleMath.Mul(LastNum, NewNum);
                            listState.Items.Insert(0, midResult.Content.ToString() + " " + NewNum + " = " + result.ToString());
                            midResult.Content = $"{LastNum.ToString()} * {NewNum.ToString()} =";
                            break;
                        case SelectedOperator.Division:
                            result = SimpleMath.Div(LastNum, NewNum);
                            listState.Items.Insert(0, midResult.Content.ToString() + " " + NewNum + " = " + result.ToString());
                            midResult.Content = $"{LastNum.ToString()} / {NewNum.ToString()} =";
                            break;
                    }
                    pastRecord = 0;
                }
                resultLable.Content = result.ToString();
            }
        }
    }
}
