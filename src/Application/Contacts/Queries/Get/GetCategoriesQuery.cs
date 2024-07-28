using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Categories.Queries.Get
{
    public sealed class GetCategoriesQuery() : IRequest<IEnumerable<string>>
    {

    }

    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<string>>
    {
        public async Task<IEnumerable<string>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return CategoryItem.SupportedCategoryNames;
        }
    }
}
