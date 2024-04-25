using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Configuration
{
    public interface IDocumentTypeService
    {
        Task<ResponseMessage> Add(DocumentTypePostDto documentTypePost);
        Task<ResponseMessage> Update(DocumentTypeGetDto documentTypeGet);
        Task<List<DocumentTypeGetDto>> GetAll();
    }
}
