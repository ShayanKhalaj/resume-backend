using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Categories;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Contracts.WebSiteContracts
{
    public interface ICategoryRepository:IBaseRepositorySearchable<Category,CategorySearchModel,CategoryComplexResult>
    {
        Task<bool> IsExistedCategoryByThisIdAsync(int id);
        Task<bool> DeleteRelatedArticlesByThisId(int id);
        Task<bool> HasDuplicatedCategoryByThisNameAsync(string name);
        
    }
}
