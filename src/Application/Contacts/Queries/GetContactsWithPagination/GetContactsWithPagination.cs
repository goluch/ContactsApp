using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contacts.Queries.GetContactsWithPagination
{
    public record GetContactsWithPaginationQuery : IRequest<PaginatedList<ContactBriefDto>>
    {
        public int ListId { get; init; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
}
