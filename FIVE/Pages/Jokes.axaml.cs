using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FIVE.Data;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FIVE;

public partial class Jokes : UserControl
{
    private readonly HttpClient _httpClient;
    public Jokes()
    {
        InitializeComponent();

        _httpClient = new HttpClient();


    }
    private async Task<Joke> GetRandomJoke()
    {
        string url = "https://official-joke-api.appspot.com/random_joke";
        var response = await _httpClient.GetStringAsync(url);
        return JsonSerializer.Deserialize<Joke>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }



    private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        try
        {
            var joke = await GetRandomJoke();

            hfhsja.Text = $"{joke.Setup}\n{joke.Punchline}";
        }
        catch 
        {
            hfhsja.Text = $"Œ¯Ë·Í‡: ’«  ¿ ¿ﬂ";
        }
    }
    
}