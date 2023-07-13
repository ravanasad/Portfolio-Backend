using Business.Constants;
using Business.Features.Files.Dtos;
using Business.Services.Storage;
using DataAccess.Abstract;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Files.Commands
{

    public class DeleteFileCommand : IRequest<DeleteFileDto>
    {
        public int Id { get; set; }

        public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand, DeleteFileDto>
        {
            private IFileDal _fileDal;
            private IStorage _storage;
            private IWebHostEnvironment _webHostEnvironment;
            public DeleteFileCommandHandler(IFileDal fileDal, IStorage storage, IWebHostEnvironment webHostEnvironment)
            {
                _fileDal = fileDal;
                _storage = storage;
                _webHostEnvironment = webHostEnvironment;
            }

            public async Task<DeleteFileDto> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
            {
                var file = await _fileDal.GetByIdAsync(request.Id);
                if (file == null)
                    throw new Exception("File not found");

                await _storage.DeleteAsync($"{_webHostEnvironment.WebRootPath}\\{file.Path}");
                var deletedFile = _fileDal.Delete(file);
                _ = await _fileDal.SaveChangesAsync();
                return new() { Path = file.Path,Type=ImageFileType.GetTypeFromInteger((int)deletedFile.Type)};
            }
        }
    }
}
