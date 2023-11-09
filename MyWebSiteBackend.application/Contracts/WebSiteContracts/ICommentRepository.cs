using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSiteBackend.application.common;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Comments;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Contracts.WebSiteContracts
{
    public interface ICommentRepository:IBaseRepositorySearchable<Comment,CommentSearchModel,CommentComplexResult>
    {
        Task<bool> HasCommentDuplicatedCommentByThisContent(string content);
        Task<bool> IsCommentExistedByThisId(int id);
        Task<int> LikeThisComment(int id,bool like);
        Task<int> DisLikeThisComment(int id, bool like);
        Task<bool> AdminAcceptsThisComment(int id,bool accepted);
        Task<bool> AdminAnswersThisComment(int id,bool answered);
        Task<bool> AdminSeeThisComment(int id,bool seen);
        Task<List<CommentDto>> ReturnAcceptedComments();
        Task<List<CommentDto>> ReturnAnsweredComments();
        Task<List<CommentDto>> ReturnSeenComments();
    }
}
