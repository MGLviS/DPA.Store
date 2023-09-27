using DPA.Store.DOMAIN.Core.Entities;

namespace DPA.Store.DOMAIN.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();

        //Task<Category> GetById(int id);
        Task<Category> GetByIdCat(int id);

       // Task<bool> Insert(Category category);

        Task<bool> Insert(Category category);

        //Task<bool> Delete(int id);
        Task<bool> Delete(int id);

       
    }
}