# NHibernate.Logging.Serilog
Serilog logger for NHibernate. Works only from NHibernate > 5.1.0(logging refactoring)

### How-To
Add this line to your code:   
`NHibernateLogger.SetLoggersFactory(new NHibernate.Logging.Serilog.SerilogLoggerFactory());`

Then in your config file you can configure the logging level like this(logging NHibernate error and NHibernate sql statements to a rollingfile):   
```
<appSettings>
    <!-- serilog configuration-->
    <add key="serilog:minimum-level" value="Error" />
    <add key="serilog:minimum-level:override:NHibernate" value="Error" />
    <add key="serilog:minimum-level:override:NHibernate.SQL" value="Debug" />
    <add key="serilog:using:RollingFile" value="Serilog.Sinks.RollingFile" />
    <add key="serilog:write-to:RollingFile.pathFormat" value="C:\temp\logs-{Date}_.txt" />
</appSettings>
```

You need https://github.com/serilog/serilog-settings-appsettings to configure Serilog from a config file and https://github.com/serilog/serilog-sinks-rollingfile to log to a rolling file.
