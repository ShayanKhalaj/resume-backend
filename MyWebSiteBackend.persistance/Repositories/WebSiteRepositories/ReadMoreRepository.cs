using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.ReadMores;
using MyWebSiteBackend.domain.Models.WebSiteModels;
using MyWebSiteBackend.persistance.DbContexts;

namespace MyWebSiteBackend.persistance.Repositories.WebSiteRepositories
{
    public class ReadMoreRepository:BaseRepository<ReadMore>,IReadMoreRepository
    {
        private readonly MyWebSiteDbContext db;
        public ReadMoreRepository(MyWebSiteDbContext db) : base(db)
        {
            this.db = db;
        }

        public async Task<ReadMoreComplexResult> SearchAsync(ReadMoreSearchModel sm)
        {
            try
            {
                var readMores = from item in db.readMores select item;
                if(sm.Id<=0)
                {
                    readMores = readMores.Where(x => x.Id > 0);
                }
                if(sm.Id>0)
                {
                    readMores = readMores.Where(x => x.Id == sm.Id);
                }
                if (sm.SubArticleID <= 0)
                {
                    readMores = readMores.Where(x => x.SubArticleID > 0);
                }
                if (sm.SubArticleID > 0)
                {
                    readMores = readMores.Where(x => x.SubArticleID == sm.SubArticleID);
                }
                if(sm.Description!=null)
                {
                    readMores = readMores.Where(x => x.Description.Equals(sm.Description));
                }
                if (sm.LinkText != null)
                {
                    readMores = readMores.Where(x => x.LinkText.Equals(sm.LinkText));
                }
                if (sm.LinkName != null)
                {
                    readMores = readMores.Where(x => x.LinkName.Equals(sm.LinkName));
                }
                var result = await readMores.Select(x => new ReadMoresListItem
                {
                    ModifiedBy = x.ModifiedBy
                    ,ModifiedDate = x.ModifiedDate
                    ,CreatedBy = x.CreatedBy
                    ,CreatedDate = x.CreatedDate
                    ,Description = x.Description
                    ,LinkName = x.LinkName
                    ,LinkText = x.LinkText
                    ,SubArticleID = x.SubArticleID
                    ,Id = x.Id
                }).OrderBy(x=>x.LinkName).ToListAsync();
                return new ReadMoreComplexResult{Results = result,Errors = null};
            }
            catch(Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add("خطا در بازیابی اطلاعات"+ex.Message);
                return new ReadMoreComplexResult{Results = null,Errors = errors};
            }
        }

        public async Task<bool> HasReadMoreDuplicatedReadMoresByThisNameAndLink(string name, string link)
        {
            return await db.readMores.AnyAsync(x => x.LinkName.Equals(name) && x.LinkText.Equals(link));
        }

        public async Task<bool> IsReadMoreExistedByThisId(int id)
        {
            return await db.readMores.AnyAsync(x => x.Id == id);
        }
    }
}
