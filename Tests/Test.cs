using System;
using NUnit.Framework;
using Carto.MapModel;
using System.Collections.Generic;

namespace Carto.Tests
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void TestEmpty ()
		{
			Map map = new Map();
			var resolver = map.Read();
			ICollection<Symbol> allSymbols = map.AllSymbols;
			resolver.Dispose();
			Assert.That( allSymbols.Count == 0 );
		}
		
		[Test()]
		public void AddASymbol()
		{
			Map map = new Map();
			var resolver = map.Write();
			Glyph glyph = new Glyph();
			resolver.Dispose();
		}
	}
}

