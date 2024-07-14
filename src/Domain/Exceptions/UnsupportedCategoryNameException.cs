namespace Domain.Exceptions
{
    public class UnsupportedCategoryNameException(string name)
        : ContactsException($"Unable to create category, name {name} is not supported!");
}
