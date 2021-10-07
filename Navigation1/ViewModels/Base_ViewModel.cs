using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Navigation1.ViewModels.Base;

namespace Navigation1.ViewModels
{
    class Base_ViewModel : AViewModel
    {

        //public ViewModelBase CurrentViewModel { get; set; }
        public Base_ViewModel()
        {
            this.AddViewModel(new LogOn_ViewModel() {  InternalName = "LogOn_ViewModel" });
            this.AddViewModel(new Recovery_ViewModel() {  InternalName = "Recovery_ViewModel" });
            this.AddViewModel(new Regester_ViewModel() {  InternalName = "Regester_ViewModel" });
            this.AddViewModel(new Main_ViewModel() {  InternalName = "Main_ViewModel" });


            this.Current_ViewModel = this.GetViewModel("LogOn_ViewModel");
        }
    }
}
