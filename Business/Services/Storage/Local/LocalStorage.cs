using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Business.Services.Storage.Local
{
    public class LocalStorage : ILocalStorage
    {
        private IWebHostEnvironment _webHostEnvironment;
        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task DeleteAsync(string path)
        => File.Delete($"{path}");

        public bool HasFile(string path, string fileName)
        => File.Exists($"{path}\\{fileName}");
        async Task<bool> CopyFileAsync(string rootPath, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new FileStream(rootPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<(string path, string fileName)> UploadAsync(string path, IFormFile file)
        {
            string rootPath = Path.Combine(_webHostEnvironment.WebRootPath, path);

            if (!Directory.Exists(rootPath))
                Directory.CreateDirectory(rootPath);

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            await CopyFileAsync($"{rootPath}\\{fileName}", file);

            return ($"{path}\\{fileName}", fileName);
        }
    }
}
