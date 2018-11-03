namespace ezCryptor.Shared.Crypto
{
    /// <summary>
    /// An enum to represent the key hashing method
    /// </summary>
    public enum KeyType : int { MD5_128Bit = 128, SHA1_192Bit = 192, SHA256 = 256, SHA512 = 512 }

    /// <summary>
    /// An enum to represent the key padding method
    /// </summary>
    public enum PaddingMethod { Zeros, PKCS1 }
}
