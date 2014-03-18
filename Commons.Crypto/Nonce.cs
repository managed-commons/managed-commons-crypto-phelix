using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commons.Crypto
{
	public class Nonce
	{
		public readonly byte[] Value;

		public Nonce(long baseValue)
		{
			Value = new byte[16];
			for (int i = 0; i < 16; i++) {
				Value[i] = (byte)(baseValue & 0xFF);
				baseValue >>= 8;
			}
		}
	}
}
