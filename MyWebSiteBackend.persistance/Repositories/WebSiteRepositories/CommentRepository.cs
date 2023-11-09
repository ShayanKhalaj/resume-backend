using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Comments;
using MyWebSiteBackend.domain.Models.WebSiteModels;
using MyWebSiteBackend.persistance.DbContexts;

namespace MyWebSiteBackend.persistance.Repositories.WebSiteRepositories
{
    public class CommentRepository:BaseRepository<Comment>,ICommentRepository
    {
        private readonly MyWebSiteDbContext db;
        public CommentRepository(MyWebSiteDbContext db) : base(db)
        {
            this.db = db;
        }

        public async Task<CommentComplexResult> SearchAsync(CommentSearchModel sm)
        {
            try
            {
                var comments = from item in db.comments select item;
                if(sm.Id<=0)
                {
                    comments = comments.Where(x => x.Id > 0);
                }
                if (sm.Id >0)
                {
                    comments = comments.Where(x => x.Id == sm.Id);
                }
                if(sm.ArticleID<=0)
                {
                    comments = comments.Where(x => x.ArticleID > 0);
                }
                if (sm.ArticleID <= 0)
                {
                    comments = comments.Where(x => x.ArticleID > 0);
                }
                if(sm.HasSeen)
                {
                    comments = comments.Where(x => x.HasSeen == sm.HasSeen);
                }
                if (sm.IsAccepted)
                {
                    comments = comments.Where(x => x.IsAccepted == sm.IsAccepted);
                }
                if (sm.IsAnswered)
                {
                    comments = comments.Where(x => x.IsAnswered == sm.IsAnswered);
                }
                if(sm.LikedCount <1)
                {
                    comments = comments.Where(x => x.LikedCount > 0);
                }
                if(sm.LikedCount>0)
                {
                    comments = comments.Where(x => x.DislikedCount == sm.DislikedCount);
                }
                if (sm.LikedCount < 1)
                {
                    comments = comments.Where(x => x.LikedCount > 0);
                }
                if (sm.LikedCount > 0)
                {
                    comments = comments.Where(x => x.LikedCount == sm.LikedCount);
                }
                var result =await comments.Select(x => new CommentsListItem
                {
                    ArticleID = x.ArticleID
                    ,
                    HasSeen = x.HasSeen
                    ,
                    LikedCount = x.LikedCount
                    ,
                    IsAccepted = x.IsAccepted
                    ,
                    IsAnswered = x.IsAnswered
                    ,
                    ModifiedBy = x.ModifiedBy
                    ,
                    CreatedBy = x.CreatedBy
                    ,
                    CreatedDate = x.CreatedDate
                    ,
                    ModifiedDate = x.ModifiedDate
                    ,
                    Name = x.Name
                    ,
                    Text = x.Text
                    ,
                    DislikedCount = x.DislikedCount
                    ,
                    Answer = x.Answer
                    ,
                    Email = x.Email
                    ,
                    Id = x.Id
                }).OrderBy(x => x.CreatedDate).ToListAsync();
                return new CommentComplexResult{Results = result,Errors = null};
            }
            catch(Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add("خطا در بازیابی اطلاعات"+ex.Message);
                return new CommentComplexResult { Results = null, Errors = errors };
            }
        }

        public async Task<bool> HasCommentDuplicatedCommentByThisContent(string content)
        {
            return await db.comments.AnyAsync(x => x.Text.Equals(content));
        }

        public async Task<bool> IsCommentExistedByThisId(int id)
        {
            return await db.comments.AnyAsync(x => x.Id == id);
        }

        public async Task<int> LikeThisComment(int id, bool like)
        {
            var comment = await db.comments.FirstOrDefaultAsync(x => x.Id == id);
            if(like==true)
            {
                comment.LikedCount = comment.LikedCount+1;
            }
            db.comments.Attach(comment);
            db.Entry<Comment>(comment).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return comment.LikedCount;
        }

        public async Task<int> DisLikeThisComment(int id,bool disLike)
        {
            var comment = await db.comments.FirstOrDefaultAsync(x => x.Id == id);
            if (disLike == true)
            {
                comment.DislikedCount = comment.DislikedCount + 1;
            }
            db.comments.Attach(comment);
            db.Entry<Comment>(comment).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return comment.DislikedCount;
        }

