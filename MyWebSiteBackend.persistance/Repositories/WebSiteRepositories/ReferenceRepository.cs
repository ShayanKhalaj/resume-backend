using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.References;
using MyWebSiteBackend.domain.Models.WebSiteModels;
using MyWebSiteBackend.persistance.DbContexts;

namespace MyWebSiteBackend.persistance.Repositories.WebSiteRepositories
{
    public class ReferenceRepository:BaseRepository<Reference>,IReferenceRepository
    {
        private readonly MyWebSiteDbContext db;
        public ReferenceRepository(MyWebSiteDbContext db) : base(db)
        {
            this.db = db;
        }

        public async Task<ReferenceComplexResult> SearchAsync(ReferenceSearchModel sm)
        {
            try
            {
                var references = from item in db.references select item;
                if(sm.ArticleID<=0)
                {
                    references = references.Where(x => x.ArticleID > 0);
                }
                if(sm.ArticleID>0)
                {
                    references = references.Where(x => x.ArticleID == sm.ArticleID);
                }
                if (sm.Id <= 0)
                {
                    references = references.Where(x => x.Id > 0);
                }
                if (sm.Id > 0)
                {
                    references = references.Where(x => x.Id == sm.Id);
                }
                if(sm.Description!=null)
                {
                    references = references.Where(x => x.Description.Equals(sm.Description));
                }
                if (sm.Link != null)
                {
                    references = references.Where(x => x.Link.Equals(sm.Link));
                }
                if (sm.Text != null)
                {
                    references = references.Where(x => x.Text.Equals(sm.Text));
                }
                if (sm.Name != null)
                {
                    references = references.Where(x => x.Name.Equals(sm.Name));
                }
                var result = await references.Select(x => new ReferencesListItem
                    {
                        ModifiedBy = x.ModifiedBy
                        ,CreatedDate = x.CreatedDate
                        ,ModifiedDate = x.ModifiedDate
                        ,CreatedBy = x.CreatedBy
                        ,ArticleID = x.ArticleID
                        ,Description = x.Description
                        ,Text = x.Text
                        ,Name = x.Name
                        ,Link = x.Link
                        ,Id = x.Id
                    })
                    .OrderBy(x => x.Name).ToListAsync();
                return new ReferenceComplexResult{Results = result,Errors = null};

            }
            catch(Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add("خطا در بازیابی اطلاعات"+ex.Message);
                return new ReferenceComplexResult{Results = null,Errors = errors};
            }
        }

        public async Task<bool> HasReferenceDuplicatedReferencesByThisNameAndLink(string name, string link)
        {
            return await db.references
                .AnyAsync(x => 
                    x.Name.Equals(name)
                    && x.Link.Equals(link));
        }

        public async Task<bool> IsReferenceExistedByThisId(int id)
        {
            return await db.references.AnyAsync(x => x.Id == id);
        }
    }
}
