using Application.Common.Interfaces;
using Application.Contacts.Queries.Get;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Application.Categories.Queries.Get
{
    public sealed class GetCategoriesQuery() : IRequest<IEnumerable<CategoryItem>>
    {

    }

    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryItem>>
    {
        public async Task<IEnumerable<CategoryItem>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return CategoryItem.SupportedCategoryItems;
        }
    }
}
