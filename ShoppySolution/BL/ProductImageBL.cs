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
    public class ProductImageBL : IProductImageBL
    {

        private IProductImageService _productImageService;
        private IMapper _mapper;

        public ProductImageBL(IServiceProvider serviceProvider)
        {
            // Dependency injection
            this._productImageService = serviceProvider.GetRequiredService<IProductImageService>();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public ProductImageDO Add(ProductImageDO model)
        {
            ProductImageDO result = model;
            ProductImage entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<ProductImageDO, ProductImage>(model);
                // Using the ProductImageService to add the new POCO class object as a new record on the Db Table
                this._productImageService.Add(entity);
                // Storing the Id to be returned
                result.Id = entity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Delete(ProductImageDO model)
        {
            try
            {
                // Mapping the Domain Object to the POCO class
                ProductImage entity = this._mapper.Map<ProductImageDO, ProductImage>(model);
                // Using the ProductImageService to delete the new POCO class object from the Db Table, and storing the result of the operation
                bool result = this._productImageService.Delete(entity);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public ProductImageDO GetById(int id)
        {
            ProductImageDO result = null;

            try
            {
                // Using the ProductImageService to return a single record from the Db table by Id
                ProductImage productImage = this._productImageService.GetById(id);
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<ProductImage, ProductImageDO>(productImage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public ProductImageDO Get(Expression<Func<ProductImageDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<ProductImageDO> GetList(Expression<Func<ProductImageDO, bool>> filter = null)
        {
            List<ProductImageDO> result = null;

            try
            {
                // Using the ProductImageService to return a list of records from the Db table
                List<ProductImage> productImages = this._productImageService.GetList();
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<List<ProductImage>, List<ProductImageDO>>(productImages);
                if (filter != null)
                    result = result.AsQueryable().Where(filter).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Update(ProductImageDO model)
        {
            //ProductImageDO result = null;
            ProductImage entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<ProductImageDO, ProductImage>(model);
                // Using the ProductImageService to update a single record from the Db table
                return this._productImageService.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
