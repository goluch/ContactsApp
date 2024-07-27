﻿using Application.Categories.Queries.Get;
using Application.Common.Models;
using Application.Contacts.Commands.CreateContact;
using Application.Contacts.Commands.DeleteContact;
using Application.Contacts.Commands.Update;
using Application.Contacts.Queries;
using Application.Contacts.Queries.Get;
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
                //.MapGet(GetContactsWithPagination)
                .MapGet(GetContacts)
                .MapGet(GetCategories)
                .MapPost(CreateContact)
                .MapPut(UpdateContact, "{id}")
                .MapDelete(DeleteContact, "{id}"); ;
        }

        public Task<PaginatedList<ContactDto>> GetContactsWithPagination(ISender sender, [AsParameters] GetContactsWithPaginationQuery query)
        {
            return sender.Send(query);
        }

        public Task<IEnumerable<ContactDto>> GetContacts(ISender sender)
        {
            return sender.Send(new GetContactsQuery());
        }

        public Task<IEnumerable<string>> GetCategories(ISender sender)
        {
            return sender.Send(new GetCategoriesQuery());
        }

        public Task<int> CreateContact(ISender sender, CreateContactCommand command)
        {
            return sender.Send(command);
        }

        public async Task<IResult> UpdateContact(ISender sender, int id, UpdateContactCommand command)
        {
            if (id != command.Id) return Results.BadRequest();
            await sender.Send(command);
            return Results.NoContent();
        }

        public async Task<IResult> DeleteContact(ISender sender, int id)
        {
            await sender.Send(new DeleteContactCommand(id));
            return Results.NoContent();
        }
    }
}
