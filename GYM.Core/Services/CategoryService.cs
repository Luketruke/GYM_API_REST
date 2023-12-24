using GYM.Core.Enumerators;
using GYM.Core.Interfaces.Services;

namespace GYM.Core.Services
{
    public class CategoryService : ICategoryService
    {
        public CategoryEnum GetCategory(string categoryName)
        {
            if (Enum.TryParse<CategoryEnum>(categoryName, out var category))
            {
                return category;
            }
            else
            {
                throw new ArgumentException("Not valid category", nameof(categoryName));
            }
        }

        public List<string> GetCategories()
        {
            return Enum.GetNames(typeof(CategoryEnum)).ToList();
        }
    }
}
