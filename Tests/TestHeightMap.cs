using System;
using NUnit.Framework;
using Carto.MapModel;

namespace Tests
{
	[TestFixture()]
	public class TestHeightMap
	{
		private Map map = new Map();
		private Map.ReadReleaser releaser = null;
		
		[SetUp()]
		public void ImportTheMap()
		{
			InputOutput.ReadFile("/Users/jon/Downloads/poolsbrook2011.ocd", map);
			releaser = map.Read();
			

		}
		
		[TearDown()]
		public void CleanupTheMap() 
		{
			releaser.Dispose();
			map = null;
		}
		
		
		[Test()]
		public void TestCase ()
		{
			map.SymdefFromOcadID()
		}
	}
}

