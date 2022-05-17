using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Classes;
using WeatherApp.ViewModel.Commands;

namespace WeatherApp.ViewModel
{
    class WeatherVM
    {
        public WeatherData WeatherDataToShow { get; set; }
        public ObservableCollection<string> Cities { get; set; } // 날씨 정보를 얻어오는 Option을 만들어 놓는다.
        public RefreshCommand RefreshCommand { get; set; }

        // 어떤 날씨 정보를 얻어오고 싶은지를 저장하는 변수 선언
        private string selectedCity;
        public string SelectedCity
        {
            get { return selectedCity; }
            set { selectedCity = value; GetWeatehr(); }
            // set { selectedCity = value; } 만 하면 GetWeatehr()를 호출을 안하니까 아무런 반응 x
        }

        public WeatherVM()
        {
            /* 
             이 것만 있고 지정해준 초기값이 없으면 아무일도 안일어나므로
             WeatherData의 생성자에서 default값을 지정해줘야 한다.
            */
            WeatherDataToShow = new WeatherData();

            Cities = new ObservableCollection<string>();
            RefreshCommand = new RefreshCommand(this);

            Cities.Add("London");
            Cities.Add("Paris");
            Cities.Add("Seoul");
            Cities.Add("Jeonju");
            Cities.Add("Daejeon");
        }

        public void GetWeatehr()
        {
            if(selectedCity != null)
            {
                var weather = WeatherAPI.GetWeatherData(selectedCity);
                WeatherDataToShow.Name = weather.Name;
                WeatherDataToShow.Main = weather.Main;
                WeatherDataToShow.Wind = weather.Wind;
            }
        }

    }
}
