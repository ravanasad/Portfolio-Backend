using AutoMapper;
using Business.Features.Contacts.Dtos;
using Business.Features.Contacts.Models;
using Domain.Entities;

namespace Business.Features.Contacts.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, DeleteContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();

            CreateMap<Contact, GetByIdContactDto>().ReverseMap();
            CreateMap<GetListContactModel, GetListContactDto>().ReverseMap();
        }
    }
}
