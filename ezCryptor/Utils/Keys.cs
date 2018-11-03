using ezCryptor.Shared.Crypto;
using System.Text;

namespace ezCryptor.Utils
{
    public static class Keys
    {
        public static byte[] GetKey(string password, KeyType keySize)
        {
            switch (keySize)
            {
                case KeyType.MD5_128Bit:
                    return Hash.Md5(Encoding.UTF8.GetBytes(password));
                case KeyType.SHA1_192Bit:
                    return Hash.SHA1(Encoding.UTF8.GetBytes(password));
                case KeyType.SHA256:
                    return Hash.SHA256(Encoding.UTF8.GetBytes(password));
                case KeyType.SHA512:
                    return Hash.SHA512(Encoding.UTF8.GetBytes(password));
                default:
                    return Hash.SHA256(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
