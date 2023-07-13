
using MediatR;
using Business.Features.Contacts.Dtos;
using AutoMapper;
using Business.Features.Contacts.Rules;
using DataAccess.Abstract;
using Domain.Entities;
using Business.Features.Contacts.Models;

namespace Business.Features.Contacts.Queries.GetListContact
{
    public class GetListContactQuery : IRequest<GetListContactModel>
    {
        public class GetListContactQueryHandler : IRequestHandler<GetListContactQuery, GetListContactModel>
        {
            private IContactDal _contactDal;
            private IMapper _mapper;
            private ContactBusinessRules _rules;

            public GetListContactQueryHandler(IContactDal contactDal, IMapper mapper, ContactBusinessRules rules)
            {
                _contactDal = contactDal;
                _mapper = mapper;
                _rules = rules;
            }
            public async Task<GetListContactModel> Handle(GetListContactQuery request, CancellationToken cancellationToken)
            {
                List<Contact> contacts = await _contactDal.GetListAsync();
                GetListContactDto contactsList = new() { Contacts = contacts };
                var response = _mapper.Map<GetListContactModel>(contactsList);
                return response;
            }
        }
    }
}

