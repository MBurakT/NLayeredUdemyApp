using NLayer.Core.Dtos;
using NLayer.Core.Models;
using NLayer.Core.Repositories;

namespace NLayer.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<CustomResponseDto<CategoryWithProductsDto>> GetCategoryByIdWithProductsAsync(int id);
    }
}
