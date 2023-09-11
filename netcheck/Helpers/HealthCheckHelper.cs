using System.Text.RegularExpressions;
using netcheck.Constants;

namespace netcheck.Helpers;

internal static class HealthCheckHelper
{
    private const string UrlRegex =
        @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";
    
    public static string GetHttpUrl()
    {
        var args = Environment.GetCommandLineArgs();

        var rawUrl = args[2];
        
        if (!Regex.IsMatch(rawUrl, UrlRegex))
        {
            throw new Exception(InformationMessages.InvalidUrl);
        }

        return rawUrl;
    }

    public static uint GetHealthCheckCount()
    {
        var args = Environment.GetCommandLineArgs();
        
        var rawCount = args[1];

        if (int.TryParse(rawCount, out var count))
        {
            if (count <= 0)
            {
                throw new Exception(InformationMessages.InvalidCount);
            }

            return (uint)count;
        }
        
        throw new Exception(InformationMessages.InvalidCount);
    }
}