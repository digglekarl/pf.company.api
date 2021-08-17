using api.Models;
using api.Repositories;
using api.Repositories.Interfaces;
using api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services
{
    public class FileService : IFileService
    {
        private IBaseRepository fileRepository;

        public FileService(IBaseRepository fileRepository)
        {
            this.fileRepository = fileRepository;
        }

        public bool Create(UploadFile file)
        {
            if (file.File.Length > 0)
            {
                var content = new byte[0];
                using (var stream = file.File.OpenReadStream())
                {
                    content = new byte[file.File.Length];
                    stream.Read(content, 0, (int)file.File.Length);
                }

                var documentFile = new File
                {
                    Content = content,
                    Name = file.File.FileName,
                    Size = file.File.Length / 1024,
                    UploadDate = DateTime.Now,
                    CompanyId = file.CompanyId
                };

                return this.fileRepository.Create(documentFile, Repositories.Queries.Files.Create, new { CONTENT = documentFile.Content, NAME = documentFile.Name, SIZE = documentFile.Size, UPLOADDATE = documentFile.UploadDate, COMPANYID = file.CompanyId });
            }

            return false;
        }
    }
}
