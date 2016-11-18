using System;
using System.Collections.Generic;
using ReportPortal.Client.Models;
using ReportPortal.Client.Requests;
using ReportPortal.Shared;
using log4net.Appender;
using log4net.Core;

namespace ReportPortal.Addins.SpecFlowPlugin.Sample
{
    /// <summary>
    /// Log4Net custom adapter for reporting logs directly to Report Portal.
    /// Logs will be viewable under current test item from shared context.
    /// </summary>
    public class ReportPortalAppender : AppenderSkeleton
    {
        private readonly Dictionary<Level, LogLevel> _levelMap = new Dictionary<Level, LogLevel>();
        public ReportPortalAppender()
        {
            _levelMap[Level.Fatal] = LogLevel.Error;
            _levelMap[Level.Error] = LogLevel.Error;
            _levelMap[Level.Warn] = LogLevel.Warning;
            _levelMap[Level.Info] = LogLevel.Info;
            _levelMap[Level.Debug] = LogLevel.Debug;
            _levelMap[Level.Trace] = LogLevel.Trace;
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            if (Bridge.Context.TestId != null)
            {
                var level = LogLevel.Info;
                if (_levelMap.ContainsKey(loggingEvent.Level))
                {
                    level = _levelMap[loggingEvent.Level];
                }

                var request = new AddLogItemRequest
                {
                    TestItemId = Bridge.Context.TestId,
                    Level = level,
                    Time = DateTime.UtcNow,
                    Text = loggingEvent.RenderedMessage
                };

                try
                {
                    Bridge.Service.AddLogItem(request);
                }
                catch (Exception)
                {
                    // Ignoring
                }
            }
        }
    }
}
