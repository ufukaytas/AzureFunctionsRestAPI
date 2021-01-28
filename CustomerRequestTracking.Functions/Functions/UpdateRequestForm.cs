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
    public class UpdateRequestForm
    {
        private IRequestFormService _requestFormService;
        public UpdateRequestForm(IRequestFormService requestFormService)
        {
            _requestFormService = requestFormService;
        }

        [FunctionName("UpdateRequestForm")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function,  "put", Route = "update/{id}")] HttpRequest req, string id, ILogger log)
        {
            log.LogInformation("Update Request function processed a request.");

            string bodyStr = await new StreamReader(req.Body).ReadToEndAsync();
            var input = JsonConvert.DeserializeObject<RequestForm>(bodyStr);

            var requestForm = await _requestFormService.UpdateAsync(new Guid(id), input);

            var responseMsg = $"Request Form is updated, the id is {requestForm.Id}";

            log.LogInformation(responseMsg);

            return new OkObjectResult(responseMsg);
        }
    }
}
