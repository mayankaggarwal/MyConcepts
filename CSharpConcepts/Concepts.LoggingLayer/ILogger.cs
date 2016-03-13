using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concepts.LoggingLayer
{
    /// <summary>
    /// Defines a common interface specification
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Writes a message to log
        /// </summary>
        /// <param name="category">A string of the category to write</param>
        /// <param name="level">LogLevel value of the level of the message</param>
        /// <param name="message">A String of the message to write to the log</param>
        void WriteMessage(string category, LogLevel level, string message); 
    }

    public enum LogLevel
    {
        FATAL = 0,
        ERROR = 1,
        WARN = 2,
        INFO = 3,
        VERBOSE = 4
    }
}
