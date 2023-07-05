using PokemonAPI.Model;
using RestSharp;
using System.Text.Json;

namespace PokemonAPI.Service
{
    internal class MascoteService
    {
        public static async Task<Mascote> BuscarMascote(string mascote)
        {
            var client = new RestClient("https://pokeapi.co/api/v2/");
            var request = new RestRequest($"pokemon/{mascote}", Method.Get);
            var response = await client.ExecuteAsync(request);

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            return JsonSerializer.Deserialize<Mascote>(response.Content, options);
        }
    }
}
