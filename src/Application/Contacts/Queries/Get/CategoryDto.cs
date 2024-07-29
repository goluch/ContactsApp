using AutoMapper;
using Domain.ValueObjects;

namespace Application.Contacts.Queries.Get
{
    public class CategoryDto
    {
        public CategoryItemDto CategoryItemValue { get; private set; }

        public string SubcategoryName { get; private set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Category, CategoryDto>();
            }
        }
    }
}
