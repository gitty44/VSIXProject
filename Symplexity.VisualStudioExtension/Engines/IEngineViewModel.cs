using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symplexity.VisualStudioExtension.Engines
{
    public interface IEngineViewModel
    {
      
       void LoadTemplates();

       void SetupGUI(bool isConnected);
       

    }
}
