using netcheck.Constants;
using netcheck.Helpers;

namespace netcheck.Managers;

internal sealed class HealthCheckManager
{
    private readonly HttpClient _httpClient = new();
    
    public void RunHealthChecks()
    {
        try
        {
            if (Environment.GetCommandLineArgs().Length == 0)
            {
                throw new Exception(InformationMessages.NoArguments);
            }

            var count = HealthCheckHelper.GetHealthCheckCount();
            var url = HealthCheckHelper.GetHttpUrl();
            
            for (int i = 0; i < count; i++)
            {
                var statusCode = ExecuteGetPing(url);
                Console.WriteLine(InformationMessages.CheckingMessage(url, statusCode));
                Thread.Sleep(1000);
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private int ExecuteGetPing(string url)
    {
        var response = _httpClient.GetAsync(url).Result;
        return (int)response.StatusCode;
    }
}