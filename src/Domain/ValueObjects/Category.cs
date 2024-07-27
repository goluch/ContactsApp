using Domain.Exceptions;

namespace Domain.ValueObjects
{
    public class Category : BaseValueObject<int>
    {

        public string CategoryName { get; private set; }
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

            if (categoryName == Private)
            {
                if (!string.IsNullOrWhiteSpace(subcategoryName))
                {
                    throw new InvalidSubcategoryNameException(categoryName, subcategoryName);
                }
            }

            if (categoryName == Business)
            {
                if (!SupportedBusinessSubcategoryNames.Contains(subcategoryName))
                {
                    throw new UnsupportedSubcategoryNameException(categoryName);
                }
            }

            CategoryName = categoryName;
            SubcategoryName = subcategoryName;
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

        public static IEnumerable<string> SupportedBusinessSubcategoryNames
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
            yield return CategoryName;
            yield return SubcategoryName;
        }
    }
}