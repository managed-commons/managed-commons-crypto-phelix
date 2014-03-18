using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commons.Crypto.Ciphers
{

	public class Phelix
	{
		private byte[] key;

		public Phelix(byte[] key)
		{
			this.key = key;
		}

		public EncryptedWithTag Encrypt(byte[] plaintext, Nonce nonce)
		{
			return new EncryptedWithTag(null, 0);
		}

		public EncryptedWithTag Encrypt(byte[] plaintext, Nonce nonce, int headersLength)
		{
			return new EncryptedWithTag(null, 0);
		}

		public byte[] Decrypt(EncryptedWithTag encripted)
		{
			return new byte[0];
		}

	}
}
