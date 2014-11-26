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
		private static readonly byte[] NiceKey = new byte[32] { 
			8, 16, 24, 32, 40, 48, 56, 64, 72, 80, 88, 96, 104, 112, 120, 128,
			136, 144, 152, 160, 168, 176, 184, 192, 200, 208, 216, 224, 232, 240, 248, 0 };

		private static readonly byte[] NiceNonce = new byte[16] { 8, 16, 24, 32, 40, 48, 56, 64, 72, 80, 88, 96, 104, 112, 120, 128 };

		private static readonly byte[] NicePlaintext = Encoding.UTF8.GetBytes("This is some plaintext for tests");


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
			Assert.NotNull(new Phelix(NiceKey));
		}

		[Test]
		public void DecryptWithNiceKeyNullData()
		{
			var phelix = new Phelix(NiceKey);
			byte[] mac;
			Assert.NotNull(phelix);
			Assert.Catch<ArgumentNullException>(() => phelix.Decrypt(null, NiceNonce, out mac));
		}

		[Test]
		public void EncryptWithNiceKeyNullData()
		{
			var phelix = new Phelix(NiceKey);
			byte[] mac;
			Assert.NotNull(phelix);
			Assert.Catch<ArgumentNullException>(() => phelix.Encrypt(null, NiceNonce, out mac));
		}

		[Test]
		public void EncryptWithNiceKeyNicePlainText()
		{
			var phelix = new Phelix(NiceKey);
			byte[] mac;
			byte[] mac2;
			Assert.NotNull(phelix);
			var ciphertext = phelix.Encrypt(NicePlaintext, NiceNonce, out mac);
			Assert.NotNull(ciphertext);
			Assert.NotNull(mac);
			Assert.That(ciphertext, Is.Not.EqualTo(NicePlaintext), "The ciphertext should be different from plaintext");
			var plaintext = phelix.Decrypt(ciphertext, NiceNonce, out mac2);
			Assert.NotNull(plaintext);
			Assert.NotNull(mac2);
			Assert.AreEqual(Phelix.MAC_SIZE / 8, mac2.Length, "MAC Length");
			Assert.That(plaintext, Is.EqualTo(NicePlaintext));
			Assert.That(mac, Is.EquivalentTo(mac2));
		}

	}
}
