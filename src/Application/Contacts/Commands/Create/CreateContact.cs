﻿using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Events;
using Domain.ValueObjects;

namespace Application.Contacts.Commands.CreateContact
{
    public record CreateContactCommand : IRequest<int>
    {
        public int Id { get; init; }
        public string Forename { get; init; }
        public string Surname { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public Category Category { get; init; }
        public string PhoneNumber { get; init; }
        public DateOnly BirthDate { get; init; }
    }

    public class CreateContractCommandHandler : IRequestHandler<CreateContactCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateContractCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var entity = new Contact
            {
                Id = request.Id,
                Forename = request.Forename,
                Surname = request.Surname,
                Email = request.Email,
                Password = request.Password,
                Category = request.Category,
                PhoneNumber = request.PhoneNumber,
                BirthDate = request.BirthDate,
            };

            entity.AddDomainEvent(new ContactCreatedEvent(entity));

            _context.Contacts.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }

}