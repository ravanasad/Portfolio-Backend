using AutoMapper;
using Business.Features.Contacts.Dtos;
using Business.Features.Contacts.Rules;
using DataAccess.Abstract;
using MediatR;

namespace Business.Features.Contacts.Queries.GetByIdContact
{
    public class GetByIdContactQuery : IRequest<GetByIdContactDto>
    {
        public int Id { get; set; }
        public class GetByIdContactQueryHandler : IRequestHandler<GetByIdContactQuery, GetByIdContactDto>
        {
            private IContactDal _contactDal;
            private IMapper _mapper;
            private ContactBusinessRules _rules;

            public GetByIdContactQueryHandler(IContactDal contactDal, IMapper mapper, ContactBusinessRules rules)
            {
                _contactDal = contactDal;
                _mapper = mapper;
                _rules = rules;
            }
            public async Task<GetByIdContactDto> Handle(GetByIdContactQuery request, CancellationToken cancellationToken)
            {
                var contact = await _contactDal.GetByIdAsync(request.Id);
                await _rules.ContactShouldBeExists(contact);
                return _mapper.Map<GetByIdContactDto>(contact);
            }
        }
    }
}

