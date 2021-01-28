using CustomerRequestTracking.Functions.Data;
using CustomerRequestTracking.Functions.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerRequestTracking.Functions.Service
{
    public class RequestFormService : IRequestFormService
    {
        private readonly DataContext _dbcontext;

        public RequestFormService(DataContext context)
        {
            _dbcontext = context;
        }
         
        public async Task<RequestForm> CreateAsync(RequestForm input)
        {
            input.CreatedDate = DateTime.UtcNow;

            _dbcontext.RequestForms.Add(input);
            await _dbcontext.SaveChangesAsync();
            return input;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var data = await GetAsync(id);

            if (data == null)
                return false;

            _dbcontext.RequestForms.Remove(data);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<RequestForm> GetAsync(Guid id)
        {
            return await _dbcontext.RequestForms.FindAsync(id);
        }

        public async Task<List<RequestForm>> ListAsync()
        {
            return await _dbcontext.RequestForms.ToListAsync();
        }

        public async Task<RequestForm> UpdateAsync(Guid id, RequestForm input)
        {
            var data = await GetAsync(id);

            data.NameSurname = input.NameSurname;
            data.PhoneNumber = input.PhoneNumber;
            data.EMail       = input.EMail;
            data.Description = input.Description;

            await _dbcontext.SaveChangesAsync();

            return data;
        }
    }
}
