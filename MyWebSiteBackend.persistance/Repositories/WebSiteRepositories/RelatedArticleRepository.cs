using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.RelatedArticles;
using MyWebSiteBackend.domain.Models.WebSiteModels;
using MyWebSiteBackend.persistance.DbContexts;

namespace MyWebSiteBackend.persistance.Repositories.WebSiteRepositories
{
    public class RelatedArticleRepository:BaseRepository<RelatedArticle>,IRelatedArticleRepository
    {
        private readonly MyWebSiteDbContext db;
        public RelatedArticleRepository(MyWebSiteDbContext db) : base(db)
        {
            this.db = db;
        }

        public async Task<RelatedArticleComplexResult> SearchAsync(RelatedArticleSearchModel sm)
        {
            try
            {
                var relateds = from item in db.relatedArticles select item;
                if(sm.Id<=0)
                {
                    relateds = relateds.Where(x => x.Id > 0);
                }
                if(sm.Id>0)
                {
                    relateds = relateds.Where(x => x.Id == sm.Id);
                }
                if (sm.ArticleID <= 0)
                {
                    relateds = relateds.Where(x => x.ArticleID > 0);
                }
                if (sm.ArticleID > 0)
                {
                    relateds = relateds.Where(x => x.ArticleID == sm.ArticleID);
                }
                if (sm.RelatedID <= 0)
                {
                    relateds = relateds.Where(x => x.RelatedID > 0);
                }
                if (sm.RelatedID > 0)
                {
                    relateds = relateds.Where(x => x.RelatedID == sm.RelatedID);
                }
                if(sm.RelationName!=null)
                {
                    relateds = relateds.Where(x => x.RelationName.Equals(sm.RelationName));
                }
                var result =await relateds.Select(x => new RelatedArticlesListItem
                {
                    ModifiedBy = x.ModifiedBy
                    ,CreatedDate = x.CreatedDate
                    ,ModifiedDate = x.ModifiedDate
                    ,Id = x.Id
                    ,CreatedBy = x.CreatedBy
                    ,ArticleID = x.ArticleID
                    ,Description = x.Description
                    ,RelatedID = x.RelatedID
                    ,ArticleTitle = x.Article.Title
                    ,RelatedArticleTitle = x.Related.Title
                    ,RelationName = x.RelationName
                }).OrderBy(x => x.RelationName).ToListAsync();
                return  new RelatedArticleComplexResult{Results = result,Errors = null};
            }
            catch(Exception ex)
            { 
                List<string> errors=new List<string>();
                errors.Add("خطا در بازیابی اطلاعات"+ex.Message);
                return new RelatedArticleComplexResult{Results = null, Errors = errors};
            }
        }

        public async Task<bool> HasRelatedArticleDuplicatedRelatedArticlesByThisName(string name)
        {
            return await db.relatedArticles.AnyAsync(x => x.RelationName.Equals(name));
        }

        public async Task<bool> IsRelatedArticleExistedByThisId(int id)
        {
            return await db.relatedArticles.AnyAsync(x => x.Id == id);
        }
    }
}
