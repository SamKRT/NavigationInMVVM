using Navigation1.RelayCommand;
using Navigation1.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Navigation1.ViewModels
{
    class Main_ViewModel : AViewModel
    {
        public RelayCommand<string> TestVMCommand { get; set; }
        public Main_ViewModel()
        {
            TestVMCommand = new RelayCommand<string>(OnTestVMCommand);

            this.AddViewModel(new MainV1_ViewModel() { InternalName = "MainV1_ViewModel" });
            this.AddViewModel(new MainV2_ViewModel() { InternalName = "MainV2_ViewModel" });
            this.AddViewModel(new MainV3_ViewModel() { InternalName = "MainV3_ViewModel" });

            this.Current_ViewModel = this.GetViewModel("MainV1_ViewModel");
        }
        private void OnTestVMCommand(string obj)
        {
            MessageBox.Show("You Are Logged On");
        }
    }
}
