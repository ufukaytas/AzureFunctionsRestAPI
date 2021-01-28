using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using CustomerRequestTracking.Functions.Service;

namespace CustomerRequestTracking.Functions.Functions
{
    public  class GetRequestForm
    {
        private IRequestFormService _requestFormService;
        public GetRequestForm(IRequestFormService requestFormService)
        {
            _requestFormService = requestFormService;
        }

        [FunctionName("GetRequestForm")]
        public  async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "get/{id}")] HttpRequest req, string id,
            ILogger log) 
        {
            log.LogInformation("Get Request function processed a request.");

            var requestForm = await _requestFormService.GetAsync(new Guid(id));

            var responseMsg = $"Request Form is readed, the id is {requestForm.Id}";
            log.LogInformation(responseMsg);

            return new OkObjectResult(requestForm);
        }
    }
}
