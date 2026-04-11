using ECommerce.Application.Abstraction.IServices;
using ECommerce.Application.Abstraction.IStorageService;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.StorageService
{
    public class LocalStorageService(string webRootPath) : IStorageService
    {
        // D:\TrainingRepository\DotNet\WebAPI\ECommerce\ECommerce.Api\wwwroot\Files
        private string GetPhysicalPath => Path.Combine(webRootPath, "Files");

        // img src="http://logichubss.com/files/tawheed.png"/>
        private string GetVirtualPath(string FileName) => "/Files/" + FileName;// /files/tawheed.jpg

        public Task<(string, string)> SaveFileAsync(IFormFile file)
        {

            var newFileName = string.Concat(Guid.CreateVersion7().ToString(), file.FileName);
            // absolute file path
            var absPath= Path.Combine(GetPhysicalPath, newFileName);
           // FileStream fileStream = new FileStream(FileMode.Create,absPath);
           //file.CopyToAsync(fileStream)
                
                // Path.Combine(Guid.CreateVersion7().ToString(), file.FileName);

            //return GetVirtualPath("")
            throw new NotImplementedException();
        }

        public Task<string> DeleteFileAsync(string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteFilesAsync(IEnumerable<string> fileNames)
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
