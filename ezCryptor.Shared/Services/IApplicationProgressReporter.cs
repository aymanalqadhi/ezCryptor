using System;
using System.Collections.Generic;

namespace ezCryptor.Shared.Services
{
    /// <summary>
    /// An interface to represent the application progress reporter
    /// </summary>
    public interface IApplicationProgressReporter : IProgress<Tuple<int, string>>
    {
        /// <summary>
        /// An overload to make it handy to call the main method
        /// </summary>
        /// <param name="value">The progress value</param>
        /// <param name="caption">The progress caption</param>
        void Report(int value, string caption);

        /// <summary>
        /// Locks the UI
        /// </summary>
        void LockUI();

        /// <summary>
        /// Unlocks the UI
        /// </summary>
        void UnlockUI();

        /// <summary>
        /// An event to fire on progress updates
        /// </summary>
        event EventHandler<Tuple<int, string>> ProgressUpdated;

        /// <summary>
        /// An event to fire when a UI lock is requested
        /// </summary>
        event EventHandler<bool> UILockRequested;
    }
}
