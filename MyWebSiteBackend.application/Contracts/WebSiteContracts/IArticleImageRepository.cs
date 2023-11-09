using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.ArticleImages;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Contracts.WebSiteContracts
{
    public interface IArticleImageRepository:IBaseRepositorySearchable<ArticleImage,ArticleImageSearchModel,ArticleImageComplexResult>
    {
        Task<bool> HasArticleImageDuplicatedArticleImageByThisUrl(string url);
        Task<bool> IsArticleImageExistedByThisId(int id);
    }
}
