
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.HTTP;
using Microsoft.AspNetCore.HTTP;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System.Net.HTTP;
using System.Text;


namespace Company.function
{
    public static class GetResumeCounter
    {
        [functionName ("GetResumeCounter")]

        public static HTTPResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(databaseName:"cosmodbresume", collectionName: "AzureResume", ConnectionStringSetting ="AzureResumeConnectionString", Id = "1", PartitionKey = "1")] Counter counter,
            [CosmosDB(databaseName:"cosmodbresume", collectionName: "AzureResume", ConnectionStringSetting ="AzureResumeConnectionString", Id = "1", PartitionKey = "1")] out Counter updatedcounter,
            ILogger log)
        {

            log.LogInformation("C# HTTP trigger function processed a request");

            updatedcounter = counter;
            updatedcounter.Count += 1;

            var JsonToReturn = JsonConvert.SerializeObject(counter);

            return new HTTPResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(JsonToReturn, Encoding.UTF8, "application/json")
            };
        }
    }
}



/*
public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    log.LogInformation("C# HTTP trigger function processed a request.");

    string name = req.Query["name"];

    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    dynamic data = JsonConvert.DeserializeObject(requestBody);
    name = name ?? data?.name;

    string responseMessage = string.IsNullOrEmpty(name)
        ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
}
*/