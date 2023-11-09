using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebSiteBackend.application.Contracts;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Articles;
using MyWebSiteBackend.domain.Models.WebSiteModels;
using MyWebSiteBackend.persistance.DbContexts;

namespace MyWebSiteBackend.persistance.Repositories.WebSiteRepositories
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        private readonly MyWebSiteDbContext db;
        public ArticleRepository(MyWebSiteDbContext db) : base(db)
        {
            this.db = db;
        }

        public async Task<ArticleComplexResult> SearchAsync(ArticleSearchModel sm)
        {
            List<string> Errors = new List<string>();
            try
            {
                var art = from item in db.articles select item;
                if (sm.Id == -1)
                {
                    art = art.Where(x => x.Id > 0);
                }
                if (sm.Id > 0)
                {
                    art = art.Where(x => x.Id == sm.Id);
                }

                if (sm.CategoryID == -1)
                {
                    art = art.Where(x => x.CategoryID > 0);
                }
                if (sm.CategoryID > 0)
                {
                    art = art.Where(x => x.CategoryID == sm.CategoryID);
                }

                if (!string.IsNullOrEmpty(sm.Description))
                {
                    art = art.Where(x => x.Description.Trim().ToLower().Contains(sm.Description.ToLower()));
                }
                if (!string.IsNullOrEmpty(sm.Text))
                {
                    art = art.Where(x => x.Text.Trim().ToLower().StartsWith(sm.Text.ToLower()));
                }
                if (!string.IsNullOrEmpty(sm.Title))
                {
                    art = art.Where(x => x.Title.Trim().ToLower().StartsWith(sm.Title.ToLower()));
                }
                if (sm.Rate < 0)
                {
                    art = art.Where(x => x.Rate >= 0);
                }
                if (sm.Rate >= 0)
                {
                    art = art.Where(x => x.Rate == sm.Rate);
                }
                var q = art.Select(x => new ArticlesListItem
                {
                    Id = x.Id
                            ,
                    AudioDescription = x.AudioDescription
                            ,
                    Title = x.Title
                            ,
                    CategoryID = x.CategoryID
                            ,
                    AudioUrl = x.AudioUrl
                            ,
                    Description = x.Description
                            ,
                    Text = x.Text
                            ,
                    VideoUrl = x.VideoUrl
                            ,
                    Rate = x.Rate
                            ,
                    CreatedBy = x.CreatedBy
                            ,
                    ModifiedBy = x.ModifiedBy
                            ,
                    VideoDescription = x.VideoDescription
                            ,
                    CategoryName = x.Category.CategoryName
                });
                var result = await q.OrderBy(x => x.Title).ToListAsync();
                return new ArticleComplexResult { Results = result, Errors = null };


            }
            catch (Exception ex)
            {
                Errors.Add("بازیابی اطلاعات ناموفق" + ex.Message);
                return new ArticleComplexResult { Errors = Errors, Results = null };
            }
        }


        public async Task<bool> IsArticleExistedByThisIdAsync(int id)
        {
            return await db.articles.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> DeleteRelatedImagesAsync(int id)
        {
            try
            {
                var images = await db.articleImages.ToListAsync();

                foreach (var image in images)
                {
                    if (image.ArticleID == id)
                    {
                        db.articleImages.Remove(image);
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

        public async Task<bool> DeleteRelatedKeywordsAsync(int id)
        {
            try
            {
                var keywords = await db.keywords.ToListAsync();
                foreach (var keyword in keywords)
                {
                    if (keyword.ArticleID == id)
                    {
                        db.keywords.Remove(keyword);
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

        public async Task<bool> DeleteRelatedMetaTagsAsync(int id)
        {
            try
            {
                var metaTags = await db.metaTags.ToListAsync();

                foreach (var tag in metaTags)
                {
                    if (tag.ArticleID == id)
                    {
                        db.metaTags.Remove(tag);
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

        public async Task<bool> DeleteRelatedCommentsAsync(int id)
        {
            try
            {
                var comments = await db.comments.ToListAsync();

                foreach (var comment in comments)
                {
                    if (comment.ArticleID == id)
                    {
                        db.comments.Remove(comment);
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


        public async Task<bool> DeleteRelatedReferencesAsync(int id)
        {
            try
            {
                var references = await db.references.ToListAsync();
                foreach (var reference in references)
                {
                    if (reference.ArticleID == id)
                    {
                        db.references.Remove(reference);
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

        public async Task<bool> DeleteRelatedSubArticlesAsync(int id)
        {
            try
            {
                var subArticles = await db.subArticles.ToListAsync();
                foreach (var subArticle in subArticles)
                {
                    if (subArticle.ArticleID == id)
                    {
                        var images = await db.subArticleImage.ToListAsync();
                        foreach (var image in images)
                        {
                            if (image.SubArticleID == subArticle.Id)
                            {
                                db.subArticleImage.Remove(image);
                                await db.SaveChangesAsync();
                            }
                        }
                        var readMores = await db.readMores.ToListAsync();
                        foreach (var readMore in readMores)
                        {
                            if (readMore.SubArticleID == subArticle.Id)
                            {
                                db.readMores.Remove(readMore);
                                await db.SaveChangesAsync();
                            }
                        }
                        db.subArticles.Remove(subArticle);
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

        public async Task<bool> HasDuplicatedTitleAsync(string Title)
        {
            return await db.articles.AnyAsync(x => x.Title.StartsWith(Title));
        }

        public async Task<bool> HasDuplicatedTitleByThisIdAsync(int id)
        {
            return await db.articles.AnyAsync(x => x.Id == id);
        }
    }
}
