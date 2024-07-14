using Application.Common.Models;
using Application.Contacts.Commands.CreateContact;
using Application.Contacts.Commands.DeleteContact;
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
                .MapGet(GetContactsWithPagination)
                .MapPost(CreateContact)
                .MapDelete(DeleteContact, "{id}"); ;
        }

        public Task<PaginatedList<ContactBriefDto>> GetContactsWithPagination(ISender sender, [AsParameters] GetContactsWithPaginationQuery query)
        {
            return sender.Send(query);
        }

        public Task<int> CreateContact(ISender sender, CreateContactCommand command)
        {
            return sender.Send(command);
        }

        public async Task<IResult> DeleteContact(ISender sender, int id)
        {
            await sender.Send(new DeleteContactCommand(id));
            return Results.NoContent();
        }
    }
}
