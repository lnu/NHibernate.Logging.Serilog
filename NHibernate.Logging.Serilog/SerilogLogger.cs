using System;
using System.Collections.Generic;
using Serilog;
using Serilog.Events;

namespace NHibernate.Logging.Serilog
{
    class SerilogLogger : INHibernateLogger
    {
        ILogger _contextLogger;

        public SerilogLogger(ILogger serilogLogger)
        {
            _contextLogger = serilogLogger ?? throw new ArgumentNullException(nameof(serilogLogger));
        }

        private static readonly Dictionary<NHibernateLogLevel, LogEventLevel> MapLevels = new Dictionary<NHibernateLogLevel, LogEventLevel>
        {
            { NHibernateLogLevel.Trace, LogEventLevel.Verbose },
            { NHibernateLogLevel.Info, LogEventLevel.Information },
            { NHibernateLogLevel.Debug, LogEventLevel.Debug },
            { NHibernateLogLevel.Warn, LogEventLevel.Warning },
            { NHibernateLogLevel.Error, LogEventLevel.Error },
            { NHibernateLogLevel.Fatal, LogEventLevel.Fatal }
        };


        public bool IsEnabled(NHibernateLogLevel logLevel)
        {
            // special case because for Serilog there's no none level
            return logLevel == NHibernateLogLevel.None || _contextLogger.IsEnabled(MapLevels[logLevel]);
        }

        public void Log(NHibernateLogLevel logLevel, NHibernateLogValues state, Exception exception)
        {
            _contextLogger.Write(MapLevels[logLevel], exception, state.Format, state.Args);
        }
    }
}
