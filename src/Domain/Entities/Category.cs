namespace Domain.Entities
{
    public class Category : ValueObject
    {
        public String CategoryName { get; private set; }
        public String SubcategoryName { get; private set; }


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
                if (!SupportedSubcategoryNames.Contains(subcategoryName))
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

        protected static IEnumerable<String> SupportedCategoryNames
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

        protected static IEnumerable<String> SupportedSubcategoryNames
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