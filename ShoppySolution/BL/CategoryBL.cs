using AutoMapper;
using DAL.MySqlDbContext;
using Entities;
using Interfaces.BL;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CategoryBL : ICategoryBL
    {

        private ICategoryService _categoryService;
        private IMapper _mapper;

        public CategoryBL(IServiceProvider serviceProvider)
        {
            // Dependency injection
            this._categoryService = serviceProvider.GetRequiredService<ICategoryService>();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public CategoryDO Add(CategoryDO model)
        {
            CategoryDO result = model;
            Category entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<CategoryDO, Category>(model);
                // Using the CategoryService to add the new POCO class object as a new record on the Db Table
                this._categoryService.Add(entity);
                // Storing the Id to be returned
                result.Id = entity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Delete(CategoryDO model)
        {
            try
            {
                // Mapping the Domain Object to the POCO class
                Category entity = this._mapper.Map<CategoryDO, Category>(model);
                // Using the CategoryService to delete the new POCO class object from the Db Table, and storing the result of the operation
                bool result = this._categoryService.Delete(entity);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public CategoryDO GetById(int id)
        {
            CategoryDO result = null;

            try
            {
                // Using the CategoryService to return a single record from the Db table by Id
                Category category = this._categoryService.GetById(id);
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<Category, CategoryDO>(category);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public CategoryDO Get(Expression<Func<CategoryDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<CategoryDO> GetList(Expression<Func<CategoryDO, bool>> filter = null)
        {
            List<CategoryDO> result = null;

            try
            {
                // Using the CategoryService to return a list of records from the Db table
                List<Category> categories = this._categoryService.GetList();
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<List<Category>, List<CategoryDO>>(categories);
                if (filter != null)
                    result = result.AsQueryable().Where(filter).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Update(CategoryDO model)
        {
            //CategoryDO result = null;
            Category entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<CategoryDO, Category>(model);
                // Using the CategoryService to update a single record from the Db table
                return this._categoryService.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
