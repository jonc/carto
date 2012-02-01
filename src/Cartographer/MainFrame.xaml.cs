using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Windows.Controls.Ribbon;

namespace Carto.Cartographer
{
    /// <summary>
    /// Interaction logic for MainFrame.xaml
    /// </summary>
    public partial class MainFrame: RibbonWindow
    {
        private readonly AppState appState;

        public MainFrame()
        {
            appState = new AppState(this);

            this.Resources.MergedDictionaries
                .Add(Microsoft.Windows.Controls.Ribbon.PopularApplicationSkins.Office2007Blue);

            InitializeComponent();
        }

        private void OpenCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            appState.Commands.OpenCommand();
        }


    }
}
