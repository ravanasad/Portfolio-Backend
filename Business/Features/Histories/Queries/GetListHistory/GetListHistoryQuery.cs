using MediatR;
using Business.Features.Histories.Dtos;
using Business.Features.Contacts.Dtos;
using Business.Features.Contacts.Models;
using Domain.Entities;
using AutoMapper;
using Business.Features.Contacts.Rules;
using DataAccess.Abstract;
using Domain.Entities;
using Business.Features.Histories.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Features.Histories.Queries.GetListHistory
{
    public class GetListHistoryQuery : IRequest<GetListHistoryModel>
    {
        public class GetListHistoryQueryHandler : IRequestHandler<GetListHistoryQuery, GetListHistoryModel>
        {
            private IHistoryDal _historyDal;
            private IMapper _mapper;

            public GetListHistoryQueryHandler(IHistoryDal historyDal, IMapper mapper)
            {
                _historyDal = historyDal;
                _mapper = mapper;
            }

            public async Task<GetListHistoryModel> Handle(GetListHistoryQuery request, CancellationToken cancellationToken)
            {
                List<History> histories = await _historyDal.Table.Include(i => i.User).ToListAsync();
                GetListHistoryDto contactsList = new() { Histories = histories };
                return _mapper.Map<GetListHistoryModel>(contactsList);
            }
        }
    }
}