        public async Task<bool> AdminAcceptsThisComment(int id,bool accepted)
        {
            var comment = await db.comments.FirstOrDefaultAsync(x => x.Id == id);
            if (accepted == true)
            {
                comment.IsAccepted = true;
                db.comments.Attach(comment);
                db.Entry<Comment>(comment).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                comment.IsAccepted = false;
                db.comments.Attach(comment);
                db.Entry<Comment>(comment).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
           
            return comment.IsAccepted;
        }

        public Task<bool> AdminAnswersThisComment(int id, bool answered)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AdminSeeThisComment(int id, bool seen)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AdminAnsweredThisComment(int id,bool answered)
        {
            var comment = await db.comments.FirstOrDefaultAsync(x => x.Id == id);
            if (answered == true)
            {
                comment.IsAnswered = true;
                db.comments.Attach(comment);
                db.Entry<Comment>(comment).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                comment.IsAnswered = false;
                db.comments.Attach(comment);
                db.Entry<Comment>(comment).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }

            return comment.IsAnswered;
        }

        public async Task<bool> AdminSeenThisComment(int id,bool seen)
        {
            var comment = await db.comments.FirstOrDefaultAsync(x => x.Id == id);
            if (seen == true)
            {
                comment.HasSeen = true;
                db.comments.Attach(comment);
                db.Entry<Comment>(comment).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                comment.HasSeen = false;
                db.comments.Attach(comment);
                db.Entry<Comment>(comment).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }

            return comment.HasSeen;
        }

        public async Task<List<CommentDto>> ReturnAcceptedComments()
        {
            var comments = await db.comments.Where(x=>x.IsAccepted==true).ToListAsync();
            List<CommentDto> commentsList = new List<CommentDto>();
            foreach(var commnet in comments)
            {
                CommentDto commentDto = new CommentDto
                {
                    IsAccepted = commnet.IsAccepted
                    ,IsAnswered = commnet.IsAnswered
                    ,HasSeen = commnet.HasSeen
                    ,DislikedCount = commnet.DislikedCount
                    ,LikedCount = commnet.LikedCount
                    ,ArticleID = commnet.ArticleID
                    ,Id = commnet.ArticleID
                    ,ModifiedBy = commnet.ModifiedBy
                    ,CreatedDate = commnet.CreatedDate
                    ,CreatedBy = commnet.CreatedBy
                    ,ModifiedDate = commnet.ModifiedDate
                    ,Text = commnet.Text
                    ,Name = commnet.Name
                    ,Answer = commnet.Answer
                    ,Email = commnet.Email
                };
                commentsList.Add(commentDto);
            }
            return commentsList;
        }

        public async Task<List<CommentDto>> ReturnAnsweredComments()
        {
            var comments = await db.comments.Where(x => x.IsAnswered == true).ToListAsync();
            List<CommentDto> commentsList = new List<CommentDto>();
            foreach (var commnet in comments)
            {
                CommentDto commentDto = new CommentDto
                {
                    IsAccepted = commnet.IsAccepted
                    ,
                    IsAnswered = commnet.IsAnswered
                    ,
                    HasSeen = commnet.HasSeen
                    ,
                    DislikedCount = commnet.DislikedCount
                    ,
                    LikedCount = commnet.LikedCount
                    ,
                    ArticleID = commnet.ArticleID
                    ,
                    Id = commnet.ArticleID
                    ,
                    ModifiedBy = commnet.ModifiedBy
                    ,
                    CreatedDate = commnet.CreatedDate
                    ,
                    CreatedBy = commnet.CreatedBy
                    ,
                    ModifiedDate = commnet.ModifiedDate
                    ,
                    Text = commnet.Text
                    ,
                    Name = commnet.Name
                    ,
                    Answer = commnet.Answer
                    ,
                    Email = commnet.Email
                };
                commentsList.Add(commentDto);
            }
            return commentsList;
        }

        public async Task<List<CommentDto>> ReturnSeenComments()
        {
            var comments = await db.comments.Where(x => x.HasSeen == true).ToListAsync();
            List<CommentDto> commentsList = new List<CommentDto>();
            foreach (var commnet in comments)
            {
                CommentDto commentDto = new CommentDto
                {
                    IsAccepted = commnet.IsAccepted
                    ,
                    IsAnswered = commnet.IsAnswered
                    ,
                    HasSeen = commnet.HasSeen
                    ,
                    DislikedCount = commnet.DislikedCount
                    ,
                    LikedCount = commnet.LikedCount
                    ,
                    ArticleID = commnet.ArticleID
                    ,
                    Id = commnet.ArticleID
                    ,
                    ModifiedBy = commnet.ModifiedBy
                    ,
                    CreatedDate = commnet.CreatedDate
                    ,
                    CreatedBy = commnet.CreatedBy
                    ,
                    ModifiedDate = commnet.ModifiedDate
                    ,
                    Text = commnet.Text
                    ,
                    Name = commnet.Name
                    ,
                    Answer = commnet.Answer
                    ,
                    Email = commnet.Email
                };
                commentsList.Add(commentDto);
            }
            return commentsList;
        }
    }
}
