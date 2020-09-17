using Serilog;
using Serilog.Core;

namespace NHibernate.Logging.Serilog
{
	/// <summary>
	/// Factory to create SerilogLogger
	/// </summary>
	public class SerilogLoggerFactory : INHibernateLoggerFactory
	{
		private readonly ILogger _log;

		public SerilogLoggerFactory(ILogger log = null)
		{
			_log = log;
		}
		
		public INHibernateLogger LoggerFor(string keyName)
		{
			var contextLogger = (_log ?? Log.Logger).ForContext(Constants.SourceContextPropertyName, keyName);
			return new SerilogLogger(contextLogger);
		}

		public INHibernateLogger LoggerFor(System.Type type)
		{
			var contextLogger = (_log ?? Log.Logger).ForContext(type);
			return new SerilogLogger(contextLogger);
		}
	}
}
