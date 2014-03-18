using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commons.Crypto
{
	public class EncryptedWithTag
	{
		public readonly byte[] Ciphertext;
		public readonly int AuthenticationTag;

		public EncryptedWithTag(byte[] ciphertext, int authenticationTag)
		{
			this.Ciphertext = ciphertext;
			this.AuthenticationTag = authenticationTag;
		}
	}
}
