using DPA.Store.DOMAIN.Core.Entities;
using DPA.Store.DOMAIN.Core.Interfaces;
using DPA.Store.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Store.DOMAIN.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _dbContext;

        public CategoryRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Ienumerable devuelve un listado, puede cambiar el tipo variable
        //async enviar peticiones de forma asincrona// return await
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _dbContext.Category.ToListAsync(); //Retorna una lista, en este las categorías
        }
    }
}
