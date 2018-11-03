using System.IO;

namespace ezCryptor.Shared.Services
{
    /// <summary>
    /// A Base interface of the logging classess
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs a message
        /// </summary>
        /// <param name="level">The logging level</param>
        /// <param name="format">The format of the output</param>
        /// <param name="args">The format representation arguemtns</param>
        void Log(LoggingLevel level, string format, params object[] args);

        /// <summary>
        /// Adds streams to the logger streams list
        /// </summary>
        /// <param name="outputStreams">The streams array</param>
        /// <returns>Operation Result</returns>
        bool AddOutputStreams(params Stream[] outputStream);
    }

    /// <summary>
    /// An enum to represent the logging level
    /// </summary>
    public enum LoggingLevel : int
    {
        Trace, Debug, Information, Warning, Error, Fatal
    }
}
