using ezCryptor.Shared.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace ezCryptor.Services
{
    /// <summary>
    /// The Default progress reporter
    /// </summary>
    [Export(typeof(IApplicationProgressReporter))]
    public class ApplicationProgressReporter : IApplicationProgressReporter
    { 
        #region Public Methods

        /// <summary>
        /// Invokes all registerd callbacks
        /// </summary>
        /// <param name="value"></param>
        public void Report(Tuple<int, string> value) => ProgressUpdated?.Invoke(this, value);

        /// <summary>
        /// An overload to make it handy to call the main method
        /// </summary>
        /// <param name="value">The progress value</param>
        /// <param name="caption">The progress caption</param>
        public void Report(int value, string caption) => Report(new Tuple<int, string>(value, caption));

        /// <summary>
        /// Locks the UI
        /// </summary>
        public void LockUI() => UILockRequested?.Invoke(this, true);

        /// <summary>
        /// Unlocks the UI
        /// </summary>
        public void UnlockUI() => UILockRequested?.Invoke(this, false);

        #endregion

        #region Public Properties

        /// <summary>
        /// An event to fire on progress updates
        /// </summary>
        public event EventHandler<Tuple<int, string>> ProgressUpdated;

        /// <summary>
        /// An event to fire when a UI lock is requested
        /// </summary>
        public event EventHandler<bool> UILockRequested;

        #endregion
    }
}
