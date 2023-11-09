using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.RelatedArticles;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Contracts.WebSiteContracts
{
    public interface IRelatedArticleRepository:IBaseRepositorySearchable<RelatedArticle,RelatedArticleSearchModel,RelatedArticleComplexResult>
    {
        Task<bool> HasRelatedArticleDuplicatedRelatedArticlesByThisName(string name);
        Task<bool> IsRelatedArticleExistedByThisId(int id);
    }
}
