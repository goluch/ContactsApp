using Application.Common.Models;

namespace Application.Contacts.Queries.GetContactsWithPagination
{
    public record GetContactsWithPaginationQuery : IRequest<PaginatedList<ContactBriefDto>>
    {
        public int ListId { get; init; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
}
