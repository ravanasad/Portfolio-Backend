
using MediatR;
using Business.Features.Histories.Dtos;
using AutoMapper;
using Business.Features.Histories.Rules;
using DataAccess.Abstract;
using Domain.Entities;

namespace Business.Features.Histories.Commands.UpdateHistory
{
    public class UpdateHistoryCommand : IRequest<UpdateHistoryDto>
    {
        public int Id { get; set; }
        public bool Type { get; set; }
        public string Year { get; set; }
        public string JobName { get; set; }
        public string Description { get; set; }
        public class UpdateHistoryCommandHandler : IRequestHandler<UpdateHistoryCommand, UpdateHistoryDto>
        {
            private IHistoryDal _historyDal;
            private IMapper _mapper;
            private HistoryBusinessRules _rules;

            public UpdateHistoryCommandHandler(IHistoryDal historyDal, IMapper mapper, HistoryBusinessRules rules)
            {
                _historyDal = historyDal;
                _mapper = mapper;
                _rules = rules;
            }
            public async Task<UpdateHistoryDto> Handle(UpdateHistoryCommand request, CancellationToken cancellationToken)
            {
                var mappedHistory = _mapper.Map<History>(request);
                var updatedHistory = _historyDal.Update(mappedHistory);
                _ = await _historyDal.SaveChangesAsync();
                return _mapper.Map<UpdateHistoryDto>(updatedHistory);
            }
        }
    }
}

