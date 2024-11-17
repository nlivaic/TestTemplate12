using System.Collections.Generic;
using TestTemplate12.Application.Sorting.Models;

namespace TestTemplate12.Application.Sorting
{
    public interface IPropertyMappingService
    {
        IEnumerable<SortCriteria> Resolve(BaseSortable sortableSource, BaseSortable sortableTarget);
    }
}
