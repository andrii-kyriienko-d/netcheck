namespace netcheck.Constants;

internal static class InformationMessages
{
    public const string InvalidUrl = "URL parsing error.";
    public const string NoArguments = "There are no arguments.";
    public const string InvalidCount = "Count argument has invalid value. It should be more than 0.";

    public static string CheckingMessage(string url, int code)
    {
        var resultMessage = code == 200 ? $"OK({code})" : $"ERR({code})";
        return $"Checking '{url}'. Result: {resultMessage}";
    }
}