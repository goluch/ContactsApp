using Domain.Exceptions;
using static Domain.ValueObjects.Category;

namespace Domain.ValueObjects
{
    public class Category : BaseValueObject<int>
    {
 
        public CategoryItem CategoryItemValue { get; private set; }

        public string SubcategoryName { get; private set; }

        public Category() { }

        public Category(string categoryName, string subcategoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                throw new InvalidCategoryNameException(categoryName);
            }

            this.CategoryItemValue = new CategoryItem { CategoryName = categoryName };
            this.SubcategoryName = subcategoryName;
        }

        public static string Boss => "Boss";
        public static string Client => "Client";

        public static IEnumerable<string> SupportedRestrictedSubcategoryNames
        {
            get
            {
                yield return Boss;
                yield return Client;
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return CategoryItemValue;
            yield return SubcategoryName;
        }
    }
}