﻿using Symplexity.VisualStudioExtension.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Symplexity.VisualStudioExtension.Engines
{
    /// <summary>
    /// Interaction logic for CalcEngineView.xaml
    /// </summary>
    public partial class CalcEngineView : UserControl
    {
        public CalcEngineView()
        {
            InitializeComponent();
            //this.DataContext = new CalcEngineViewModel();
        }
    }
}
