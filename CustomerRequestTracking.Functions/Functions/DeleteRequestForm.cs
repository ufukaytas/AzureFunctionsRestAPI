using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using CustomerRequestTracking.Functions.Service;
using System;

namespace CustomerRequestTracking.Functions.Functions
{
    public class DeleteRequestForm
    { 
        private IRequestFormService _requestFormService;
        public DeleteRequestForm(IRequestFormService requestFormService)
        {
            _requestFormService = requestFormService;
        }

        [FunctionName("DeleteRequestForm")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "delete/{id}")] HttpRequest req, string id,
            ILogger log)
        {
            log.LogInformation("Delete Request Form function processed a request.");

            var result = await _requestFormService.DeleteAsync(new Guid(id));

            var responseMsg = $"Request Form item is deleted: {result}";
            log.LogInformation(responseMsg);

            return new OkObjectResult(responseMsg);
        }
    }
}
