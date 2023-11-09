using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.common;

namespace MyWebSiteBackend.application.Contracts
{
    public interface IBaseRepository<T>
    {
        Task<OperationResult> DeleteAsync(int id);
        Task<OperationResult> CreateAsync(T model);
        Task<OperationResult> EditAsync(T model);
        Task<T> GetAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
    }
}
