using AutoMapper;
using Business.Constants;
using Business.Features.UserAbouts.Dtos;
using Business.Features.UserAbouts.Rules;
using Business.Services.FileService;
using Business.Services.Storage;
using DataAccess.Abstract;
using Domain.Entities;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Transactions;

namespace Business.Features.UserAbouts.Commands.CreateUserAbout
{
    public class CreateUserAboutCommand : IRequest<CreateUserAboutDto>
    {
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Fullname { get; set; }
        public string CvPath { get; set; }
        public string ImagePath { get; set; }
        public IFormFile FileImage { get; set; }
        public IFormFile FileCv { get; set; }
        public class CreateUserAboutCommandHandler : IRequestHandler<CreateUserAboutCommand, CreateUserAboutDto>
        {
            private IUserAboutDal _userAboutDal;
            private IMapper _mapper;
            private UserAboutBusinessRules _rules;
            private IFileService _fileService;

            public CreateUserAboutCommandHandler(IUserAboutDal userAboutDal, IMapper mapper, UserAboutBusinessRules rules, IFileService fileService)
            {
                _userAboutDal = userAboutDal;
                _mapper = mapper;
                _rules = rules;
                _fileService = fileService;
            }

            public async Task<CreateUserAboutDto> Handle(CreateUserAboutCommand request, CancellationToken cancellationToken)
            {
                AppUser user = await _rules.CheckUserEmail();
                UserAbout userAbout = _mapper.Map<UserAbout>(request);

                if(request.FileCv != null)
                {
                    string path = await _fileService.UploadAsync(ImageFileType.CvFolder, request.FileCv);
                    userAbout.CvPath = path;
                }
                if (request.FileImage != null)
                {
                    string path = await _fileService.UploadAsync(ImageFileType.ProfileFolder, request.FileCv);
                    userAbout.ImagePath = path;
                }
                UserAbout addedUserAbout = _userAboutDal.Add(userAbout);
                addedUserAbout.AppUser = user;
                _ = await _userAboutDal.SaveChangesAsync();
                return _mapper.Map<CreateUserAboutDto>(addedUserAbout);
            }
        }
    }
}

