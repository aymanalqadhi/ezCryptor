using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.Security.Cryptography;
using System.Collections.Generic;
using ezCryptor.Shared.Crypto;

namespace ezCryptor.Algorithms
{
    [Export(typeof(ICryptoAlgorithm))]
    public class AesAlgorithm : BaseAlgorithm<AesManaged>, ICryptoAlgorithm
    {
        /// <summary>
        /// Gets the name of the 
        /// </summary>
        public override string Name => "AES";

        /// <summary>
        /// Gets the supported key sizes
        /// </summary>
        public override IEnumerable<int> SupportedKeySizes => new []{ 128, 192, 256 };

        /// <summary>
        /// Gets the default key size value
        /// </summary>
        public override int DefaultKeySize => 256;

        /// <summary>
        /// Initializes the algorithm
        /// </summary>
        /// <returns>The operation result</returns>
        public override Task<bool> Initialize()
        {
            _algorithm = new RijndaelManaged
            {
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            return Task.FromResult(true);
        }
    }
}
