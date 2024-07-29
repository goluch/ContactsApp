using AutoMapper;
using Domain.ValueObjects;

namespace Application.Contacts.Queries.Get
{
    public class CategoryItemDto
    {
        public string CategoryName { get; init; }

        public string AllowedSubcategories { get; init; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<CategoryItem, CategoryItemDto>();
            }
        }
    }
}
