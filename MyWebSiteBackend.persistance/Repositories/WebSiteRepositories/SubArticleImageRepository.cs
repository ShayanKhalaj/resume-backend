using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticleImages;
using MyWebSiteBackend.domain.Models.WebSiteModels;
using MyWebSiteBackend.persistance.DbContexts;

namespace MyWebSiteBackend.persistance.Repositories.WebSiteRepositories
{
    public class SubArticleImageRepository:BaseRepository<SubArticleImage>,ISubArticleImageRepository
    {
        private readonly MyWebSiteDbContext db;
        public SubArticleImageRepository(MyWebSiteDbContext db) : base(db)
        {
            this.db = db;
        }

        public async Task<SubArticleImageComplexResult> SearchAsync(SubArticleImageSearchModel sm)
        {
            try
            {
                var images = from item in db.subArticleImage select item;
                if(sm.SubArticleID<=0)
                {
                    images = images.Where(x => x.SubArticleID > 0);
                }
                if(sm.SubArticleID>0)
                {
                    images = images.Where(x => x.SubArticleID == sm.SubArticleID);
                }
                if (sm.Id <= 0)
                {
                    images = images.Where(x => x.Id > 0);
                }
                if (sm.Id > 0)
                {
                    images = images.Where(x => x.Id == sm.Id);
                }
                if(sm.Description!=null)
                {
                    images = images.Where(x => x.Description.Equals(sm.Description));
                }
                if(sm.ImageUrl!=null)
                {
                    images = images.Where(x => x.ImageUrl.Equals(sm.ImageUrl));
                }
                var result = await images.Select(x=>new SubArticleImagesListItem
                    {
                        Alter=x.Alter
                        ,CreatedBy=x.CreatedBy
                        ,CreatedDate=x.CreatedDate
                        ,Description=x.Description
                        ,Id=x.Id
                        ,ImageUrl=x.ImageUrl
                        ,ModifiedBy=x.ModifiedBy
                        ,ModifiedDate=x.ModifiedDate
                        ,SubArticleID=x.SubArticleID
                    })
                    .OrderBy(x=>x.Id)
                    .ToListAsync();
                return new SubArticleImageComplexResult{Results = result,Errors=null};
            }
            catch(Exception ex)
            {
                List<string> errors =new List<string>();
                errors.Add("خطا در بازیابی اطلاعات"+ex.Message);
                return new SubArticleImageComplexResult{Results = null,Errors = errors};
            }
        }

        public async Task<bool> HasSubArticleImageDuplicatedSubArticleImageByThisUrl(string url)
        {
            return await db.subArticleImage.AnyAsync(x => x.ImageUrl.Equals(url));
        }

        public async Task<bool> IsSubArticleImageExistedByThisId(int id)
        {
            return await db.subArticleImage.AnyAsync(x => x.Id == id);
        }
    }
}
