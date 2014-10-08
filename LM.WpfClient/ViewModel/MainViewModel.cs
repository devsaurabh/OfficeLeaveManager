using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace LM.WpfClient.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        public ICommand AddEmployee { get; internal set; }

        public MainViewModel()
        {
            AddEmployee = new RelayCommand(LoginExecute); 
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        private async void LoginExecute()
        {
           
        }
    }
}