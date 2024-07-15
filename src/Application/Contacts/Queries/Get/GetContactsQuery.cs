using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;

namespace Application.Contacts.Queries.Get
{
    public sealed class GetContactsQuery() : IRequest<IEnumerable<ContactDto>>
    {

    }

    public class GetContactQueryHandler : IRequestHandler<GetContactsQuery, IEnumerable<ContactDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetContactQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContactDto>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Contacts.AsNoTracking()
                .ProjectTo<ContactDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
