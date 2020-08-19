using System;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace CKMStoCFD_Log
{
    public class Log
    {
        private static Logger log;

        public static void Init()
        {
            InitLogging("CKMStoCFD_Log.txt");
        }
        public static void Init(string filename)
        {
            InitLogging(filename);
        }

        private static void InitLogging(string filename)
        {
            var config = new LoggingConfiguration();
            var fileTarget = new FileTarget();
            fileTarget.FileName = filename;
            fileTarget.Layout = "${longdate}|${level:uppercase=true}|thread:${threadid}|${message}${onexception:inner=${newline}${exception:format=tostring}}";
            fileTarget.ArchiveEvery = FileArchivePeriod.Day;
            fileTarget.MaxArchiveFiles = 7;
            config.AddRule(LogLevel.Trace, LogLevel.Fatal, fileTarget, "*");
            LogManager.Configuration = config;
            log = LogManager.GetCurrentClassLogger();
        }
        public static void Info(string st)
        {
            log.Info(st);
        }
        public static void Debug(string st)
        {
            log.Debug(st);
        }
        public static void Trace(string st)
        {
            log.Trace(st);
        }
        public static void Warn(string st)
        {
            log.Warn(st);
        }
        public static void Error(string st)
        {
            log.Error(st);
        }
        public static void Error(Exception ex, string st)
        {
            log.Error(ex, st);
        }
        public static void Fatal(string st)
        {
            log.Fatal(st);
        }
        public static void Fatal(Exception ex, string st)
        {
            log.Fatal(ex, st);
        }
    }
}
