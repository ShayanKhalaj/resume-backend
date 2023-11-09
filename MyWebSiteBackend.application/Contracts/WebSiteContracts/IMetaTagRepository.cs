using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.MetaTags;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Contracts.WebSiteContracts
{
    public interface IMetaTagRepository:IBaseRepositorySearchable<MetaTag,MetaTagSearchModel,MetaTagComplexResult>
    {
        Task<bool> HasMetaTagDuplicatedMetaTagByThisTag(string tag);
        Task<bool> IsMetaTagExistedByThisId(int id);
    }
}
