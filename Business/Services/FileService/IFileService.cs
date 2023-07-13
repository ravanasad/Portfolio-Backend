using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace Business.Services.FileService
{
    public interface IFileService
    {
        Task DeleteAsync(string imagePath);
        Task<string> UploadAsync(string type, IFormFile file);
        Task<string> UpdateAsync(string type,string path,IFormFile file); 

    }
}
