using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Application.Abstraction.IStorageService
{
    public interface IStorageService
    {
        Task<(string, string)> SaveFileAsync(IFormFile file);
        Task<IEnumerable<string>> SaveFilesAsync(IFormCollection files);
        Task<IEnumerable<string>> SaveFilesAsync(List<IFormFile> files);
        Task<(string,string)> UpdateFileAsync(IFormFile file,string existingFileName);
        Task<string> DeleteFileAsync(string fileName);
        Task<int> DeleteFilesAsync(IEnumerable<string> fileNames);
    }
}
