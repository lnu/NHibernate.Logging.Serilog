using Serilog;
using Serilog.Core;

namespace NHibernate.Logging.Serilog
{
	/// <summary>
	/// Factory to create SerilogLogger
	/// </summary>
	public class SerilogLoggerFactory : INHibernateLoggerFactory
	{
		public INHibernateLogger LoggerFor(string keyName)
		{
			var contextLogger = Log.Logger.ForContext(Constants.SourceContextPropertyName, keyName);
			return new SerilogLogger(contextLogger);
		}

		public INHibernateLogger LoggerFor(System.Type type)
		{
			var contextLogger = Log.Logger.ForContext(type);
			return new SerilogLogger(contextLogger);
		}
	}
}
