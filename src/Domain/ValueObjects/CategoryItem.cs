using Domain.Exceptions;
using static Domain.ValueObjects.Category;

namespace Domain.ValueObjects
{
    public class CategoryItem : BaseValueObject<int>
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

        public CategoryItem() { }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
