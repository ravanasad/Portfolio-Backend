using Microsoft.AspNetCore.Http;

namespace Business.Services.Storage
{
    public interface IStorage
    {
        Task<(string path, string fileName)> UploadAsync(string path,IFormFile file);
        Task DeleteAsync(string path);
        bool HasFile(string path, string fileName);
    }
}
