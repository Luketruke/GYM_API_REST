using GYM.Core.Enumerators;

namespace GYM.Core.Interfaces.Services
{
    public interface ICategoryService
    {
        List<string> GetCategories();
        CategoryEnum GetCategory(string categoryName);
    }
}