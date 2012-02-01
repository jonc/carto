using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Carto.MapModel;

//The MapViewer coordinates the viewing of the map and the symbol toolbox.
namespace Carto.Cartographer
{
    class MapViewer
    {
        PanAndZoom panAndZoom;
        ListBox symbolList;
        VisualBitmapCache bitmapCache;
        Map map;

        public MapViewer(PanAndZoom panAndZoom, ListBox symbolList)
        {
            this.panAndZoom = panAndZoom;
            this.symbolList = symbolList;

            bitmapCache = new VisualBitmapCache();
            bitmapCache.PanAndZoomControl = panAndZoom;
            panAndZoom.AddLayer(bitmapCache);
        }

        public Map Map
        {
            get {
                return map;
            }
            set {
                map = value;
                bitmapCache.Map = map;
            }
        }
    }
}
