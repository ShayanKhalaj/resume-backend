using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Keywords;
using MyWebSiteBackend.domain.Models.WebSiteModels;
using MyWebSiteBackend.persistance.DbContexts;

namespace MyWebSiteBackend.persistance.Repositories.WebSiteRepositories
{
    public class KeywordRepository:BaseRepository<Keyword>,IKeywordRepository
    {
        private readonly MyWebSiteDbContext db;
        public KeywordRepository(MyWebSiteDbContext db) : base(db)
        {
            this.db = db;
        }

        public async Task<KeywordComplexResult> SearchAsync(KeywordSearchModel sm)
        {
            try
            {
                var keywords = from item in db.keywords select item;
                if(sm.ArticleID<=0)
                {
                    keywords = keywords.Where(x => x.ArticleID > 0);
                }
                if(sm.ArticleID>0)
                {
                    keywords = keywords.Where(x => x.ArticleID == sm.ArticleID);
                }
                if (sm.Id <= 0)
                {
                    keywords = keywords.Where(x => x.Id > 0);
                }
                if (sm.Id > 0)
                {
                    keywords = keywords.Where(x => x.Id == sm.Id);
                }
                if(sm.Text!=null)
                {
                    keywords = keywords.Where(x => x.Text.Equals(sm.Text));
                }
                if (sm.Description != null)
                {
                    keywords = keywords.Where(x => x.Description.Equals(sm.Description));
                }
                if (sm.Name != null)
                {
                    keywords = keywords.Where(x => x.Name.Equals(sm.Name));
                }
                var result = await keywords.Select(x => new KeywordsListItem
                {
                    ArticleID = x.ArticleID
                    ,ModifiedBy = x.ModifiedBy
                    ,CreatedBy = x.CreatedBy
                    ,CreatedDate = x.CreatedDate
                    ,ModifiedDate = x.ModifiedDate
                    , Text = x.Text
                    , Name = x.Name
                    ,Description = x.Description
                    ,Id = x.Id
                }).OrderBy(x=>x.Text).ToListAsync();
                return new KeywordComplexResult{Results = result,Errors = null};
            }
            catch(Exception ex)
            {
                List<string> errors =new List<string>();
                errors.Add("خطا دربازیابی اطلاعات"+ex.Message);
                return new KeywordComplexResult{Results = null,Errors = errors};
            }

        }

        public async Task<bool> HasKeywordDuplicatedKeywordsByThisName(string name)
        {
            return await db.keywords.AnyAsync(x => x.Name.Equals(name));
        }

        public async Task<bool> IsKeywordExistedByThisId(int id)
        {
            return await db.keywords.AnyAsync(x => x.Id == id);
        }
    }
}
