using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace LM.WpfClient.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string _navigationSource;

        public ICommand AddEmployee { get; internal set; }
        public ICommand EditEmployee { get; internal set; }

        public string NavigationSource
        {
            get { return _navigationSource; }
            set
            {
                _navigationSource = value;
                RaisePropertyChanged();
            }
        }

        public MainViewModel()
        {
            AddEmployee = new RelayCommand(AddEmployeeExecute);
            EditEmployee = new RelayCommand(EditEmployeeExecute); 

            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        private async void AddEmployeeExecute()
        {
            NavigationSource = "Views/AddEmployee.xaml";
        }
        private async void EditEmployeeExecute()
        {
            NavigationSource = "Views/EditEmployee.xaml";
        }
    }
}