
using MediatR;
using Business.Features.Histories.Dtos;
using AutoMapper;
using Business.Features.Histories.Rules;
using DataAccess.Abstract;

namespace Business.Features.Histories.Commands.DeleteHistory
{
    public class DeleteHistoryCommand : IRequest<DeleteHistoryDto>
    {
        public int Id { get; set; }
        public class DeleteHistoryCommandHandler : IRequestHandler<DeleteHistoryCommand, DeleteHistoryDto>
        {
            private IHistoryDal _historyDal;
            private IMapper _mapper;

            public DeleteHistoryCommandHandler(IHistoryDal historyDal, IMapper mapper)
            {
                _historyDal = historyDal;
                _mapper = mapper;
            }
            public async Task<DeleteHistoryDto> Handle(DeleteHistoryCommand request, CancellationToken cancellationToken)
            {
                var history = await _historyDal.GetByIdAsync(request.Id);
                var deletedHistory = _historyDal.Delete(history);
                _ = await _historyDal.SaveChangesAsync();

                return _mapper.Map<DeleteHistoryDto>(deletedHistory);
            }
        }
    }
}

