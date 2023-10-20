using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly Context _context;
        public DocumentTypeRepository(Context context)
        {
            _context = context;
        }
        public List<DocumentTypeResponse> GetAllDocumentTypes()
        {
            var documentList = _context.DocumentTypes.Select(document => new DocumentTypeResponse
            {
                DocumentTypeId = document.DocumentTypeId,
                DocumentTypeDescription = document.DocumentTypeDescription
            }).ToList();

            return documentList;
        }
    }
}
