using System.Net;

namespace Domain.Exceptions
{
    public abstract class ContactsException(string title, string details = "") : Exception(title)
    {
        public string Details { get; init; } = details;
        public IEnumerable<string> Errors { get; init; } = [];
        public virtual HttpStatusCode? StatusCode { get; init; }
    }
}
