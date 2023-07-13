
using MediatR;
using Business.Features.Contacts.Dtos;
using AutoMapper;
using DataAccess.Abstract;
using Domain.Entities;

namespace Business.Features.Contacts.Commands.UpdateContact
{
    public class UpdateContactCommand : IRequest<UpdateContactDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, UpdateContactDto>
        {
            private IContactDal _contactDal;
            private IMapper _mapper;

            public UpdateContactCommandHandler(IContactDal contactDal, IMapper mapper)
            {
                _contactDal = contactDal;
                _mapper = mapper;
            }
            public async Task<UpdateContactDto> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
            {
                var contact = await _contactDal.GetByIdAsync(request.Id);
                contact.Email = request.Email;
                contact.Message = request.Message;
                contact.Name = request.Name;
                _ = _contactDal.Update(contact);
                await _contactDal.SaveChangesAsync();

                return _mapper.Map<UpdateContactDto>(contact);  
                
            }
        }
    }
}

