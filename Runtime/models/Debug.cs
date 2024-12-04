using System;

namespace DynamicPixels.GameService.Models
{
    
    /// <summary>
    ///     Represents Game Service DebugLocation Class
    /// </summary>
    public enum DebugLocation
    {
        /// <summary>
        ///     Happened In All Systems
        /// </summary>
        All,

        /// <summary>
        ///     Happened In Core
        /// </summary>
        Internal,

        /// <summary>
        ///     Happened In Http System
        /// </summary>
        Http,

        /// <summary>
        ///     Happened In Connection System
        /// </summary>
        Connection,

        /// <summary>
        ///     Happened In Chat System
        /// </summary>
        Chat,

        /// <summary>
        ///     Happened In Voice System
        /// </summary>
        Voice,

        /// <summary>
        ///     Happened In Notification System
        /// </summary>
        Notification,
        
        /// <summary>
        ///     Happened In Social System
        /// </summary>
        Social,

        /// <summary>
        ///     Happened In WebSocket System
        /// </summary>
        WebSocket,
    }
    
    /// <summary>
    ///  Represents LogType Class in Debug System
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// Normal Log
        /// </summary>
        Normal,
        /// <summary>
        /// Error Log
        /// </summary>
        Error,
        /// <summary>
        /// Exception Log
        /// </summary>
        Exception
    }
    
    /// <summary>
    /// Represents Debug Class
    /// </summary>
    public class DebugArgs
    {
        /// <summary>
        /// the Debug Type (Normal or Error)
        /// </summary>
        public LogType LogTypeType;

        /// <summary>
        /// the Debug Location
        /// </summary>
        public DebugLocation Where;
        

        /// <summary>
        /// the Debug Data
        /// </summary>
        public string Data;
        
        
        /// <summary>
        /// the Debug Exception
        /// NullAble, Only Available When LogType is Exception
        /// </summary>
        public Exception Exception;
    }
}