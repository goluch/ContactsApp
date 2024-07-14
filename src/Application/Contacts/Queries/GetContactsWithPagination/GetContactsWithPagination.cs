using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;

namespace Application.Contacts.Queries.GetContactsWithPagination
{
    public record GetContactsWithPaginationQuery : IRequest<PaginatedList<ContactBriefDto>>
    {
        public int ListId { get; init; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }

    //public class GetContactsWithPaginationQueryHandler : IRequestHandler<GetContactsWithPaginationQuery, PaginatedList<ContactBriefDto>>
    //{
    //    private readonly IApplicationDbContext _context;
    //    private readonly IMapper _mapper;

    //    public GetContactsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    //    {
    //        _context = context;
    //        _mapper = mapper;
    //    }

    //    public async Task<PaginatedList<ContactBriefDto>> Handle(GetContactsWithPaginationQuery request, CancellationToken cancellationToken)
    //    {
    //        return await _context.ContactsList
    //            .Where(x => x.Id.ListId == request.ListId)
    //            .OrderBy(x => x.Title)
    //            .ProjectTo<ContactBriefDto>(_mapper.ConfigurationProvider)
    //            .PaginatedListAsync(request.PageNumber, request.PageSize);
    //    }
    //}
}
