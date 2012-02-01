using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Carto.MapModel;

namespace Carto.Cartographer
{
    // Root of all application state. Manages basic file management commands, and contains references to sub-objects than manage
    // different parts of the app (e.g., MainFrame, Commands, MapViewer).
    class AppState
    {
        public readonly MainFrame MainFrame;
        public readonly Commands Commands;

        MapViewer mapViewer;
        public MapViewer MapViewer {
            get {return MapViewer; }
        }

        public AppState(MainFrame mainFrame)
        {
            this.MainFrame = mainFrame;
            this.Commands = new Commands(this);
        }

        void CreateMapViewer()
        {
            if (mapViewer == null) {
                mapViewer = new MapViewer(MainFrame.PanAndZoom, MainFrame.SymbolList);
            }
        }

        public void OpenMapFile(string filename)
        {
            Map map = new Map();
            InputOutput.ReadFile(filename, map);

            CreateMapViewer();
            mapViewer.Map = map;
        }
    }
}
