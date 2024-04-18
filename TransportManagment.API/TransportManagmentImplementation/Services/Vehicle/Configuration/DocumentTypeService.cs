using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Configuration;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;
using static TransportManagmentInfrustructure.Enums.CommonEnum;

namespace TransportManagmentImplementation.Services.Vehicle.Configuration
{
    public class DocumentTypeService :IDocumentTypeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public DocumentTypeService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResponseMessage> Add(DocumentTypePostDto documentTypePost)
        {
            try
            {
                var documentType = new DocumentType
                {
                    FileName = documentTypePost.FileName,
                    FileExtentions = Enum.Parse<FileExtentions>(documentTypePost.FileExtentions),
                    IsPermanentRequired = documentTypePost.IsPermanentRequired,
                    IsTemporaryRequired = documentTypePost.IsTemporaryRequired,
                    CreatedById = documentTypePost.CreatedById,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };

                await _dbContext.DocumentTypes.AddAsync(documentType);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "DocumentType Added Successfully !!!"
                };
            }
            catch (Exception ex)
            {
                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<List<DocumentTypeGetDto>> GetAll()
        {
            var documentTypes = await _dbContext.DocumentTypes.AsNoTracking().ToListAsync();
            var documentTypeDtos = _mapper.Map<List<DocumentTypeGetDto>>(documentTypes);
            return documentTypeDtos;
        }

        public async Task<ResponseMessage> Update(DocumentTypeGetDto documentTypeGet)
        {
            try
            {
                var documentType = await _dbContext.DocumentTypes.FindAsync(documentTypeGet.Id);
                if (documentType != null)
                {
                    documentType.FileName = documentTypeGet.FileName;
                    documentType.FileExtentions = Enum.Parse<FileExtentions>(documentTypeGet.FileExtentions);
                    documentType.IsPermanentRequired = documentTypeGet.IsPermanentRequired;
                    documentType.IsTemporaryRequired = documentTypeGet.IsTemporaryRequired;

                    documentType.IsActive = documentTypeGet.IsActive;

                    await _dbContext.SaveChangesAsync();

                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "DocumentType Updated Successfully !!!"
                    };
                }
                else
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "DocumentType Not Found !!!"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
