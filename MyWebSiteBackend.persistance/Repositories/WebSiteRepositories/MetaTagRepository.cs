using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebSiteBackend.application.Contracts;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.MetaTags;
using MyWebSiteBackend.domain.Models.WebSiteModels;
using MyWebSiteBackend.persistance.DbContexts;

namespace MyWebSiteBackend.persistance.Repositories.WebSiteRepositories
{
    public class MetaTagRepository:BaseRepository<MetaTag>,IMetaTagRepository
    {
        private readonly MyWebSiteDbContext db;
        public MetaTagRepository(MyWebSiteDbContext db) : base(db)
        {
            this.db = db;
        }

        public async Task<MetaTagComplexResult> SearchAsync(MetaTagSearchModel sm)
        {
            try
            {
                var metaTags = from item in db.metaTags select item;
                if (sm.ArticleID <= 0)
                {
                    metaTags = metaTags.Where(x => x.ArticleID > 0);
                }
                if (sm.ArticleID > 0)
                {
                    metaTags = metaTags.Where(x => x.ArticleID == sm.ArticleID);
                }
                if (sm.Id <= 0)
                {
                    metaTags = metaTags.Where(x => x.Id > 0);
                }
                if (sm.Id > 0)
                {
                    metaTags = metaTags.Where(x => x.Id == sm.Id);
                }
                if (sm.Description != null)
                {
                    metaTags = metaTags.Where(x => x.Description.Equals(x.Description));
                }
                if (sm.Tag != null)
                {
                    metaTags = metaTags.Where(x => x.Tag.Equals(sm.Tag));
                }
                if (sm.TagName != null)
                {
                    metaTags = metaTags.Where(x => x.TagName.Equals(sm.TagName));
                }
                var result = await metaTags.Select(x => new MetaTagsListItem
                {
                    ArticleID = x.ArticleID
                    ,
                    ModifiedBy = x.ModifiedBy
                    ,
                    CreatedBy = x.CreatedBy
                    ,
                    CreatedDate = x.CreatedDate
                    ,
                    ModifiedDate = x.ModifiedDate
                    ,
                    Description = x.Description
                    ,
                    Tag = x.Tag
                    ,
                    TagName = x.TagName
                    ,
                    Id = x.Id
                }).ToListAsync();
                return new MetaTagComplexResult { Results = result, Errors = null };
            }
            catch(Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add("خطا در بازیابی اطلاعات"+ex.Message);
                return new MetaTagComplexResult{Results = null,Errors = errors};
            }
        }

        public async Task<bool> HasMetaTagDuplicatedMetaTagByThisTag(string tag)
        {
            return await db.metaTags.AnyAsync(x => x.Tag.Equals(tag));
        }

        public async Task<bool> IsMetaTagExistedByThisId(int id)
        {
            return await db.metaTags.AnyAsync(x => x.Id == id);
        }
    }
}
