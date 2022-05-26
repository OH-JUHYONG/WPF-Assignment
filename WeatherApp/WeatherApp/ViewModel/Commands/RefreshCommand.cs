using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WeatherApp.ViewModel.Commands
{
    class RefreshCommand : ICommand
    {
        public WeatherVM VM { get; set; }

        public RefreshCommand(WeatherVM vm)
        {
            VM = vm;
        }

        public event EventHandler CanExecuteChanged;

        // Command의 실행 가능 여부를 반환
        public bool CanExecute(object parameter)
        {
            return true;
        }

        // Command가 실행되었을때의 동작(= 이벤트 핸들러의 역할)
        public void Execute(object parameter)
        { 
            TextBox txtBox = parameter as TextBox;

            var citylist = VM.Cities.ToList();
            string s;
         
            if (txtBox.Text != "")
            {
                int count = 0;
                for (int i = 0; i < citylist.Count(); i++)
                {
                    s = citylist[i];
                    if (s == txtBox.Text)
                    {
                        VM.SelectedCity = s;
                        VM.GetWeatehr();
                        break;
                    }
                    count++;
                    if (count == citylist.Count())
                    {
                        VM.Cities.Add(txtBox.Text);
                        VM.SelectedCity = txtBox.Text;
                        VM.GetWeatehr();
                    }
                }
            }
            else VM.GetWeatehr();  
        }
    }
}
