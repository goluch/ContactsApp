using Application.Common.Interfaces;
using Ardalis.GuardClauses;
using Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contacts.Commands.DeleteContact
{

    public record DeleteContactCommand(int Id) : IRequest;
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteContactCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Contacts
                .FindAsync(new object[] { request.Id }, cancellationToken);

            Guard.Against.NotFound(request.Id, entity);

            _context.Contacts.Remove(entity);

            entity.AddDomainEvent(new ContactDeletedEvent(entity));

            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
