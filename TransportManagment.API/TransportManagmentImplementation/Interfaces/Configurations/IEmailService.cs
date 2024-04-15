
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Configuration
{
    public interface IEmailService
    {
        Task<ResponseMessage> Send(EmailMetadata emailMetadata);
    }
}
