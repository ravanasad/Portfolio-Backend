
using MediatR;
using Business.Features.UserAbouts.Dtos;
using AutoMapper;
using Business.Features.UserAbouts.Rules;
using DataAccess.Abstract;
using Domain.Entities;
using Business.Services.FileService;

namespace Business.Features.UserAbouts.Commands.DeleteUserAbout
{
    public class DeleteUserAboutCommand : IRequest<DeleteUserAboutDto>
    {
        public int Id { get; set; }
        public class DeleteUserAboutCommandHandler : IRequestHandler<DeleteUserAboutCommand, DeleteUserAboutDto>
        {
            private IUserAboutDal _userAboutDal;
            private IMapper _mapper;
            private UserAboutBusinessRules _rules;
            private IFileService _fileService;
            public DeleteUserAboutCommandHandler(IUserAboutDal userAboutDal, IMapper mapper, UserAboutBusinessRules rules, IFileService fileService)
            {
                _userAboutDal = userAboutDal;
                _mapper = mapper;
                _rules = rules;
                _fileService = fileService;
            }

            public async Task<DeleteUserAboutDto> Handle(DeleteUserAboutCommand request, CancellationToken cancellationToken)
            {
                UserAbout userAbout = await _rules.UserAboutShouldBeExists(request.Id);
                UserAbout deletedUserAbout = _userAboutDal.Delete(userAbout);
                if(deletedUserAbout.ImagePath != null) 
                    await _fileService.DeleteAsync(deletedUserAbout.ImagePath);
                if (deletedUserAbout.CvPath != null)
                    await _fileService.DeleteAsync(deletedUserAbout.CvPath);
                _ = await _userAboutDal.SaveChangesAsync();
                return _mapper.Map<DeleteUserAboutDto>(deletedUserAbout);
            }
        }
    }
}

