#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;


public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    log.LogInformation("C# HTTP trigger function processed a request.");

    string name = req.Query["app_id"];

    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    dynamic data = JsonConvert.DeserializeObject(requestBody);
    //name = name ?? data?.app_id;
    string value = data?.payload_fields.Value;
    string sensorID = data?.payload_fields.sensorID;
    string sensorPassword = data?.payload_fields.sensorPassword;
    string result11 = "aa";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://lorastore20181206101456.azurewebsites.net/api/Measurements");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                //string json = "{ 'SensorId': 18, 'Value': 22, 'SensorPassword': 'sfsfeg'}";
              //  string json = "{ 'SensorId': 18, 'Value': 22, 'SensorPassword': 'sfsfeg'}";
                string json = "{ 'SensorId': "+ sensorID + ", 'Value': "+ value + ", 'SensorPassword': '"+sensorPassword +"'}";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                log.LogInformation("result back");
              //  Console.Write(result);
              result11 = result;

            }




    return value != null
        ? (ActionResult)new OkObjectResult($"Hello, value={value} sensorID={sensorID} pass=")
        : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
}
