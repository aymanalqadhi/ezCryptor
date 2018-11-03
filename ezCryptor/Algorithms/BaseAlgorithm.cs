using ezCryptor.Shared.Crypto;
using ezCryptor.Shared.Services;
using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace ezCryptor.Algorithms
{
    public abstract class BaseAlgorithm<TAlgorithm> : ICryptoAlgorithm
        where TAlgorithm : SymmetricAlgorithm
    {
        #region Private Fields

        /// <summary>
        /// Thread safety lock object
        /// </summary>
        protected readonly object _lock = new object();

        /// <summary>
        /// The framework provided implementation of the symmetric algorithm
        /// </summary>
        protected SymmetricAlgorithm _algorithm;

        /// <summary>
        /// The Encryptor created by <see cref="SymmetricAlgorithm"/>
        /// </summary>
        protected ICryptoTransform _encryptor;

        /// <summary>
        /// The Decryptor created by <see cref="SymmetricAlgorithm"/>
        /// </summary>
        protected ICryptoTransform _decryptor;

        /// <summary>
        /// The crypto key
        /// </summary>
        protected byte[] _key;

        /// <summary>
        /// A DI injected service to manage logs
        /// </summary>
        [Import]
        protected ILogger _logger;

        #endregion

        #region Public Methods


        public virtual byte[] Key
        {
            get { return _key; }
            set
            {
                if (value == null || SupportedKeySizes.All(k => k / 8 != value.Length))
                    throw new InvalidOperationException("Invalid Key!");

                _key = value;

                _encryptor = _algorithm.CreateEncryptor(_key, new byte[16]);
                _decryptor = _algorithm.CreateDecryptor(_key, new byte[16]);
            }
        }

        public abstract string Name { get; }
        public abstract IEnumerable<int> SupportedKeySizes { get; }
        public abstract int DefaultKeySize { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Encrypts a byte array and write to the output stream
        /// </summary>
        /// <param name="data">The data to encrypt</param>
        /// <param name="output">The stream to write to</param>
        /// <param name="statusCallback">The progress reporting callback</param>
        /// <returns></returns>
        public async Task<bool> EncryptAsync(byte[] data, Stream output)
        {
            try
            {
                var ac = new CryptoStream(output, _encryptor, CryptoStreamMode.Write);

                await ac.WriteAsync(data, 0, data.Length);
                await ac.FlushAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger?.Log(LoggingLevel.Error, ex.Message);
                return false;
            }
        }

        /// <summary>
        /// A sync wrapper around <see cref="EncryptAsync(byte[], Stream)"/>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public bool Encrypt(byte[] data, Stream output) => EncryptAsync(data, output).Result;

        /// <summary>
        /// Decrypts a byte array and write to the output stream
        /// </summary>
        /// <param name="data">The data to encrypt</param>
        /// <param name="output">The stream to write to</param>
        /// <param name="statusCallback">The progress reporting callback</param>
        /// <returns></returns>
        public async Task<bool> DecryptAsync(byte[] data, Stream output)
        {
            try
            {
                var ac = new CryptoStream(output, _decryptor, CryptoStreamMode.Write);

                await ac.WriteAsync(data, 0, data.Length);
                await ac.FlushAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger?.Log(LoggingLevel.Error, ex.Message);
                return false;
            }
        }


        /// <summary>
        /// A sync wrapper around <see cref="DecryptAsync(byte[], Stream)"/>
        /// </summary>
        public bool Decrypt(byte[] data, Stream output) => DecryptAsync(data, output).Result;

        /// <summary>
        /// Used to initialize the algorithm
        /// </summary>
        /// <returns></returns>
        public abstract Task<bool> Initialize();

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Disposes the object disposable fileds
        /// </summary>
        public void Dispose()
        {
            _algorithm.Dispose();
        }

        #endregion
    }
}
