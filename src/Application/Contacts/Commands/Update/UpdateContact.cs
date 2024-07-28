using Application.Common.Interfaces;
using Ardalis.GuardClauses;
using Domain.ValueObjects;
using System.Security.Cryptography.X509Certificates;

namespace Application.Contacts.Commands.Update
{
    public record UpdateContactCommand : IRequest
    {
        public int Id { get; init; }
        public string Forename { get; init; }
        public string Surname { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public Category Category { get; init; }
        public string Subcategory { get; init; }
        public string PhoneNumber { get; init; }
        public DateOnly BirthDate { get; init; }
    }

    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateContactCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Contacts
                .FindAsync(new object[] { request.Id }, cancellationToken);

            Guard.Against.NotFound(request.Id, entity);

            entity.Id = request.Id;
            entity.Forename = request.Forename;
            entity.Surname = request.Surname;
            entity.Email = request.Email;
            entity.Password = request.Password;
            entity.Category = request.Category;
            entity.PhoneNumber = request.PhoneNumber;
            entity.BirthDate = request.BirthDate;

            await _context.SaveChangesAsync(cancellationToken);

        }
    }
}
