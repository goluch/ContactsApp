﻿using Domain.Exceptions;
using static Domain.ValueObjects.Category;

namespace Domain.ValueObjects
{
    public class CategoryItem : BaseValueObject<int>
    {
        private string _categoryName;
        public string CategoryName {
            get
            {
                return _categoryName;
            }
            set
            {
                ValidateCategoryName(value);
                _categoryName = value;
            }
        }

        public string AllowedSubcategories
        {
            get
            {
                if (CategoryName == Business)
                {
                    return Restricted;
                }
                if (CategoryName == Private)
                {
                    return None;
                }
                if (CategoryName == Other)
                {
                    return Any;
                }
                else
                {
                    throw new UnsupportedCategoryNameException(CategoryName);
                }
            }
        }

        public CategoryItem() { }

        public CategoryItem(string categoryName)
        {
            ValidateCategoryName(categoryName);
            this.CategoryName = categoryName;
        }

        private static void ValidateCategoryName(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                throw new UnsupportedCategoryNameException(categoryName);
            }
            if (!SupportedCategoryNames.Contains(categoryName))
            {
                throw new UnsupportedCategoryNameException(categoryName);
            }
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

        public static IEnumerable<CategoryItem> SupportedCategoryItems
        {
            get
            {
                yield return new CategoryItem { CategoryName = Business };
                yield return new CategoryItem { CategoryName = Private };
                yield return new CategoryItem { CategoryName = Other };
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
