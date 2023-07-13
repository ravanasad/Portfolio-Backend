using MediatR;
using Business.Features.Contacts.Dtos;
using AutoMapper;
using DataAccess.Abstract;
using Domain.Entities;

namespace Business.Features.Contacts.Commands.DeleteContact
{
    public class DeleteContactCommand : IRequest<DeleteContactDto>
    {
        public int Id { get; set; }
        public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, DeleteContactDto>
        {
            private IContactDal _contactDal;
            private IMapper _mapper;

            public DeleteContactCommandHandler(IContactDal contactDal, IMapper mapper)
            {
                _contactDal = contactDal;
                _mapper = mapper;
            }
            public async Task<DeleteContactDto> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
            {
                Contact contact = await _contactDal.GetByIdAsync(request.Id);
                Contact deletedContact = _contactDal.Delete(contact);
                return _mapper.Map<DeleteContactDto>(deletedContact);   
            }
        }
    }
}

