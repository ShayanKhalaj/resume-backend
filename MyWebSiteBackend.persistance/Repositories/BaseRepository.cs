using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyWebSiteBackend.application.common;
using MyWebSiteBackend.application.Contracts;
using MyWebSiteBackend.persistance.DbContexts;
using Newtonsoft.Json;

namespace MyWebSiteBackend.persistance.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly MyWebSiteDbContext db;

        public BaseRepository(MyWebSiteDbContext db)
        {
            this.db = db;
        }
        public async Task<OperationResult> DeleteAsync(int id)
        {
            OperationResult op = new OperationResult("Delete");
            try
            {
                var model = await GetAsync(id);
                db.Remove(model);
                await db.SaveChangesAsync();
                return op.Succeeded("حذف موفق", HttpStatusCode.OK, model);
            }
            catch (Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add("عملیات ناموفق"+ex.Message);
                return op.Failed("حذف ناموفق", HttpStatusCode.BadGateway, errors);
            }
        }

        public async Task<OperationResult> CreateAsync(T model)
        {
            OperationResult op = new OperationResult("Create");
            try
            {
                await db.Set<T>().AddAsync(model);
                await db.SaveChangesAsync();
                return op.Succeeded("ثبت موفق", HttpStatusCode.OK, model);
            }
            catch(Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add("عملیات ناموفق" + ex.Message);
                return op.Failed("ثبت ناموفق", HttpStatusCode.BadGateway, errors);
            }
        }

        public async Task<OperationResult> EditAsync(T model)
        {
            OperationResult op =new OperationResult("Edit");
            try
            {
                db.Attach<T>(model);
                db.Entry<T>(model).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return op.Succeeded("ویرایش موفق", HttpStatusCode.OK, model);
            }
            catch(Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add("عملیات ناموفق" + ex.Message);
                return op.Failed("ویرایش ناموفق", HttpStatusCode.BadGateway, errors);
            }

            
        }

        public async Task<T> GetAsync(int id)
        {
            return await db.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await db.Set<T>().ToListAsync();
        }
    }
}
