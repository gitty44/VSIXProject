//------------------------------------------------------------------------------
// <copyright file="ConnectCommandPackage.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.Win32;
using EnvDTE;
using EnvDTE80;
using System.Text;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Symplexity.VisualStudioExtension.Engines;

namespace Symplexity.VisualStudioExtension
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the
    /// IVsPackage interface and uses the registration attributes defined in the framework to
    /// register itself and its components with the shell. These attributes tell the pkgdef creation
    /// utility what data to put into .pkgdef file.
    /// </para>
    /// <para>
    /// To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...&gt; in .vsixmanifest file.
    /// </para>
    /// </remarks>
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // Info on this package for Help/About
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(SymPackage.PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    [ProvideToolWindow(typeof(Symplexity.VisualStudioExtension.SymplexityCalculationUtilitiesWindow))]
    public sealed class SymPackage : Microsoft.VisualStudio.Shell.Package
    {
        /// <summary>
        /// ConnectCommandPackage GUID string.
        /// </summary>
        public const string PackageGuidString = "e96ccae3-d98b-4f23-8b10-5e08e0cf380b";
       
      
        private Events2 vsEvents;

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly Microsoft.VisualStudio.Shell.Package package;
        private DTE2 visualStudioInstance;
        private Boolean Connected = false;
        private UtilitiesViewModel uvm;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private System.IServiceProvider ServiceProvider
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectCommand"/> class.
        /// </summary>
        public SymPackage()
        {
            // Inside this method you can place any initialization code that does not require
            // any Visual Studio service because at this point the package object is created but
            // not sited yet inside Visual Studio environment. The place to do all the other
            // initialization is the Initialize method.
        }

        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            //ConnectCommand.Initialize(this);
            base.Initialize();
            Symplexity.VisualStudioExtension.SymplexityCalculationUtilitiesWindowCommand.Initialize(this);
                       
            OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (null != mcs)
            {
                CommandID connectCommandID = new CommandID(new Guid(Guids.guidConnectCommandPackageCmdSet), (int)PkgCmdIDList.ConnectCommandId);
                OleMenuCommand command = new OleMenuCommand(new EventHandler(ConnectCommandCallback), connectCommandID);
                mcs.AddCommand(command);

                CommandID saveCommandID = new CommandID(new Guid(Guids.guidConnectCommandPackageCmdSet), (int)PkgCmdIDList.cmdidSaveCommand);
                command = new OleMenuCommand(new EventHandler(SaveCommandCallback), saveCommandID);
                mcs.AddCommand(command);


            }

            visualStudioInstance = (DTE2)this.ServiceProvider.GetService(typeof(DTE));
            uvm = new UtilitiesViewModel();
        }    

        /// <summary>
        /// Event handler called when the user selects the Connect command.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters", MessageId = "Microsoft.Samples.VisualStudio.MenuCommands.MenuCommandsPackage.OutputCommandString(System.String)")]
        private void ConnectCommandCallback(object caller, EventArgs args)
        {
            if (!this.Connected)
            {
                this.Connect();
            }
            else
            {
                this.Disconnect();
            }
        }


        /// <summary>
        /// Event handler called when the user selects the Save command.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters", MessageId = "Microsoft.Samples.VisualStudio.MenuCommands.MenuCommandsPackage.OutputCommandString(System.String)")]
        private void SaveCommandCallback(object caller, EventArgs args)
        {
            OutputCommandString("In Save Command Callback");
            uvm.ChangeViewModel("CalculationEngine");
        }

        public void Connect()
        {       

                    //if (Config.Engine.AssemblyPath.Contains("Symplexity.Engines.TimeAndAttendance.dll"))
                    //{
                        uvm.ChangeViewModel("TAEngine");
                    //}
                    //else //Assume Calculation Engine
                    //{
                    //    uvm.ChangeViewModel("CalculationEngine"); 
                    //}                                  
            
        }
     

        private void Disconnect()
        {
            if (VsShellUtilities.ShowMessageBox(
                ServiceProvider,
                "Are you sure you wish to disconnect from this database? Any unsaved changes will be lost.",
                "Confirm disconnecting from Cluster.",
                OLEMSGICON.OLEMSGICON_INFO,
                OLEMSGBUTTON.OLEMSGBUTTON_YESNO,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST) == 6) //Yes button returns value of 6, No button returns value of 7
            {
                visualStudioInstance.StatusBar.Text = "Disconnecting...";
                Application.DoEvents();
                
                Connected = false;
                
                visualStudioInstance.StatusBar.Text = "Disconnected";
                Application.DoEvents();
            }

            string message = "Inside Disconnect() method.";
            string title = "ConnectCommand";
            ShowMessage(message, title);

        }



        /// <summary>
        /// This function prints text on the debug ouput and on the generic pane of the 
        /// Output window.
        /// </summary>
        /// <param name="text"></param>
        private void OutputCommandString(string text)
        {
            // Build the string to write on the debugger and Output window.
            StringBuilder outputText = new StringBuilder();
            outputText.Append(" ================================================\n");
            outputText.AppendFormat("  MenuAndCommands: {0}\n", text);
            outputText.Append(" ================================================\n\n");

            IVsOutputWindowPane windowPane = (IVsOutputWindowPane)GetService(typeof(SVsGeneralOutputWindowPane));
            if (null == windowPane)
            {
                Debug.WriteLine("Failed to get a reference to the Output window General pane");
                return;
            }
            if (Microsoft.VisualStudio.ErrorHandler.Failed(windowPane.OutputString(outputText.ToString())))
            {
                Debug.WriteLine("Failed to write on the Output window");
            }
        }

        private void ShowMessage(string message, string title)
        {
            VsShellUtilities.ShowMessageBox(
                this.ServiceProvider,
                message,
                title,
                OLEMSGICON.OLEMSGICON_INFO,
                OLEMSGBUTTON.OLEMSGBUTTON_OK,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);

        }

        #endregion
    }
}
