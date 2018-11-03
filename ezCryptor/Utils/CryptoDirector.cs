using ezCryptor.Shared.Crypto;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ezCryptor.Utils
{
    public class CryptoDirector
    {
        #region Private Fields

        /// <summary>
        /// The in, out streams
        /// </summary>
        private readonly Stream _from, _to;

        /// <summary>
        /// The chunk size (used in encryption only)
        /// </summary>
        private readonly uint _chunkSize;

        /// <summary>
        /// The crypto algorithm used in encrypting & decrypting
        /// </summary>
        private readonly ICryptoAlgorithm _algorithm;

        /// <summary>
        /// The crypto mode (either encrypting or decrypting)
        /// </summary>
        private readonly RedirectionMode _mode;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="algorithm">The crypto alogrithm</param>
        /// <param name="from">This source stream</param>
        /// <param name="to">The destination stream</param>
        /// <param name="mode">The crypto mode</param>
        /// <param name="chunkSize">The encryption chunk size</param>
        public CryptoDirector(ICryptoAlgorithm algorithm, Stream from, Stream to, RedirectionMode mode, uint chunkSize = 1024 * 1024)
        {
            /**     Validate required parameters    **/
            if (algorithm == null) throw new ArgumentNullException("algorithm");
            if (from == null) throw new ArgumentNullException("from");
            if (to == null) throw new ArgumentNullException("to");

            /**     Initiaize private fileds **/
            _algorithm = algorithm;
            _from = from;
            _to = to;
            _chunkSize = chunkSize;
            _mode = mode;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Encrypts or decrypts a chunk of data
        /// </summary>
        /// <param name="callback">Reports the current progress</param>
        /// <returns>The operation result</returns>
        public async Task<bool> ProcessChunk(Action<double> callback)
        {
            if (!_from.CanRead) return false;
            callback?.Invoke((double)_from.Position / _from.Length);

            if (_mode == RedirectionMode.Decrypt)
            {
                if (_from.Length - _from.Position < 20) return false;

                var read = await _from.ReadAsync(new byte[16], 0, 16);
                if (read != 16) throw new InvalidDataException("Could not read IV");

                var chunkLen = new byte[4];
                read = await _from.ReadAsync(chunkLen, 0, chunkLen.Length);
                if (read != chunkLen.Length) throw new InvalidDataException("Could not read chunk size");

                var len = BitConverter.ToInt32(chunkLen, 0);
                var buffer = new byte[len];
                read = await _from.ReadAsync(buffer, 0, buffer.Length);

                if (read != buffer.Length) throw new InvalidDataException("Invalid Chunk");
                if (!await _algorithm.DecryptAsync(buffer, _to)) throw new InvalidOperationException("Could not decrypt chunk!");
            }
            else
            {
                await _to.WriteAsync(new byte[16], 0, 16);

                var chunk = new byte[_chunkSize];
                var count = await _from.ReadAsync(chunk, 0, chunk.Length);

                if (count <= 0) return false;

                using (var mem = new MemoryStream())
                {
                    if (!await _algorithm.EncryptAsync(chunk, mem)) throw new InvalidOperationException("Could not encrypt chunk!");
                    var encBlk = mem.ToArray();

                    await _to.WriteAsync(BitConverter.GetBytes(encBlk.Length), 0, 4);
                    await _to.WriteAsync(encBlk, 0, encBlk.Length);
                }
            }

            return true;
        }

        #endregion
    }

    /// <summary>
    /// An enum to represent the 
    /// </summary>
    public enum RedirectionMode { Encrypt, Decrypt }
}
