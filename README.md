# NHibernate.Logging.Serilog
Serilog logger for NHibernate. Works only from NHibernate > 5.0.3(logging refactoring)

### How-To
Add this line to your code   
`NHibernateLogger.SetLoggersFactory(new NHibernate.Logging.Serilog.SerilogLoggerFactory());`
