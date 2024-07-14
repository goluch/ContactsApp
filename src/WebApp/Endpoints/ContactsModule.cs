using Application.Contacts.Queries;
using Application.Contacts.Queries.GetContactsWithPagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security;
using WebApp.Swagger;

namespace WebApp.Endpoints
{
    public static class ContactsModule
    {
        private const string ApiRouteBase = "api/contacts";

        private static void AddContactsEndpoints(this IEndpointRouteBuilder app)
        {
            //app.MapGet("/GetContacts", async (
            //            [FromQuery] int pageSize,
            //            [FromQuery] int pageNumber,
            //            [FromQuery] bool? desc,
            //            ISender sender,
            //            CancellationToken ct
            //        ) =>
            //        Results.Ok(await sender.Send(new GetContactsWithPaginationQuery(pageNumber, pageSize, desc ?? true), ct)))
            //    //.RequireAuthorization(Permission.ProjectRead.ToString())
            //    .WithTags(SwaggerSetup.ContactsTag);

            app.MapGet("/GetContactsWithPagination", async (
                        ISender sender,
                        CancellationToken ct
                    ) =>
                    Results.Ok(await sender.Send(new GetContactsWithPaginationQuery(), ct)))
                //.RequireAuthorization(Permission.ProjectRead.ToString())
                .WithTags(SwaggerSetup.ContactsTag);
        }
        public static void UseContactsEndpoints(this IEndpointRouteBuilder app) => app.MapGroup(ApiRouteBase).AddContactsEndpoints();
    }
}
