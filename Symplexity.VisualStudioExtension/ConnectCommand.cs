//------------------------------------------------------------------------------
// <copyright file="ConnectCommand.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;
using System.Globalization;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Symplexity.VisualStudioExtension.Config;
using Symplexity.Core.Config;
using System.Reflection;
using System.IO;
using System.Linq;
using EnvDTE;
using EnvDTE80;
using System.Windows.Forms;

namespace Symplexity.VisualStudioExtension
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class ConnectCommand
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("b4da29d7-8c59-47c7-8658-4e5c3c7c3759");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly Microsoft.VisualStudio.Shell.Package package;


        private DTE2 visualStudioInstance;
        private Boolean Connected = false;
        private SelectedConfiguration Config;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        private ConnectCommand(Microsoft.VisualStudio.Shell.Package package)
        {
            if (package == null)
            {
                throw new ArgumentNullException("package");
            }

            this.package = package;

            OleMenuCommandService commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (commandService != null)
            {
                var menuCommandID = new CommandID(CommandSet, CommandId);
                var menuItem = new MenuCommand(this.MenuItemCallback, menuCommandID);
                commandService.AddCommand(menuItem);
            }

            visualStudioInstance = (DTE2)this.ServiceProvider.GetService(typeof(DTE));
           
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static ConnectCommand Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private IServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static void Initialize(Microsoft.VisualStudio.Shell.Package package)
        {
            Instance = new ConnectCommand(package);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void MenuItemCallback(object sender, EventArgs e)
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

        private void Connect()
        {
            //Let the user choose the config file that is to be used.
            string selectedConfigFile = GetConfigFile();

            //Let the user choose the cluster configuration that is to be used.
            ConnectionConfigForm ConnectConfigWindow = new ConnectionConfigForm(selectedConfigFile);
            ConnectConfigWindow.ShowDialog();

            if (ConnectConfigWindow.SelectedConfig != null)
            {
                try
                {
                    Config = ConnectConfigWindow.SelectedConfig;
                    AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolver);

                    visualStudioInstance.StatusBar.Text = "Loading addin...";
                    Application.DoEvents();

                    //Events2 evs = visualStudio.Events as Events2;

                    SetupGUI(true);

                    Connected = true;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("An error occured whilst attempting to load the addon. \r\n\r\n" + ex.ToString(), "Error loading Addon", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("An error occured while attempting to load the assembly files. " + ex.Message, ex);
                    Connected = false;
                }

            }


            string message = "Inside Connect() method, and this Cluster was chosen: " + ConnectConfigWindow.SelectedConfig.Cluster.Name;
            string title = "ConnectCommand";
            ShowMessage(message, title);
            
            

            

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
                SetupGUI(false);
                Connected = false;
                visualStudioInstance.StatusBar.Text = "Disconnected";
                Application.DoEvents();
            }

            string message = "Inside Disconnect() method.";
            string title = "ConnectCommand";
            ShowMessage(message, title);
          
        }

        private void SetupGUI(Boolean isConnect)
        {
            
        }

        private string GetConfigFile()
        {
            
            Microsoft.Win32.OpenFileDialog openConfigFile = new Microsoft.Win32.OpenFileDialog();
            openConfigFile.Multiselect = false;
            openConfigFile.InitialDirectory = @"c:\Program Files\Symplexity\Configs";
            openConfigFile.FileName = "";
            openConfigFile.CheckFileExists = true;
            openConfigFile.CheckPathExists = true;
            openConfigFile.Filter = "Configuration File|*.config";

            Nullable<bool> result = openConfigFile.ShowDialog();
            string selectedConfigFile = "";

            if (result == true)
            {
                selectedConfigFile = openConfigFile.FileName;
            }

            return selectedConfigFile;

        }

        private Assembly AssemblyResolver(object sender, ResolveEventArgs args)
        {
            string assemblyName = args.Name.Split(',')[0];

            if (args.Name.Contains(".resources,"))
            { //return null; 
            }

            var files = Directory.GetFiles(Config.BinPath, assemblyName + ".dll");
            if (files.Count() > 0)
            {
                Assembly asm = Assembly.LoadFrom(files[0]);
                return asm;
            }
            else
            {
                throw new Exception("Unable to find assembly in AssemblyResolver: " + args.Name);
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
    }
}
