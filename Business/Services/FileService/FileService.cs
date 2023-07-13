using Business.Services.Storage;
using Microsoft.AspNetCore.Http;

namespace Business.Services.FileService
{
    public class FileService : IFileService
    {
        private IStorage _storage;

        public FileService(IStorage storage)
        {
            _storage = storage;
        }

        public async Task DeleteAsync(string imagePath)
        {
            await _storage.DeleteAsync(imagePath);
        }

        public async Task<string> UpdateAsync(string type, string path, IFormFile file)
        {
            await DeleteAsync(path);
            string newPath = await UploadAsync(type, file); 
            return newPath;
        }

        public async Task<string> UploadAsync(string type, IFormFile file)
        {
            (string path,string filename) datas = await _storage.UploadAsync(type, file);
            return datas.path;
        }
    }
}
