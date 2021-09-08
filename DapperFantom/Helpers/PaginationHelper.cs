﻿using DapperFantom.Entities;
using DapperFantom.Models;
using DapperFantom.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperFantom.Helpers
{
    public class PaginationHelper
    {
        private ArticleService _articleService;

        public PaginationHelper(IServiceProvider serviceProvider)
        {
            // Does de correct dependency injection of the desired class
            // An alternative to injecting as a parameter on the constructor
            this._articleService = serviceProvider.GetRequiredService<ArticleService>();
        }

        public PaginationModel CategoryPagination(Category category, int page)
        {
            PaginationModel paginationModel = new PaginationModel();
            int totalCount = this._articleService.GetTotalArticleCountByCategory(category.CategoryId);
            paginationModel.TotalCount = totalCount;

            int articlesPerPage = 3;
            decimal pageSize = Math.Ceiling(decimal.Parse(totalCount.ToString()) / articlesPerPage);
            int pageCount = (int)Math.Round(pageSize);
            paginationModel.PageCount = pageCount;

            List<Article> articleLst = this._articleService.GetArticlesByCategoryId(category.CategoryId);
            paginationModel.ArticleList = articleLst;

            return paginationModel;
        }
    }
}
