namespace Domain.Exceptions
{
    public class InvalidSubcategoryNameException(string categoryName, string name)
        : ContactsException($"Unable to create subcategory name {categoryName} with categoty name {name}!");
}
