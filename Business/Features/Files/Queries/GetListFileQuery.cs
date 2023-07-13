using AutoMapper;
using Business.Features.Files.Dtos;
using Business.Features.Files.Models;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Files.Queries
{
    public class GetListFileQuery : IRequest<GetListFileModel>
    {

        public class GetListFileQueryHandler : IRequestHandler<GetListFileQuery, GetListFileModel>
        {
            private IFileDal _fileDal;
            private IMapper _mapper;
            public GetListFileQueryHandler(IFileDal fileDal, IMapper mapper)
            {
                _fileDal = fileDal;
                _mapper = mapper;
            }

            public async Task<GetListFileModel> Handle(GetListFileQuery request, CancellationToken cancellationToken)
            {
                var files = await _fileDal.GetListAsync();
                GetListFileDto listFile = new GetListFileDto() { Files=files};
                return _mapper.Map<GetListFileModel>(listFile);
            }
        }
    }
}
