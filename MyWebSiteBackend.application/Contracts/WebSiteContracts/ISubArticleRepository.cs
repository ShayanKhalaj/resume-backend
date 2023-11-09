using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticles;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Contracts.WebSiteContracts
{
    public interface ISubArticleRepository:IBaseRepositorySearchable<SubArticle, SubArticleSearchModel, SubArticleComplexResult>
    {
        Task<bool> HasSubArticleDuplicatedSubArticleByThisTitle(string title);
        Task<bool> IsSubArticleExistedByThisId(int id);
    }
}
