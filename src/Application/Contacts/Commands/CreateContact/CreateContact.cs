using Application.Common.Interfaces;
using ContactsApp.Domain.Entities;
using ContactsApp.Domain.Enums;
using Domain.Events;

namespace Application.Contacts.Commands.CreateContact
{
    public record CreateContractCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Forename { get; init; }
        public string Surname { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public Category Category { get; init; }
        public string Subcategory { get; init; }
        public int PhoneNumber { get; init; }
        public DateOnly BirthDate { get; init; }
    }

    public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateContractCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateContractCommand request, CancellationToken cancellationToken)
        {
            var entity = new Contact
            {
                Id = request.Id,
                Forename = request.Forename,
                Surname = request.Surname,
                Email = request.Email,
                Password = request.Password,
                Category = request.Category,
                Subcategory = request.Subcategory,
                PhoneNumber = request.PhoneNumber,
                BirthDate = request.BirthDate,
            };

            entity.AddDomainEvent(new ContactCreatedEvent(entity));

            _context.ContactsList.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }

}