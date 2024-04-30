using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagmentImplementation.Interfaces.Common
{
    public interface ILoggerManagerService
    {

        public void LogCreate(string module, string createdById, string message);
        public void LogUpdate( string module, string createdById, string message);
        public void LogExcption(string module, string createdById, string message);

    }
}
