using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSiteBackend.application.Contracts
{
    public interface IBaseRepositorySearchable<T,TSearchModel,TSearchResult>:IBaseRepository<T>
    {
        /// <summary> 
        /// </summary>
        /// <param name="sm">sm = search model</param>
        /// <returns></returns>
        Task<TSearchResult> SearchAsync(TSearchModel sm);
    }
}
