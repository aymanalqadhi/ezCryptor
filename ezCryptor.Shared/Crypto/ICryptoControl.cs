namespace ezCryptor.Shared.Crypto
{
    public interface ICryptoControl
    {
        /// <summary>
        /// The title of the control
        /// </summary>
        string Title { get; }

        /// <summary>
        /// The Selected Algorithm
        /// </summary>
        ICryptoAlgorithm SelectedAlgorithm { get; set; }

        /// <summary>
        /// Chunk size in bytes
        /// </summary>
        uint ChunkSize { get; set; }

        /// <summary>
        /// The selected key size
        /// </summary>
        int KeySize { get; set; }
    }
}
