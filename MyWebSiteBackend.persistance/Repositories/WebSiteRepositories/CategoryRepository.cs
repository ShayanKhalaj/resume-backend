using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Categories;
using MyWebSiteBackend.domain.Models.WebSiteModels;
using MyWebSiteBackend.persistance.DbContexts;

namespace MyWebSiteBackend.persistance.Repositories.WebSiteRepositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly MyWebSiteDbContext db;
        public CategoryRepository(MyWebSiteDbContext db) : base(db)
        {
            this.db = db;
        }

        public async Task<CategoryComplexResult> SearchAsync(CategorySearchModel sm)
        {
            try
            {
                var Category = from item in db.categories select item;
                if (sm.Id == -1)
                {
                    Category = Category.Where(x => x.Id > 0);
                }
                if (sm.Id > 0)
                {
                    Category = Category.Where(x => x.Id == sm.Id);
                }
                if (!string.IsNullOrEmpty(sm.CategoryName))
                {
                    Category = Category.Where(x => x.CategoryName.StartsWith(sm.CategoryName));
                }
                var Result = await Category.Select(x => new CategoryListItem
                {
                    CategoryName = x.CategoryName
                    ,
                    Description = x.Description
                    ,
                    CreatedBy = x.CreatedBy
                    ,
                    ModifiedBy = x.ModifiedBy
                    ,
                    ImageAlter = x.ImageAlter
                    ,
                    ImageUrl = x.ImageUrl
                    ,
                    Id = x.Id
                }).OrderBy(x => x.CategoryName).ToListAsync();
                return new CategoryComplexResult { Results = Result, Errors = null };
            }
            catch (Exception ex)
            {
                List<string> Errors = new List<string>();
                Errors.Add("بازیابی اطلاعات ناموفق" + ex.Message);
                return new CategoryComplexResult { Errors = Errors, Results = null };
            }
        }

        public async Task<bool> IsExistedCategoryByThisIdAsync(int id)
        {
            return await db.categories.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> DeleteRelatedArticlesByThisId(int id)
        {
            try
            {
                var categoryArticles = from item in db.articles select item;
                categoryArticles = categoryArticles.Where(x => x.CategoryID == id);
                if (await categoryArticles.ToListAsync() != null)
                {
                    foreach (var article in categoryArticles)
                    {
                        db.articles.Remove(article);
                        await db.SaveChangesAsync();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> HasDuplicatedCategoryByThisIdAsync(int id)
        {
            return await db.categories.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> HasDuplicatedCategoryByThisNameAsync(string name)
        {
            return await db.categories.AnyAsync(x => x.CategoryName.StartsWith(name));
        }
    }
}
