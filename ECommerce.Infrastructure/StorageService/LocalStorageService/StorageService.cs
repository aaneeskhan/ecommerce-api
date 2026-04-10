using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Application.Abstraction.IStorageService;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Infrastructure.StorageService.LocalStorageService
{
    public class StorageService : IStorageService
    {
        public Task<string> DeleteFileAsync(string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteFilesAsync(IEnumerable<string> fileNames)
        {
            throw new NotImplementedException();
        }

        public Task<(string, string)> SaveFileAsync(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> SaveFilesAsync(IFormCollection files)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> SaveFilesAsync(List<IFormFile> files)
        {
            throw new NotImplementedException();
        }

        public Task<(string, string)> UpdateFileAsync(IFormFile file, string existingFileName)
        {
            throw new NotImplementedException();
        }
    }
}
