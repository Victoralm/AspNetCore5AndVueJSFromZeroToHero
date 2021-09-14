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
    public class PageBL : IPageBL
    {

        private IPageService _pageService;
        private IMapper _mapper;

        public PageBL(IServiceProvider serviceProvider)
        {
            // Dependency injection
            this._pageService = serviceProvider.GetRequiredService<IPageService>();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public PageDO Add(PageDO model)
        {
            PageDO result = model;
            Page entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<PageDO, Page>(model);
                // Using the PageService to add the new POCO class object as a new record on the Db Table
                this._pageService.Add(entity);
                // Storing the Id to be returned
                result.Id = entity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Delete(PageDO model)
        {
            try
            {
                // Mapping the Domain Object to the POCO class
                Page entity = this._mapper.Map<PageDO, Page>(model);
                // Using the PageService to delete the new POCO class object from the Db Table, and storing the result of the operation
                bool result = this._pageService.Delete(entity);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public PageDO GetById(int id)
        {
            PageDO result = null;

            try
            {
                // Using the PageService to return a single record from the Db table by Id
                Page page = this._pageService.GetById(id);
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<Page, PageDO>(page);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public PageDO Get(Expression<Func<PageDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<PageDO> GetList(Expression<Func<PageDO, bool>> filter = null)
        {
            List<PageDO> result = null;

            try
            {
                // Using the PageService to return a list of records from the Db table
                List<Page> pages = this._pageService.GetList();
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<List<Page>, List<PageDO>>(pages);
                if (filter != null)
                    result = result.AsQueryable().Where(filter).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Update(PageDO model)
        {
            //PageDO result = null;
            Page entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<PageDO, Page>(model);
                // Using the PageService to update a single record from the Db table
                return this._pageService.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
