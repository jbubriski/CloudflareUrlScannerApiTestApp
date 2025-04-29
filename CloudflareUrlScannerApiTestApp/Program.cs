// See https://aka.ms/new-console-template for more information

// API Docs
// https://developers.cloudflare.com/api/resources/url_scanner/subresources/scans/methods/create/

using System.Diagnostics;
using System.Net.Http.Json;
using System.Text;
using System.Web;
using UrlScanner;

Console.WriteLine("Test app for the Cloudflare URL Scanner API.");

var accountId = "[ENTER YOUR ACCOUNT ID HERE]";
var email = "[ENTER YOUR EMAIL HERE]";
var authKey = Environment.GetEnvironmentVariable("Dev_Cloudflare_UrlScanner_Authkey");

var hostUrl = "johnnycode.com";
var fullHostUrl = "https://johnnycode.com";

var scandId = "";

using var httpClient = new HttpClient();

// Check auth
{
    var stopWatch = new Stopwatch();
    stopWatch.Start();
    var url = $"https://api.cloudflare.com/client/v4/user/tokens/verify";
    var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);

    httpRequestMessage.Headers.Add("Authorization", $"Bearer {authKey}");

    var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

    Console.WriteLine($"Finished in {stopWatch.ElapsedMilliseconds}ms.");
    Console.WriteLine($"Status: {httpResponseMessage.StatusCode}");
    var textResponse = await httpResponseMessage.Content.ReadAsStringAsync();
    Console.WriteLine("Response");
    Console.WriteLine(textResponse);
    Console.WriteLine();
}

// Search existing scans
{
    var stopWatch = new Stopwatch();
    stopWatch.Start();
    
    var url = $"https://api.cloudflare.com/client/v4/accounts/{accountId}/urlscanner/v2/search";
    var queryLimit = 10;
    
    var query = HttpUtility.ParseQueryString(string.Empty);
    query["q"] = $"page.domain:{hostUrl}*";
    // query["q"] = "page.domain:stackexchange* AND verdicts.malicious:true AND NOT page.domain:stackexchange.com";
    query["size"] = queryLimit.ToString();
    var queryString = query.ToString();
    url += $"?{queryString}";

    Console.WriteLine($"Searching existing scans...");
    Console.WriteLine($"Hitting API at: {url}");

    var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);

    httpRequestMessage.Headers.Add("Authorization", $"Bearer {authKey}");

    var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

    Console.WriteLine($"Finished in {stopWatch.ElapsedMilliseconds}ms.");
    Console.WriteLine($"Status: {httpResponseMessage.StatusCode}");
    var textResponse = await httpResponseMessage.Content.ReadAsStringAsync();
    Console.WriteLine("Response");
    Console.WriteLine(textResponse);

    var searchScansResponse = await httpResponseMessage.Content.ReadFromJsonAsync<SearchScansResponse>();
    Console.WriteLine("JSON Response Message");
    Console.WriteLine($"Results found (limit {queryLimit}): {searchScansResponse.Results.Length}");

    if (searchScansResponse.Results.Length > 0)
    {
        var firstResult = searchScansResponse.Results[0];
        
        Console.WriteLine($"First result: {firstResult.Page.Url}... is malicious? {firstResult.Verdicts.Malicious}");
    }

    Console.WriteLine();
}

// Create scan
if (false && string.IsNullOrWhiteSpace(scandId))
{
    var stopWatch = new Stopwatch();
    stopWatch.Start();
    var url = $"https://api.cloudflare.com/client/v4/accounts/{accountId}/urlscanner/v2/scan";
    var requestBody = @"{ ""url"": """+ fullHostUrl + @""" }";

    Console.WriteLine($"Creating a new scan...");
    Console.WriteLine($"Hitting API at: {url}");

    var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url);

    // httpRequestMessage.Headers.Add("X-Auth-Email", email);
    // httpRequestMessage.Headers.Add("X-Auth-Key", authKey);
    // httpRequestMessage.Headers.Add("Content-Type", "application/json");
    httpRequestMessage.Headers.Add("Authorization", $"Bearer {authKey}");

    httpRequestMessage.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");

    var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

    Console.WriteLine($"Finished in {stopWatch.ElapsedMilliseconds}ms.");
    Console.WriteLine($"Status: {httpResponseMessage.StatusCode}");
    var textResponse = await httpResponseMessage.Content.ReadAsStringAsync();
    Console.WriteLine("Text Response");
    Console.WriteLine(textResponse);

    var createScanResponse = await httpResponseMessage.Content.ReadFromJsonAsync<CreateScanResponse>();
    Console.WriteLine("JSON Response Message");
    Console.WriteLine(createScanResponse.Message);

    // {"uuid":"c4c7da24-a368-4e43-a9ff-5c00c5d2d00f","api":"https://api.cloudflare.com/client/v4/accounts/bb6812d2f161c94a7ec51b23f428bd09/urlscanner/v2/result/c4c7da24-a368-4e43-a9ff-5c00c5d2d00f","visibility":"public","url":"https://johnnycode.com","message":"Submission successful"}

    scandId = createScanResponse.Uuid;
    
    Console.WriteLine();
}

// Get scan
if (!string.IsNullOrWhiteSpace(scandId))
{
    var stopWatch = new Stopwatch();
    stopWatch.Start();
    var url = $"https://api.cloudflare.com/client/v4/accounts/{accountId}/urlscanner/v2/result/{scandId}";

    Console.WriteLine($"Getting an existing scan...");
    Console.WriteLine($"Hitting API at: {url}");

    var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url);

    httpRequestMessage.Headers.Add("Authorization", $"Bearer {authKey}");

    var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

    Console.WriteLine($"Finished in {stopWatch.ElapsedMilliseconds}ms.");
    Console.WriteLine($"Status: {httpResponseMessage.StatusCode}");

    if (!httpResponseMessage.IsSuccessStatusCode)
    {
        Console.WriteLine("Failure status, aborting.");
        Console.WriteLine("Press any key to quit.");
        
        Console.ReadKey();
        
        return;
    }
    
    var textResponse = await httpResponseMessage.Content.ReadAsStringAsync();
    Console.WriteLine("Text Response");
    Console.WriteLine(textResponse);
    var getScanResponse = await httpResponseMessage.Content.ReadFromJsonAsync<GetScanResponse>();
    Console.WriteLine("JSON Response Message");
    Console.WriteLine($"Malicious? {getScanResponse.Verdicts.Overall}");

    Console.WriteLine();
}

Console.WriteLine("All done.");

Console.ReadKey();