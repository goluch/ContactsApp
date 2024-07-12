using Application.Common.Models;
using Application.Contacts.Queries.GetContactsWithPagination;
using MediatR;
using WebApp.Infrastructure;

namespace WebApp.Endpoints
{
    public class Contacts : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this)
                //.RequireAuthorization()
                .MapGet(GetContactsWithPagination);
        }

        public Task<PaginatedList<ContactBriefDto>> GetContactsWithPagination(ISender sender, [AsParameters] GetContactsWithPaginationQuery query)
        {
            return sender.Send(query);
        }
    }
}
