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
            for (int i = 0; i < 16; i++)
            {
                Value[i] = (byte)(baseValue & 0xFF);
                baseValue >>= 8;
            }
        }
    }

    public class Encrypted {
        public readonly byte[] Ciphertext;
        public readonly int AuthenticationTag;
        public Encrypted(byte[] ciphertext, int authenticationTag)
        {
            this.Ciphertext = ciphertext;
            this.AuthenticationTag = authenticationTag;
        }
    }

    public class Helix
    {
        private byte[] key;

        public Helix(byte[] key)
        {
            this.key = key;
        }

        public Encrypted Encrypt(byte[] plaintext, Nonce nonce)
        {
            return new Encrypted(null, 0);
        }

        public byte[] Decrypt(Encrypted encripted)
        {
            return new byte[0];
        }

    }
}
