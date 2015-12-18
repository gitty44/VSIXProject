
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Symplexity.VisualStudioExtension.Engines
{
    public class UtilitiesViewModel : BindableBase
    {
        #region Fields
        
        public RelayCommand<string> ChangeViewModelCommand { get; private set; }

        private CalcEngineViewModel calcViewModel = new CalcEngineViewModel();
        private TAEngineViewModel taViewModel = new TAEngineViewModel(); 

        private BindableBase currentEngineViewModel;

        public BindableBase CurrentEngineViewModel
        {
            get { return currentEngineViewModel; }
            set
            {
                SetProperty(ref currentEngineViewModel, value);
            }
        }
             

        #endregion

        public UtilitiesViewModel()
        {          
            ChangeViewModelCommand = new RelayCommand<string>(ChangeViewModel);
            CurrentEngineViewModel = calcViewModel; 
        }

     

        #region Methods

        public void ChangeViewModel(string viewToShow) //(IEngineViewModel viewModel)
        {
            switch (viewToShow)
            {
                case "CalculationEngine":
                    CurrentEngineViewModel = calcViewModel;
                    break;
                case "TAEngine":
                    CurrentEngineViewModel = taViewModel;
                    break;
                default: 
                    CurrentEngineViewModel = calcViewModel;
                    break;
            }            
        }

        #endregion
    }
}
