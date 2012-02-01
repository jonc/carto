using System;
using System.Drawing;
using NUnit.Framework;
using Carto.MapModel;

namespace Carto.Tests
{
	[TestFixture()]
	public class TestLoad
	{
		[Test()]
		public void TestPoolsbrookLoad ()
		{
			Map map = new Map ();
			int version = InputOutput.ReadFile ("/Users/jon/Downloads/poolsbrook2011.ocd", map);
			Assert.AreEqual (8, version);
			Map.ReadReleaser releaser = map.Read ();
			Console.WriteLine (map.Template.absoluteFileName);
			Console.WriteLine (map.Bounds);
			releaser.Dispose ();
		}
		
		[Test()]
		public void TestPoolsbrookWrite ()
		{
			Map map = new Map ();
			int version = InputOutput.ReadFile ("/Users/jon/Downloads/poolsbrook2011.ocd", map);
			InputOutput.WriteFile ("/Users/jon/testWrite.ocd", map, 9);
			Map map2 = new Map ();
			version = InputOutput.ReadFile ("/Users/jon/testWrite.ocd", map2);
			Assert.AreEqual (9, version);
		}
		
		[Test()]
		public void TestGetContours ()
		{
			Map map = new Map ();
			int version = InputOutput.ReadFile ("/Users/jon/Downloads/poolsbrook2011.ocd", map);
			var releaser = map.Read ();
			foreach (Symbol sym in map.AllSymbols) {
				if (sym.Definition.OcadID == 101000 || sym.Definition.OcadID == 102000) {
					Console.WriteLine (sym.Definition.Name + " " + sym.GetType ().ToString ());
					Console.WriteLine (sym.BoundingBox);
					LineSymbol contour = (LineSymbol)sym;
					if (contour.Path.IsClosedCurve) {
						Console.WriteLine (contour.Path.Area ());
					} else {
						Console.WriteLine ("Not Closed");
					}
				}
			}
			releaser.Dispose ();
		}
		
		[Test()]
		public void GetContourPath ()
		{
			var map = new Map ();
			int version = InputOutput.ReadFile ("/Users/jon/Downloads/poolsbrook2011.ocd", map);
			var releaser = map.Read ();
			foreach (var sym in map.AllSymbols) {
				if (sym.Definition.OcadID == 101000 || sym.Definition.OcadID == 102000) {
					LineSymbol contour = (LineSymbol)sym;
					var kinds = contour.Path.PointKinds;
					foreach (var point in contour.Path.Points) {
						Console.WriteLine (point);
					}
					Console.WriteLine (" --- ");
					foreach (var kind in kinds) {
						Console.WriteLine (kind);
					}
					Console.WriteLine (" --- ");
					foreach (var point in contour.Path.FlattenedPoints) {
						Console.WriteLine (point);
					}
					break;
				}
			}
			releaser.Dispose ();
		}
	}
}

