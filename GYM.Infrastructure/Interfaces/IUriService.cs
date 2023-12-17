using GYM.Core.QueryFilters;

namespace GYM.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetDojoPaginationUri(DojoQueryFIlter filter, string actionUrl);
    }
}