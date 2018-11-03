using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.Security.Cryptography;
using System.Collections.Generic;
using ezCryptor.Shared.Crypto;

namespace ezCryptor.Algorithms
{
    [Export(typeof(ICryptoAlgorithm))]
    public class TripleDesAlgorithm : BaseAlgorithm<TripleDESCryptoServiceProvider>, ICryptoAlgorithm
    {
        /// <summary>
        /// Gets the name of the 
        /// </summary>
        public override string Name => "TrippleDES";

        /// <summary>
        /// Gets the supported key sizes
        /// </summary>
        public override IEnumerable<int> SupportedKeySizes => new List<int> { 128, 192 };

        /// <summary>
        /// Gets the default key size value
        /// </summary>
        public override int DefaultKeySize => 192;

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
