using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Abstraction.IStorageService
{
    public interface IStorageService
    {
        Task<(string,string)> SaveFileAsync(IFormFile file);

        Task<IEnumerable<string>> SaveFilesAsync(IFormFileCollection files);

        //Task<IEnumerable<string>> SaveFilesAsync(List<IFormFile> files);

        Task<(string,string)> UpdateFileAsync(IFormFile file, string existingFileName);

        Task<string> DeleteFileAsync(string fileName);

        Task<int> DeleteFilesAsync(IEnumerable<string> fileNames);
    }
}
