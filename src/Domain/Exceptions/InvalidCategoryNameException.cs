namespace Domain.Exceptions
{
    public class InvalidCategoryNameException(string name)
        : ContactsException($"Unable to create category name with name {name}!");
}
