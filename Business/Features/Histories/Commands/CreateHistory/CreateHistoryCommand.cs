using MediatR;
using Business.Features.Histories.Dtos;
using DataAccess.Abstract;
using AutoMapper;
using Business.Features.Histories.Rules;
using Domain.Entities.Identity;
using Domain.Entities;

namespace Business.Features.Histories.Commands.CreateHistory
{
    public class CreateHistoryCommand : IRequest<CreateHistoryDto>
    {
        public bool Type { get; set; }
        public string Year { get; set; } 
        public string JobName { get; set; } 
        public string Description { get; set; } 
        public class CreateHistoryCommandHandler : IRequestHandler<CreateHistoryCommand, CreateHistoryDto>
        {
            private IHistoryDal _historyDal;
            private IMapper _mapper;
            private HistoryBusinessRules _rules;

            public CreateHistoryCommandHandler(IHistoryDal historyDal, IMapper mapper, HistoryBusinessRules rules)
            {
                _historyDal = historyDal;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<CreateHistoryDto> Handle(CreateHistoryCommand request, CancellationToken cancellationToken)
            {
                AppUser user = await _rules.CheckUserEmail();
                History history = new()
                {
                    Description = request.Description,
                    JobName = request.JobName,
                    Type = request.Type,
                    User = user,
                    Year = request.Year
                };
                var addedHistory = _historyDal.Add(history);
                _ = await _historyDal.SaveChangesAsync();
                return _mapper.Map<CreateHistoryDto>(addedHistory);
            }
        }
    }
}

