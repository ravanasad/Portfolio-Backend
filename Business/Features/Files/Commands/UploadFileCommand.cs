using AutoMapper;
using Business.Constants;
using Business.Features.Files.Dtos;
using Business.Services.Storage;
using DataAccess.Abstract;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Business.Features.Files.Commands
{
    public class UploadFileCommand : IRequest<UploadFileDto>
    {
        public int OwnerId { get; set; }
        public IFormFile File { get; set; }
        public int Type { get; set; }
        public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, UploadFileDto>
        {
            private IFileDal _fileDal;
            private IStorage _storage;
            private IMapper _mapper;
            public UploadFileCommandHandler(IFileDal fileDal, IStorage storage, IMapper mapper)
            {
                _fileDal = fileDal;
                _storage = storage;
                _mapper = mapper;
            }
            public async Task<UploadFileDto> Handle(UploadFileCommand request, CancellationToken cancellationToken)
            {
                string type = ImageFileType.GetTypeFromInteger(request.Type);
                (string path, string fileName) file = await _storage.UploadAsync($"{type}Images", request.File);
                Domain.Entities.Files.File newFile = new()
                {
                    FileName = file.fileName,
                    Path = file.path,
                    OwnerId = request.OwnerId,
                    Type = (SendingImageOwnerType)request.Type
                };
                var addedFile = _fileDal.Add(newFile);
                _ = await _fileDal.SaveChangesAsync();
                return new() { Path=file.path,Type=type};
            }
        }
    }
}
