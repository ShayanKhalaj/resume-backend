using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Articles;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Contracts.WebSiteContracts
{
    public interface IArticleRepository:IBaseRepositorySearchable<Article,ArticleSearchModel,ArticleComplexResult>
    {
        Task<bool> IsArticleExistedByThisIdAsync(int id);
        Task<bool> DeleteRelatedImagesAsync(int id);
        Task<bool> DeleteRelatedKeywordsAsync(int id);
        Task<bool> DeleteRelatedMetaTagsAsync(int id);
        Task<bool> DeleteRelatedCommentsAsync(int id);
        Task<bool> DeleteRelatedReferencesAsync(int id);
        Task<bool> DeleteRelatedSubArticlesAsync(int id);
        Task<bool> HasDuplicatedTitleAsync(string title);
        Task<bool> HasDuplicatedTitleByThisIdAsync(int id);
    }
}
