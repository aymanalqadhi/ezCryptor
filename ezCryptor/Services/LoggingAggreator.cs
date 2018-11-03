using System;
using System.ComponentModel.Composition;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ezCryptor.Shared.Services;

namespace ezCryptor.Services
{
    [Export(typeof(ILogger))]
    public class LoggingAggreator : ILogger
    {
        #region Private Fields

        /// <summary>
        /// The logger streams list
        /// </summary>
        private readonly List<StreamWriter> _streams;

        #endregion`

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public LoggingAggreator()
        {
            _streams = new List<StreamWriter>();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Writes to each stream in the internal streams list
        /// </summary>
        /// <param name="format">The format to write in</param>
        /// <param name="args">Writing arguments</param>
        private void WriteToStreams(string format, params object[] args)
          => Parallel.ForEach(_streams, s => s.Write(format, args));

        #endregion

        #region Public Methods

        /// <summary>
        /// Logs a message
        /// </summary>
        /// <param name="level">The logging level</param>
        /// <param name="format">The format of the output</param>
        /// <param name="args">The format representation arguemtns</param>
        public void Log(LoggingLevel level, string format, params object[] args)
        {
            switch (level)
            {
                case LoggingLevel.Trace:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case LoggingLevel.Debug:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;

                case LoggingLevel.Information:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;

                case LoggingLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case LoggingLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case LoggingLevel.Fatal:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
            }

            WriteToStreams("[{0}][{1}] ", DateTime.Now.ToString("%H:%M:%s"), level.ToString());
            Console.ForegroundColor = ConsoleColor.White;

            WriteToStreams(format + '\n', args);
        }

        /// <summary>
        /// Adds streams to the logger streams list
        /// </summary>
        /// <param name="outputStreams">The streams array</param>
        /// <returns>Operation Result</returns>
        public bool AddOutputStreams(params Stream[] outputStreams)
        {
            foreach (var stream in outputStreams)
                _streams.Add(new StreamWriter(stream) { AutoFlush = true });

            return true;
        }

        #endregion
    }
}
