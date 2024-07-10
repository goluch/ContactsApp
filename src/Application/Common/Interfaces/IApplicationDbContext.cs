using ContactsApp.Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Contact> ContactsList { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
