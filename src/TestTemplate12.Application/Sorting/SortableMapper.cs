using AutoMapper;
using TestTemplate12.Application.Sorting.Models;

namespace TestTemplate12.Application.Sorting
{
    public static class SortableMapper
    {
        public static void ForSortableMembers<TSource, TTarget>(this IMappingExpression<TSource, TTarget> mapping)
            where TSource : BaseSortable
            where TTarget : BaseSortable
        {
            mapping
                .ForMember(
                    dest => dest.SortBy,
                    opts => opts.MapFrom<SortCriteriaResolver<TSource, TTarget>>());
        }
    }
}
