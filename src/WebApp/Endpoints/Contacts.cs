using Application.Common.Models;
using Application.Contacts.Commands.CreateContact;
using Application.Contacts.Commands.DeleteContact;
using Application.Contacts.Queries;
using Application.Contacts.Queries.GetContactsWithPagination;
using Domain.Entities;
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
                //.MapGet(GetContacts, "all")
                .MapPost(CreateContact)
                .MapDelete(DeleteContact, "{id}"); ;
        }

        public Task<PaginatedList<ContactBriefDto>> GetContactsWithPagination(ISender sender, [AsParameters] GetContactsWithPaginationQuery query)
        {
            return sender.Send(query);
        }

        //public Task<Contact> GetContacts(ISender sender)
        //{
        //    return sender.Send(new GetContactsQuery());
        //}

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
