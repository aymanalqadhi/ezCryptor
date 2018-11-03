using System;
using System.IO;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.Security.Cryptography;
using System.Collections.Generic;
using ezCryptor.Shared.Services;
using ezCryptor.Shared.Crypto;

namespace ezCryptor.Algorithms
{
    [Export(typeof(ICryptoAlgorithm))]
    public class DesAlgorithm : BaseAlgorithm<DESCryptoServiceProvider>, ICryptoAlgorithm
    {
        /// <summary>
        /// Gets the name of the 
        /// </summary>
        public override string Name => "DES";

        /// <summary>
        /// Gets the supported key sizes
        /// </summary>
        public override IEnumerable<int> SupportedKeySizes => new List<int> { 128 };

        /// <summary>
        /// Gets the default key size value
        /// </summary>
        public override int DefaultKeySize => 128;

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
