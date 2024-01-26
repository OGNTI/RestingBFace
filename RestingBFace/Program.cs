using System.Text.Json;
using RestSharp;
using System.IO;

RestClient client = new("https://swapi.py4e.com/api/");

while (true)
{
    Console.WriteLine("Write a number");
    string input = Console.ReadLine().ToLower().Trim();
    RestRequest request = new($"people/{input}/");

    RestResponse response = client.GetAsync(request).Result;

    if(response.StatusCode == System.Net.HttpStatusCode.OK)
    {
        Character c = JsonSerializer.Deserialize<Character>(response.Content);

        Console.WriteLine($"Name: {c.name}");
        Console.WriteLine($"Height: {c.height}");
        Console.WriteLine($"Mass: {c.mass}");
        Console.WriteLine($"Hair Color: {c.hair_color}");
        Console.WriteLine($"Skin Color: {c.skin_color}");
        Console.WriteLine($"Eye Color: {c.eye_color}");
        Console.WriteLine($"Gender: {c.gender}");
    }
    else Console.WriteLine(response.StatusCode);

    // Console.WriteLine(response.Content);
    // File.WriteAllText("test.json", response.Content);

    Console.WriteLine();
}

