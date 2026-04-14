using ECommerce.Application.Abstraction.IServices;
using ECommerce.Application.Abstraction.IStorageService;
using ECommerce.Application.RRModels.Files;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.StorageService
{
    public class LocalStorageService(string webRootPath) : IStorageService
    {

        public async Task<(string, string)> SaveFileAsync(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var newFileName = string.Concat(Guid.CreateVersion7().ToString(), extension);
           
            if (!Directory.Exists(GetPhysicalPath))
            {
                Directory.CreateDirectory(GetPhysicalPath);
            }
           
            var absPath = Path.Combine(GetPhysicalPath, newFileName);

            FileStream fileStream = new FileStream(absPath,FileMode.Create);
            await file.CopyToAsync(fileStream);

            var virtualPath = GetVirtualPath(newFileName);
            return (virtualPath, newFileName);
        }
      
        public async Task<(IEnumerable<FileResponse>,int)> SaveFilesAsync(IFormFileCollection files)
        {
            int totalFileUploaded = 0;
            List<FileResponse> filesResponse = new List<FileResponse>();
            foreach (var file in files)
            {
                (string filePath, string fileName) = await SaveFileAsync(file);
                filesResponse.Add(new FileResponse
                {
                    FileName = fileName,
                    FilePath = filePath,
                });
                totalFileUploaded++;
            }
            return (filesResponse, totalFileUploaded);
        }

        public void DeleteFileAsync(string fileName)
        {
            string filePath = Path.Combine(GetPhysicalPath, fileName);
            File.Delete(filePath);
        }

        public int DeleteFilesAsync(IEnumerable<string> fileNames)
        {
            int totalFilesDeleted = 0;
            foreach (var fileName in fileNames)
            {
                string filePath = Path.Combine(GetPhysicalPath, fileName);
                File.Delete(filePath);
                totalFilesDeleted++;
            }
            return totalFilesDeleted;
        }


        public Task<(string, string)> UpdateFileAsync(IFormFile file, string existingFileName)
        {
          
            throw new NotImplementedException();
        }


        #region helpers

        // D:\TrainingRepository\DotNet\WebAPI\ECommerce\ECommerce.Api\wwwroot\Files
        private string GetPhysicalPath => Path.Combine(webRootPath, "Files");

        // img src="http://logichubss.com/files/tawheed.png"/>
        private string GetVirtualPath(string FileName) => "/Files/" + FileName;// /files/tawheed.jpg

        public Task<IEnumerable<string>> SaveFilesAsync(IFormCollection files)
        {
            throw new NotImplementedException();
        }

     

        #endregion
    }
}
