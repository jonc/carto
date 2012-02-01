using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;

namespace Carto.Cartographer
{
    // Contains all the commands for the application. They are called from the main windows command handlers.
    class Commands
    {
        AppState appState;

        public Commands(AppState appState)
        {
            this.appState = appState;
        }

        public void OpenCommand()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = ".ocd";
            dialog.Filter = MiscText.OcadFiles + "|*.ocd|" + MiscText.AllFiles + "|*.*";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog(appState.MainFrame) == true) {
                appState.OpenMapFile(dialog.FileName);
            }
        }
    }
}
