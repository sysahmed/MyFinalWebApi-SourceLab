using log4net.Core;

namespace MyApp.Demo.Core.Aspect.Autofac.Logging.Layouts
{
    internal class SerializableLogEvent
    {
        private LoggingEvent loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            this.loggingEvent = loggingEvent;
        }
    }
}