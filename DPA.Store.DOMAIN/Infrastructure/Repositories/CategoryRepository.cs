﻿using DPA.Store.DOMAIN.Core.Entities;
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

        public async Task<Category> GetByIdCat(int id)
        {
            return await _dbContext.Category.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        
        public async Task<bool> Insert(Category category)
        {
            await _dbContext.Category.AddAsync(category);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var getcat = await _dbContext.Category.Where(x=>x.Id == id).FirstOrDefaultAsync();
            if (getcat == null)
                return false;
            _dbContext.Category.Remove(getcat);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
     
    }
}
