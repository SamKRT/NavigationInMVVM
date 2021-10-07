using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Navigation1.RelayCommand;

namespace Navigation1.ViewModels.Base
{
    public abstract class AViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public RelayCommand<string> SelectViewCommand { get; set; }

        public AViewModel()
        {
            SelectViewCommand = new RelayCommand<string>(OnSelectViewCommand);
        }

        private static ObservableCollection<ViewModelBase> _ViewModels;
        public static ObservableCollection<ViewModelBase> ViewModels
        {
            get { return _ViewModels; }
            set { _ViewModels = value; }
        }

        public void AddViewModel(ViewModelBase viewmodel)
        {
            if (ViewModels == null)
                ViewModels = new ObservableCollection<ViewModelBase>();

            var currentVNs = (from vms in ViewModels where vms.InternalName == viewmodel.InternalName select vms).FirstOrDefault();
            if (currentVNs == null)
                ViewModels.Add(viewmodel);
        }

        public ViewModelBase GetViewModel(string viewmodel)
        {
            return ViewModels.FirstOrDefault(item => item.InternalName == viewmodel);
        }

        private void OnSelectViewCommand(string obj)
        {
            switch (obj)
            {
                case "ExitCommand":
                    Application.Current.Shutdown();
                    break;
                default:
                    Current_ViewModel = this.GetViewModel(obj);
                    break;
            }
        }

        private ViewModelBase _Current_ViewModel;
        public ViewModelBase Current_ViewModel
        {
            get { return _Current_ViewModel; }
            set { _Current_ViewModel = value; OnPropertyChanged("Current_ViewModel"); }
        }
    }
}
