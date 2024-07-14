namespace Domain.Exceptions
{
    public class UnsupportedSubcategoryNameException(string name)
        : ContactsException($"Unable to create category, subcategory name {name} is not supported!");
}
