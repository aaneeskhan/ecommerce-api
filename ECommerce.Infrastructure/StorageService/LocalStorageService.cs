using ECommerce.Application.Abstraction.IServices;
using ECommerce.Application.Abstraction.IStorageService;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.StorageService
{
    internal class LocalStorageService : IStorageService
    {
        public Task<string> DeleteFileAsync(string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteFilesAsync(IEnumerable<string> fileNames)
        {
            throw new NotImplementedException();
        }

        public Task<string> SaveFileAsync(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> SaveFilesAsync(IFormFileCollection files)
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
