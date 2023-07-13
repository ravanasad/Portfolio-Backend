using AutoMapper;
using Business.Features.Histories.Dtos;
using DataAccess.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.Features.Histories.Queries.GetByIdHistory
{
    public class GetByIdHistoryQuery : IRequest<GetByIdHistoryDto>
    {
        public int Id { get; set; }
        public class GetByIdHistoryQueryHandler : IRequestHandler<GetByIdHistoryQuery, GetByIdHistoryDto>
        {
            private IHistoryDal _historyDal;
            private IMapper _mapper;
            public GetByIdHistoryQueryHandler(IHistoryDal historyDal, IMapper mapper)
            {
                _historyDal = historyDal;
                _mapper = mapper;
            }
            public async Task<GetByIdHistoryDto> Handle(GetByIdHistoryQuery request, CancellationToken cancellationToken)
            {
                var history = await _historyDal.Table.Include(i=>i.User).FirstOrDefaultAsync(i=>i.Id==request.Id);
                return _mapper.Map<GetByIdHistoryDto>(history); 
            }
        }
    }
}

