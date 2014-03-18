using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using Commons.Crypto.Ciphers;

namespace Unit.Commons.Crypto.Ciphers
{

	[TestFixture]
	public class TestPhelix
	{
		[Test]
		public void ConstructWithNullKeyThrowsArgumentNullException()
		{
			Assert.Catch<ArgumentNullException>(() => new Phelix(null));
		}

		[Test]
		public void ConstructWithShorterKeyThrowsArgumentException()
		{
			Assert.Catch<ArgumentException>(() => new Phelix(new byte[4] { 8, 16, 24, 32 }));
		}

		[Test]
		public void ConstructWithLongerKeyThrowsArgumentException()
		{
			Assert.Catch<ArgumentException>(() => new Phelix(new byte[33] { 8, 16, 24, 32, 40, 48, 56, 64, 72, 80, 88, 96, 104, 112, 120, 128, 
				136, 144, 152, 160, 168, 176, 184, 192, 200, 208, 216, 224, 232, 240, 248, 0, 8 }));
		}

		[Test]
		public void ConstructWithNiceKey()
		{
			Assert.NotNull(new Phelix(new byte[32] { 8, 16, 24, 32, 40, 48, 56, 64, 72, 80, 88, 96, 104, 112, 120, 128,
													136, 144, 152, 160, 168, 176, 184, 192, 200, 208, 216, 224, 232, 240, 248, 0}));
		}
	}
}
