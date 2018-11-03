using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ezCryptor.Shared.Crypto
{
    public interface ICryptoAlgorithm
    {
        /// <summary>
        /// Gets the name of the algorithm
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the supported key sizes
        /// </summary>
        IEnumerable<int> SupportedKeySizes { get; }

        /// <summary>
        /// Gets the default keys size value
        /// </summary>
        int DefaultKeySize { get; }

        /// <summary>
        /// The crypto key
        /// </summary>
        byte[] Key { get; set; }

        /// <summary>
        /// Encrypts a byte array and write to the output stream
        /// </summary>
        /// <param name="data">The data to encrypt</param>
        /// <param name="output">The stream to write to</param>
        /// <returns></returns>
        bool Encrypt(byte[] data, Stream output);

        /// <summary>
        /// Like <see cref="Encrypt"/>, but in an asynchronous way
        /// </summary>
        Task<bool> EncryptAsync(byte[] data, Stream output);

        /// <summary>
        /// Decrypts a byte array and write to the output stream
        /// </summary>
        /// <param name="data">The data to encrypt</param>
        /// <param name="key">The key to decrypt with</param>
        /// <param name="output">The stream to write to</param>
        /// <returns></returns>
        bool Decrypt(byte[] data, Stream output);

        /// <summary>
        /// Like <see cref="Decrypt"/>, but in an asynchronous way
        /// </summary>
        Task<bool> DecryptAsync(byte[] data, Stream output);

        /// <summary>
        /// Initializes the algorithm
        /// </summary>
        /// <returns>The operation result</returns>
        Task<bool> Initialize();
    }
}
