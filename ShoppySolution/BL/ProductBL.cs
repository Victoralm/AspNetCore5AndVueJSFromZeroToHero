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
    public class ProductBL : IProductBL
    {

        private IProductService _productService;
        private IMapper _mapper;

        public ProductBL(IServiceProvider serviceProvider)
        {
            // Dependency injection
            this._productService = serviceProvider.GetRequiredService<IProductService>();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public ProductDO Add(ProductDO model)
        {
            ProductDO result = model;
            Product entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<ProductDO, Product>(model);
                // Using the ProductService to add the new POCO class object as a new record on the Db Table
                this._productService.Add(entity);
                // Storing the Id to be returned
                result.Id = entity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Delete(ProductDO model)
        {
            try
            {
                // Mapping the Domain Object to the POCO class
                Product entity = this._mapper.Map<ProductDO, Product>(model);
                // Using the ProductService to delete the new POCO class object from the Db Table, and storing the result of the operation
                bool result = this._productService.Delete(entity);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public ProductDO GetById(int id)
        {
            ProductDO result = null;

            try
            {
                // Using the ProductService to return a single record from the Db table by Id
                Product product = this._productService.GetById(id);
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<Product, ProductDO>(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public ProductDO Get(Expression<Func<ProductDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<ProductDO> GetList(Expression<Func<ProductDO, bool>> filter = null)
        {
            List<ProductDO> result = null;

            try
            {
                // Using the ProductService to return a list of records from the Db table
                List<Product> products = this._productService.GetList();
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<List<Product>, List<ProductDO>>(products);
                if (filter != null)
                    result = result.AsQueryable().Where(filter).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Update(ProductDO model)
        {
            //ProductDO result = null;
            Product entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<ProductDO, Product>(model);
                // Using the ProductService to update a single record from the Db table
                return this._productService.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
