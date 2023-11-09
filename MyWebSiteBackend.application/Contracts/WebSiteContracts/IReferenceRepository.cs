using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.References;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Contracts.WebSiteContracts
{
    public interface IReferenceRepository:IBaseRepositorySearchable<Reference,ReferenceSearchModel,ReferenceComplexResult>
    {
        Task<bool> HasReferenceDuplicatedReferencesByThisNameAndLink(string name, string link);
        Task<bool> IsReferenceExistedByThisId(int id);
    }
}
