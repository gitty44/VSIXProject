using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symplexity.VisualStudioExtension
{
    /// <summary>
    /// This class is used to expose the list of the IDs of the commands implemented
    /// by this package. This list of IDs must match the set of IDs defined inside the
    /// Buttons section of the VSCT file.
    /// </summary>
    internal static class PkgCmdIDList
    {
        // Now define the list a set of public static members.
        public const int cmdidSaveCommand = 4177;
        public const int ConnectCommandId = 0x0100;


    }
}
