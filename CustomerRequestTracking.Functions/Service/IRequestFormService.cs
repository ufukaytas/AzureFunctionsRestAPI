using CustomerRequestTracking.Functions.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerRequestTracking.Functions.Service
{
    public interface IRequestFormService
    {
        Task<RequestForm> CreateAsync(RequestForm input);
        Task<RequestForm> GetAsync(Guid id);
        Task<RequestForm> UpdateAsync(Guid id, RequestForm input);
        Task<bool> DeleteAsync(Guid id);
        Task<List<RequestForm>> ListAsync();
    }
}
