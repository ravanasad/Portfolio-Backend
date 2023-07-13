using MediatR;
using Business.Features.Contacts.Dtos;
using Domain.Entities.Identity;
using DataAccess.Abstract;
using AutoMapper;
using Domain.Entities;

namespace Business.Features.Contacts.Commands.CreateContact
{
    public class CreateContactCommand : IRequest<CreateContactDto>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, CreateContactDto>
        {
            private IContactDal _contactDal;
            private IMapper _mapper;

            public CreateContactCommandHandler(IContactDal contactDal, IMapper mapper)
            {
                _contactDal = contactDal;
                _mapper = mapper;
            }

            public async Task<CreateContactDto> Handle(CreateContactCommand request, CancellationToken cancellationToken)
            {
                Contact contact = new() 
                { 
                    Email= request.Email,
                    Name= request.Name,
                    Message= request.Message
                };
                var createdContact=_contactDal.Add(contact);

                return _mapper.Map<CreateContactDto>(createdContact);
            }
        }
    }
}

