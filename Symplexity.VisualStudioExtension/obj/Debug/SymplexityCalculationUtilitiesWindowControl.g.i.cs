﻿#pragma checksum "..\..\SymplexityCalculationUtilitiesWindowControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A5F5CC477A532E2F715A175A3B922612"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Symplexity.VisualStudioExtension {
    
    
    /// <summary>
    /// SymplexityCalculationUtilitiesWindowControl
    /// </summary>
    public partial class SymplexityCalculationUtilitiesWindowControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\SymplexityCalculationUtilitiesWindowControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Symplexity.VisualStudioExtension.SymplexityCalculationUtilitiesWindowControl MyToolWindow;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\SymplexityCalculationUtilitiesWindowControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl tbcMainTab;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\SymplexityCalculationUtilitiesWindowControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tbpTimeAndAttendance;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\SymplexityCalculationUtilitiesWindowControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl tabFiles;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\SymplexityCalculationUtilitiesWindowControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tabItemCalcFiles;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\SymplexityCalculationUtilitiesWindowControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listCalcFiles;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\SymplexityCalculationUtilitiesWindowControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView treeTemplate;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\SymplexityCalculationUtilitiesWindowControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listAdvancedCalcFiles;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Symplexity.VisualStudioExtension;component/symplexitycalculationutilitieswindowc" +
                    "ontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SymplexityCalculationUtilitiesWindowControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.MyToolWindow = ((Symplexity.VisualStudioExtension.SymplexityCalculationUtilitiesWindowControl)(target));
            return;
            case 2:
            this.tbcMainTab = ((System.Windows.Controls.TabControl)(target));
            
            #line 12 "..\..\SymplexityCalculationUtilitiesWindowControl.xaml"
            this.tbcMainTab.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.tbcMainTab_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbpTimeAndAttendance = ((System.Windows.Controls.TabItem)(target));
            return;
            case 4:
            this.tabFiles = ((System.Windows.Controls.TabControl)(target));
            return;
            case 5:
            this.tabItemCalcFiles = ((System.Windows.Controls.TabItem)(target));
            return;
            case 6:
            this.listCalcFiles = ((System.Windows.Controls.ListBox)(target));
            return;
            case 7:
            this.treeTemplate = ((System.Windows.Controls.TreeView)(target));
            return;
            case 8:
            this.listAdvancedCalcFiles = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

