using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Application.Abstraction.IStorageService;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Infrastructure.StorageService.LocalStorageService
{
    public class StorageService(string webRootPath) : IStorageService
    {
        #region Helpers
        
        private string GetPhysicalPath => Path.Combine(webRootPath,"Files");
        private string GetVirtualPath(string FileName) => "/Files/" + FileName;

        #endregion
        public async Task<(string, string)> SaveFileAsync(IFormFile file)
        {
            
            var extension=Path.GetExtension(file.FileName);
            var newFileName =string.Concat( Guid.CreateVersion7() , extension);

            if (!Directory.Exists(GetPhysicalPath))
            {
                Directory.CreateDirectory(GetPhysicalPath);
            }

            var absPath=Path.Combine(GetPhysicalPath,newFileName);

            FileStream fileStream = new FileStream(absPath,FileMode.Create);

            await file.CopyToAsync(fileStream);
            var virtualPath = GetVirtualPath(newFileName);

            return (virtualPath, newFileName);


        }
        public Task<string> DeleteFileAsync(string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteFilesAsync(IEnumerable<string> fileNames)
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
