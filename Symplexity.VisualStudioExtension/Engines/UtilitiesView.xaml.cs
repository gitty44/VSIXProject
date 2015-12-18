//------------------------------------------------------------------------------
// <copyright file="UtilitiesView.xaml.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Symplexity.VisualStudioExtension.Engines
{
    using Microsoft.VisualStudio.Shell;
    using Engines;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;
    

    /// <summary>
    /// Interaction logic for UtilitiesView.
    /// </summary>
    public partial class UtilitiesView : UserControl
    {
        IEngineViewModel engineControlPanel;

        /// <summary>
        /// Initializes a new instance of the <see cref="UtilitiesView"/> class.
        /// </summary>
        public UtilitiesView()
        {
            this.InitializeComponent();
            //this.DataContext = new UtilitiesViewModel();
                     
        }     
    }
}