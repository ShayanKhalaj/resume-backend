using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.ReadMores;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Contracts.WebSiteContracts
{
    public interface IReadMoreRepository:IBaseRepositorySearchable<ReadMore,ReadMoreSearchModel,ReadMoreComplexResult>
    {
        Task<bool> HasReadMoreDuplicatedReadMoresByThisNameAndLink(string name, string link);
        Task<bool> IsReadMoreExistedByThisId(int id);
    }
}
