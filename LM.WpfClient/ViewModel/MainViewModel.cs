using System;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Timers;
using System.Windows.Threading;

namespace LM.WpfClient.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string _navigationSource;
        private DateTime _autoTimer;

        public ICommand AddEmployee { get; internal set; }
        public ICommand EditEmployee { get; internal set; }

        Dictionary<string, string> navSource;

        public string NavigationSource
        {
            get { return _navigationSource; }
            set
            {
                _navigationSource = value;
                RaisePropertyChanged();
            }
        }

        public DateTime AutoTimer
        {
            get { return _autoTimer; }
            set
            {
                _autoTimer = value;
                RaisePropertyChanged();
            }
        }

        public MainViewModel()
        {
            AddEmployee = new RelayCommand(AddEmployeeExecute);
            EditEmployee = new RelayCommand(EditEmployeeExecute);
            navSource = new Dictionary<string, string>();

            navSource.Add("AddEmployee", "Views/AddEmployee.xaml");
            navSource.Add("EditEmployee", "Views/EditEmployee.xaml");


            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        void timer_Tick(object sender, EventArgs e)
        {
            AutoTimer = DateTime.Now;
        }

        private async void AddEmployeeExecute()
        {
            NavigationSource = navSource["AddEmployee"];
        }
        private async void EditEmployeeExecute()
        {
            NavigationSource = navSource["EditEmployee"];
        }


    }


    public class Ticker : INotifyPropertyChanged
    {
        public Ticker()
        {
            Timer timer = new Timer();
            timer.Interval = 1000; // 1 second updates
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        public DateTime Now
        {
            get { return DateTime.Now; }
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Now"));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}