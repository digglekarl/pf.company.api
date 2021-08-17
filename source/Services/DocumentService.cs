using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services
{
    public class DocumentService : IDocumentService
    {
        private IBaseRepository baseRepository;
        public DocumentService(IBaseRepository baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public List<DocumentFile> Get()
        {
            var documentFiles = new List<DocumentFile>();
            var documents = this.baseRepository.Get<Document>(Repositories.Queries.Documents.GetAll);
            documents.ForEach(document =>
            {
                var file = this.baseRepository.Get<File>(document.FileId, Repositories.Queries.Files.GetSingle, new { ID = document.FileId });
                var documentFile = new DocumentFile
                {
                    Document = document,
                    File = file
                };

                documentFiles.Add(documentFile);
            });

            return documentFiles;
        }

        public DocumentFile Get(long id)
        {
            var document = this.baseRepository.Get<Document>(id, Repositories.Queries.Documents.GetSingle, new { ID = id });
            var file = this.baseRepository.Get<File>(document.FileId, Repositories.Queries.Files.GetSingle, new { ID = document.FileId });

            return new DocumentFile
            {
                Document = document,
                File = file
            };
        }

        public bool Create(Document document)
        {
            return this.baseRepository.Create(document, Repositories.Queries.Documents.Create, new { NAME = document.DocumentName, RENEWALDATE = document.RenewalDate, COMPANYID = document.CompanyId, FILEID = document.FileId, DOCUMENTTYPEID = document.DocumentTypeId });
        }

        public bool Update(Document document)
        {
            return this.baseRepository.Update(document, Repositories.Queries.Documents.Update, new { ID = document.Id, NAME = document.DocumentName, RENEWALDATE = document.RenewalDate, COMPANYID = document.CompanyId });
        }

        public bool Delete(long id)
        {
            return this.baseRepository.Delete(id, Repositories.Queries.Documents.Delete, new { ID = id });
        }

    }
}
