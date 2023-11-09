using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Keywords;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Contracts.WebSiteContracts
{
    public interface IKeywordRepository:IBaseRepositorySearchable<Keyword,KeywordSearchModel,KeywordComplexResult>
    {
        Task<bool> HasKeywordDuplicatedKeywordsByThisName(string name);
        Task<bool> IsKeywordExistedByThisId(int id);
    }
}
