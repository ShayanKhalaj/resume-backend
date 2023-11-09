using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebSiteBackend.application.Contracts;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.ArticleImages;
using MyWebSiteBackend.domain.Models.WebSiteModels;
using MyWebSiteBackend.persistance.DbContexts;

namespace MyWebSiteBackend.persistance.Repositories.WebSiteRepositories
{
    public class ArticleImageRepository:BaseRepository<ArticleImage>,IArticleImageRepository
    {
        private readonly MyWebSiteDbContext db;
        public ArticleImageRepository(MyWebSiteDbContext db):base(db)
        {
            this.db = db;
        }


        public async Task<ArticleImageComplexResult> SearchAsync(ArticleImageSearchModel sm)
        {
            try
            {
                var images = from item in db.articleImages select item;
                if(sm.Id==-1)
                {
                    images = images.Where(x => x.Id > 0);
                }
                if (sm.Id > 0)
                {
                    images = images.Where(x => x.Id == sm.Id);
                }
                if(sm.ArticleID<=0)
                {
                    images = images.Where(x => x.ArticleID > 0);
                }
                if(sm.ArticleID>0)
                {
                    images = images.Where(x => x.ArticleID == sm.ArticleID);
                }
                if(sm.ImageUrl!=null)
                {
                    images = images.Where(x => x.ImageUrl.Equals(sm.ImageUrl));
                }
                var result =await images.Select(x => new ArticleImageListItem
                {
                    ArticleID = x.ArticleID
                    ,ImageUrl = x.ImageUrl
                    ,CreatedBy = x.CreatedBy
                    ,ModifiedBy = x.ModifiedBy
                    ,CreatedDate = x.CreatedDate
                    ,ModifiedDate = x.ModifiedDate
                    ,alter = x.alter
                    ,Description = x.Description
                    ,Id = x.Id
                }).OrderBy(x=>x.CreatedDate).ToListAsync();
                return new ArticleImageComplexResult{Results = result,Errors = null};
            }
            catch(Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add("خطا در بازیابی اطلاعات"+ex.Message);
                return new ArticleImageComplexResult{Results = null,Errors = errors};
            }
        }

        public async Task<bool> HasArticleImageDuplicatedArticleImageByThisUrl(string url)
        {
            return await db.articleImages.AnyAsync(x => x.ImageUrl.Equals(url));
        }

        public async Task<bool> IsArticleImageExistedByThisId(int id)
        {
            return await db.articleImages.AnyAsync(x => x.Id == id);
        }
    }
}
