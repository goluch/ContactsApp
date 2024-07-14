using Application.Common.QueryParameters;
using Application.DTO.Contacts;

namespace Application.Contacts.Queries.Get
{
    public sealed class GetContactsQuery(int pageNumber, int pageSize, bool desc, bool onlyActive = true)
        : IRequest<GetContactsDto>
    {
        public PagingParameters Parameters { get; set; } = new() { PageSize = pageSize, PageNumber = pageNumber };

        public OrderingParameters OrderingParameters { get; set; } = new() { OrderBy = "Name", Desc = desc };

        public bool OnlyActive { get; set; } = onlyActive;
    }
}
