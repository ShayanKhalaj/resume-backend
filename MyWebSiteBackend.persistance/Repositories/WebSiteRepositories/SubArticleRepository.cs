using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticles;
using MyWebSiteBackend.domain.Models.WebSiteModels;
using MyWebSiteBackend.persistance.DbContexts;

namespace MyWebSiteBackend.persistance.Repositories.WebSiteRepositories
{
    public class SubArticleRepository:BaseRepository<SubArticle>,ISubArticleRepository
    {
        private readonly MyWebSiteDbContext db;
        public SubArticleRepository(MyWebSiteDbContext db) : base(db)
        {
            this.db = db;
        }

        public async Task<SubArticleComplexResult> SearchAsync(SubArticleSearchModel sm)
        {
            try
            {
                var subArticles = from item in db.subArticles select item;
                if(sm.ArticleID<=0)
                {
                    subArticles = subArticles.Where(x => x.ArticleID > 0);
                }
                if(sm.ArticleID>0)
                {
                    subArticles = subArticles.Where(x => x.ArticleID == sm.ArticleID);
                }
                if (sm.Id <= 0)
                {
                    subArticles = subArticles.Where(x => x.Id > 0);
                }
                if (sm.Id > 0)
                {
                    subArticles = subArticles.Where(x => x.Id == sm.Id);
                }
                if(sm.Description!=null)
                {
                    subArticles = subArticles.Where(x => x.Description.Equals(sm.Description));
                }
                if(sm.Text!=null)
                {
                    subArticles = subArticles.Where(x => x.Text.Equals(sm.Text));
                }
                if (sm.Title != null)
                {
                    subArticles = subArticles.Where(x => x.Title.Equals(sm.Title));
                }
                var result = await subArticles.Select(x=>new SubArticlesListItem
                    {
                        ModifiedBy = x.ModifiedBy
                        ,CreatedDate = x.CreatedDate
                        ,ModifiedDate = x.ModifiedDate
                        ,CreatedBy = x.CreatedBy
                        ,ArticleID = x.ArticleID
                        ,Description = x.Description
                        ,Text = x.Text
                        ,Title = x.Title
                        ,AudioDescription = x.AudioDescription
                        ,AudioUrl = x.AudioUrl
                        ,Id = x.Id
                        ,VideoDescription = x.VideoDescription
                        ,VideoUrl = x.VideoUrl
                    })
                    .OrderBy(x=>x.Title)
                    .ToListAsync();
                return new SubArticleComplexResult{Results = result,Errors = null};
            }
            catch(Exception ex)
            {
                List<string> errors =new List<string>();
                errors.Add("خطا در بازیابی اطلاعات"+ex.Message);
                return new SubArticleComplexResult{Results = null,Errors = errors};
            }
        }

        public async Task<bool> HasSubArticleDuplicatedSubArticleByThisTitle(string title)
        {
            return await db.subArticles.AnyAsync(x => x.Title.Equals(title));
        }

        public async Task<bool> IsSubArticleExistedByThisId(int id)
        {
            return await db.subArticles.AnyAsync(x => x.Id == id);
        }
    }
}
