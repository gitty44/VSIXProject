//------------------------------------------------------------------------------
// <copyright file="SymplexityCalculationUtilitiesWindow.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Symplexity.VisualStudioExtension
{
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Shell;
    using System.ComponentModel.Design;
    using Engines;

    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    /// </summary>
    /// <remarks>
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
    /// usually implemented by the package implementer.
    /// <para>
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its
    /// implementation of the IVsUIElementPane interface.
    /// </para>
    /// </remarks>
    [Guid("28619315-8fb6-43d0-ab55-e312f7e2719c")]
    public class SymplexityCalculationUtilitiesWindow : ToolWindowPane
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymplexityCalculationUtilitiesWindow"/> class.
        /// </summary>
        public SymplexityCalculationUtilitiesWindow() : base(null)
        {
            this.Caption = "Symplexity Calculation Utilities";

            this.ToolBar = new CommandID(new Guid(Guids.guidConnectCommandPackageCmdSet), Guids.SymToolbar);
            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on
            // the object returned by the Content property.
            this.Content = new UtilitiesView();
            
        }
      
    }
}
