using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commons.Crypto.Ciphers
{

	public class Phelix
	{
		public const int NONCE_SIZE = 128;  /* size of nonce        in bits */
		public const int MAC_SIZE = 128;    /* size of full mac tag in bits */
		public const int KEY_SIZE = 256;    /* size of full key     in bits */

		private readonly byte[] _key;

		public Phelix(byte[] key)
		{
			if (key == null)
				throw new ArgumentNullException("key");
			if (key.Length != (KEY_SIZE / 8))
				throw new ArgumentException("The key MUST have " + KEY_SIZE + " bits!", "key");
			_key = key;
		}

		public byte[] Encrypt(byte[] plaintext, byte[] nonce, out byte[] mac)
		{
			ConstrainNonce(nonce);
			mac = new byte[MAC_SIZE / 8];
			return plaintext;
		}

		public byte[] Encrypt(byte[] plaintext, byte[] nonce, int headersLength, out byte[] mac)
		{
			ConstrainNonce(nonce);
			mac = new byte[MAC_SIZE / 8];
			return plaintext;
		}

		public byte[] Decrypt(byte[] ciphertext, byte[] nonce, out byte[] mac)
		{
			ConstrainNonce(nonce);
			mac = new byte[MAC_SIZE / 8];
			return ciphertext;
		}

		private static void ConstrainNonce(byte[] nonce)
		{
			if (nonce == null)
				throw new ArgumentNullException("nonce");
			if (nonce.Length != (KEY_SIZE / 8))
				throw new ArgumentException("The nonce MUST have " + NONCE_SIZE + " bits!", "nonce");
		}

	}
}
