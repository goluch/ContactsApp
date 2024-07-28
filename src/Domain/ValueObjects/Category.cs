using Domain.Exceptions;
using static Domain.ValueObjects.Category;

namespace Domain.ValueObjects
{
    public class Category : BaseValueObject<int>
    {
        public record CategoryItem
        {
            public string CategoryName
            {
                get => CategoryName;
                init
                {
                    if (value == Business)
                    {
                        AllowedSubcategories = Restricted;
                    }
                    if (value == Private)
                    {
                        AllowedSubcategories = None;
                    }
                    if (value == Other)
                    {
                        AllowedSubcategories = Any;
                    }
                    else
                    {
                        throw new UnsupportedCategoryNameException(value);
                    }
                }
            }

            public string AllowedSubcategories { get; private set; }
        }
        public CategoryItem CategoryItemValue { get; private set; }

        public string SubcategoryName { get; private set; }


        public Category(string categoryName, string subcategoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                throw new InvalidCategoryNameException(categoryName);
            }

            if (!SupportedCategoryNames.Contains(categoryName))
            {
                throw new UnsupportedCategoryNameException(categoryName);
            }

            CategoryItemValue = new CategoryItem { CategoryName = categoryName };
            SubcategoryName = subcategoryName;
        }

        public static string Any => "Any";
        public static string Restricted => "Restricted";
        public static string None => "None";

        public static IEnumerable<string> SupportedAllowedSubcategories
        {
            get
            {
                yield return Any;
                yield return Restricted;
                yield return None;
            }
        }

        public static string Business => "Business";
        public static string Private => "Private";
        public static string Other => "Other";

        public static IEnumerable<string> SupportedCategoryNames
        {
            get
            {
                yield return Business;
                yield return Private;
                yield return Other;
            }
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