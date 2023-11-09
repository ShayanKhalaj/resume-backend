using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticleImages;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Contracts.WebSiteContracts
{
    public interface ISubArticleImageRepository:IBaseRepositorySearchable<SubArticleImage, SubArticleImageSearchModel, SubArticleImageComplexResult>
    {
        Task<bool> HasSubArticleImageDuplicatedSubArticleImageByThisUrl(string url);
        Task<bool> IsSubArticleImageExistedByThisId(int id);
    }
}
