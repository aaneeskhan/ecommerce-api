using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Text;
using ECommerce.Application.Abstraction.IStorageService;
using ECommerce.Application.RRModels.files;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Infrastructure.StorageService
{
    public class LocalStorageService(string webRootPath) : IStorageService
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

        public async Task<(IEnumerable<FileResponse>,int)> SaveFilesAsync(IFormFileCollection files)
        {
            int totalFilesUploaded = 0;
            List<FileResponse> filesResponses = new List<FileResponse>();
            foreach(var file in files)
            {
                (string filePath,string fileName)= await SaveFileAsync(file);
                var FileRespone = new FileResponse()
                {
                    FilePath=filePath,
                    FileName=fileName
                };
                filesResponses.Add(FileRespone);
                totalFilesUploaded++;
            }
            return (filesResponses,totalFilesUploaded);
        }
        public void DeleteFileAsync(string fileName)
        {
            string filePath = Path.Combine(GetPhysicalPath, fileName);
            File.Delete(filePath);
        }

        public int DeleteFilesAsync(IEnumerable<string> fileNames)
        {
            var totalFilesDeleted = 0;
            foreach(var fileName in fileNames)
            {
                string filePath = Path.Combine(GetPhysicalPath, fileName);
                File.Delete(filePath);
                totalFilesDeleted++;
            }
            return totalFilesDeleted;
        }

        public async Task<(string, string)> UpdateFileAsync(IFormFile file, string existingFileName)
        {
            if(existingFileName is not null)
            {
                DeleteFileAsync(existingFileName);
            }
            return await SaveFileAsync(file);
        }
    }
}
