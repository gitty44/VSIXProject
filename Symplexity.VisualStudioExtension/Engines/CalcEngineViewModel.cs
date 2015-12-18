using EnvDTE80;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Symplexity.VisualStudioExtension.Engines
{
    public class CalcEngineViewModel : BindableBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);            

        public CalcEngineViewModel()
        {
            
        }

        public string Name
        {
            get
            {
                return "Calc Engine";
            }
        }
    
   
        public void LoadTemplates()
        {

        }

        public void SetupGUI(bool isConnected)
        {
           
        }

       

    }
}
