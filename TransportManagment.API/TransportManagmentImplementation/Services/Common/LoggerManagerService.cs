using Microsoft.Extensions.Logging;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.Interfaces.Common;

namespace TransportManagmentImplementation.Services.Common
{
    public class LoggerManagerService : ILoggerManagerService
    {

        private readonly ILogger<LoggerManagerService> _logger;
        public LoggerManagerService(ILogger<LoggerManagerService> logger) {
        
        _logger= logger;
        
        }
        public void LogCreate(string module,string createdById, string message)
        {
            LogContext.PushProperty("ChangedOn", DateTime.Now.ToString());
            LogContext.PushProperty("Module", module);
            LogContext.PushProperty("UserId", createdById);

            _logger.LogInformation("Ban Body Added Successfully on {Created}", DateTime.Now);
        }

        public void LogExcption(string module, string createdById, string message)
        {

            LogContext.PushProperty("ChangedOn", DateTime.Now.ToString());
            LogContext.PushProperty("Module", module);
            LogContext.PushProperty("UserId", createdById);

            _logger.LogInformation("Ban Body Added Successfully on {Created}", DateTime.Now);
        }

        public void LogUpdate( string module, string createdById, string message)
        {
            LogContext.PushProperty("ChangedOn", DateTime.Now.ToString());
            LogContext.PushProperty("Module", module);
            LogContext.PushProperty("UserId", createdById);

            _logger.LogInformation("Ban Body Added Successfully on {Created}", DateTime.Now);
        }
    }
}
