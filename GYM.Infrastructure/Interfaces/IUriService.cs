using GYM.Core.QueryFilters;

namespace GYM.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetDojoPaginationUri(DojoQueryFilter filter, string actionUrl);
        Uri GetFighterPaginationUri(FighterQueryFilter filter, string actionUrl);
    }
}