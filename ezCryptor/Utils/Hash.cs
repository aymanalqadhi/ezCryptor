using System.Security.Cryptography;

namespace ezCryptor.Utils
{
    public static class Hash
    {
        public static byte[] Md5(byte[] message) => GetHash(message, "MD5");
        public static byte[] SHA1(byte[] message) => GetHash(message, "SHA1");
        public static byte[] SHA256(byte[] message) => GetHash(message, "SHA256");
        public static byte[] SHA512(byte[] message) => GetHash(message, "SHA512");

        private static byte[] GetHash(byte[] message, string algorithm) 
        {
            using (var hash = HashAlgorithm.Create(algorithm))
                return hash.ComputeHash(message);
        }
    }
}
