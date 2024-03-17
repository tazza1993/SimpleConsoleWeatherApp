using System.Text.Json;
using RandomCSharp;

await RunApplication();
Console.ReadLine();
return;

static async Task RunApplication()
{
    const string apiKey = "D6G3CUP4ZBKDL69EPZ9XHAV6T";

    while (true)
    {
        Console.Clear();
        DisplayMenu();
        var location = GetLocation();
        var response = await GetResponseAsync($"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{location}?unitGroup=uk&key={apiKey}&contentType=json");
        
        var weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(response);
        if (weatherForecast != null) DisplayResults(weatherForecast);
        Console.ReadLine();
    }
}

static void DisplayMenu()
{
    Console.WriteLine("1. Lincoln");
    Console.WriteLine("2. Metheringham");
    Console.WriteLine("3. Quit");
    Console.WriteLine();
}

static void DisplayResults(WeatherForecast weatherForecast)
{
    Console.Clear();
    Console.WriteLine($"Location: {weatherForecast?.Location}");
    Console.WriteLine($"Timezone: {weatherForecast?.Timezone}");
    Console.WriteLine($"Summary: {weatherForecast?.Summary}");
    Console.WriteLine($"Temperature: {weatherForecast?.CurrentConditions?.Temperature}°c");
    Console.WriteLine($"Cloud data: {weatherForecast?.CurrentConditions?.CloudDensity} and {weatherForecast?.CurrentConditions?.CloudCoverage}");
    Console.WriteLine($"Sunrise time: {weatherForecast?.CurrentConditions?.Sunrise}");
    Console.WriteLine($"Sunset time: {weatherForecast?.CurrentConditions?.Sunset}");
    Console.WriteLine();
    Console.Write("Hit enter when ready to return to the menu. ");
}

static string GetLocation()
{
    var location = "";
    var input = CaptureIntInput("Enter Menu Choice: ");

    if (input == 1)
    {
        location = "Lincoln%2C%20GB";
    }

    return location;
}

static int CaptureIntInput(string message)
{
    while (true)
    {
        Console.Write(message);
        var input = Console.ReadLine();

        if (int.TryParse(input, out var output))
            return output;
        
        Console.WriteLine("Invalid input. Try again.");
    }
}

static async Task<string> GetResponseAsync(string requestUrl)
{
    try
    {
        using var client = new HttpClient();
        var response = await client.GetAsync(requestUrl);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        return $"Error: {response.StatusCode}";
    }
    catch (Exception ex)
    {
        return $"Exception: {ex.Message}";
    }
}