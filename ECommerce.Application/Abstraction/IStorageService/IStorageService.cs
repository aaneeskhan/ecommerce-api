using ECommerce.Application.RRModels.Files;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Abstraction.IStorageService
{
    public interface IStorageService
    {
        Task<(string, string)> SaveFileAsync(IFormFile file);
        Task<(IEnumerable<FileResponse>, int)> SaveFilesAsync(IFormFileCollection files);
        Task<(string,string)> UpdateFileAsync(IFormFile file,string existingFileName);
        void DeleteFileAsync(string fileName);
        int DeleteFilesAsync(IEnumerable<string> fileNames);
    }
}
