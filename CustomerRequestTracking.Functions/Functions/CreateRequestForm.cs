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
using CustomerRequestTracking.Functions.Model;

namespace CustomerRequestTracking.Functions.Functions
{
    public class CreateRequestForm
    {
        private IRequestFormService _requestFormService;
        public CreateRequestForm(IRequestFormService requestFormService)
        {
            _requestFormService = requestFormService;
        }
         
        [FunctionName("CreateRequestForm")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "create")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Create Request function processed a request.");

            
            string bodyStr = await new StreamReader(req.Body).ReadToEndAsync();
            var input = JsonConvert.DeserializeObject<RequestForm>(bodyStr);
            var requestForm = await _requestFormService.CreateAsync(input);
             
            var responseMsg = $"Request Form is created, the id is {requestForm.Id}";

            log.LogInformation(responseMsg);

            return new OkObjectResult(responseMsg);
        }
    }
}
