using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using CustomerRequestTracking.Functions.Service;

namespace CustomerRequestTracking.Functions.Functions
{
    public class ListRequestForm
    {
        private IRequestFormService _requestFormService;
        public ListRequestForm(IRequestFormService requestFormService)
        {
            _requestFormService = requestFormService;
        }

        [FunctionName("ListRequestForm")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "list")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Get Request function processed a request.");

            var listRequestForm = await _requestFormService.ListAsync();

            var responseMsg = $"Request Form is readed, total count: {listRequestForm.Count}";
            log.LogInformation(responseMsg);

            return new OkObjectResult(listRequestForm);
        }
    }
}
