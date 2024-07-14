using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Contact> Contacts { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
