using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.BusinessSubategories.Queries.Get
{
    public sealed class GetBusinessSubategoriesQuery() : IRequest<IEnumerable<string>>
    {

    }

    public class GetBusinessSubategoriesQueryHandler : IRequestHandler<GetBusinessSubategoriesQuery, IEnumerable<string>>
    {
        public async Task<IEnumerable<string>> Handle(GetBusinessSubategoriesQuery request, CancellationToken cancellationToken)
        {
            return Category.SupportedBusinessSubcategoryNames;
        }
    }
}
