namespace Application.DTO.Contacts
{
    public class GetContactsDto
    {
        public IEnumerable<ContactDto> Projects { get; set; } = [];

        public record ContactDto(Guid Id, string Name);
    }
}
