using MediatR;
using Business.Features.UserAbouts.Dtos;
using AutoMapper;
using Business.Features.UserAbouts.Rules;
using DataAccess.Abstract;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Business.Services.Storage;
using Business.Services.FileService;
using Business.Constants;
using System.Reflection.Metadata;

namespace Business.Features.UserAbouts.Commands.UpdateUserAbout
{
    public class UpdateUserAboutCommand : IRequest<UpdateUserAboutDto>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Fullname { get; set; }
        public IFormFile FileImage { get; set; }
        public IFormFile FileCv { get; set; }
        public class UpdateUserAboutCommandHandler : IRequestHandler<UpdateUserAboutCommand, UpdateUserAboutDto>
        {
            private IUserAboutDal _userAboutDal;
            private IMapper _mapper;
            private UserAboutBusinessRules _rules;
            private IFileService _fileService;
            public UpdateUserAboutCommandHandler(IUserAboutDal userAboutDal, IMapper mapper, UserAboutBusinessRules rules, IFileService fileService)
            {
                _userAboutDal = userAboutDal;
                _mapper = mapper;
                _rules = rules;
                _fileService = fileService;
            }

            public async Task<UpdateUserAboutDto> Handle(UpdateUserAboutCommand request, CancellationToken cancellationToken)
            {
                UserAbout userAbout = await _rules.UserAboutShouldBeExists(request.Id);

                if (request.FileCv != null)
                {
                    string path = "";
                    if (userAbout.ImagePath != string.Empty)
                        path = await _fileService.UpdateAsync(ImageFileType.ProfileFolder, userAbout.ImagePath, request.FileImage);
                    else
                        path = await _fileService.UploadAsync(ImageFileType.ProfileFolder, request.FileImage);
                    userAbout.CvPath = path;
                }
                if (request.FileImage != null)
                {
                    string path = "";
                    if (userAbout.ImagePath != string.Empty)
                        path = await _fileService.UpdateAsync(ImageFileType.ProfileFolder, userAbout.ImagePath, request.FileImage);
                    else
                        path = await _fileService.UploadAsync(ImageFileType.ProfileFolder, request.FileImage);
                    userAbout.ImagePath = path;
                }
                userAbout.Description = request.Description;
                userAbout.PhoneNumber = request.PhoneNumber;
                userAbout.Fullname = request.Fullname;
                UserAbout updatedUserAbout = _userAboutDal.Update(userAbout);
                _ = await _userAboutDal.SaveChangesAsync();
                return _mapper.Map<UpdateUserAboutDto>(updatedUserAbout);
            }
        }
    }
}

