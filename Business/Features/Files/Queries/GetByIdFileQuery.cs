using Business.Features.Files.Dtos;
using DataAccess.Abstract;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.Features.Files.Queries
{
    public class GetByIdFileQuery : IRequest<GetByIdFileDto>
    {
        public int OwnerId { get; set; }
        public int Type { get; set; }
        public class GetByIdQueryHandler : IRequestHandler<GetByIdFileQuery, GetByIdFileDto>
        {
            public IFileDal _fileDal { get; set; }

            public GetByIdQueryHandler(IFileDal fileDal)
            {
                _fileDal = fileDal;
            }

            public async Task<GetByIdFileDto> Handle(GetByIdFileQuery request, CancellationToken cancellationToken)
            {
                var file = await _fileDal.Table.FirstOrDefaultAsync(i => i.OwnerId == request.OwnerId && i.Type == (SendingImageOwnerType)request.Type);
                if (file == null)
                    throw new Exception("File not found");
                return new() { Filename = file.FileName, Path = file.Path, Type = Enum.GetName(typeof(SendingImageOwnerType), file.Type) };
            }
        }
    }
}
