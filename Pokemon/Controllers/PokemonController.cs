using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
 

namespace Pokemon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        const string baseurl = @"https://pokeapi.co/api/v2/";

        private HttpResponseMessage GetCall(string callname)
        {
            var client = new HttpClient();
            client.BaseAddress = new System.Uri(baseurl);
            var responseTask = client.GetAsync(callname);
            responseTask.Wait();
            var result = responseTask.Result;
            return result;
        }


        private Root GetPokemons()
        {   
            var result = GetCall("pokemon");
            if (result.IsSuccessStatusCode)
            {
               var readTask = result.Content.ReadAsAsync<Root>();
               readTask.Wait();

                var pokemons = readTask.Result;
                return pokemons;
            }
            return null;
        }


        private Pokemon GetPokemon(int Id)
        {
            var result = GetCall("pokemon/" + Id);
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Pokemon>();
                readTask.Wait();

                var pokemons = readTask.Result;
                return pokemons;
            }
            return null;
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult Get(int Id)
        {
            var p = GetPokemon(Id);
            return Ok(p);
        }

        [HttpGet]
        public IEnumerable<Object> Index()
        {
            var list = GetPokemons().results;
            return list;
        }

        
    }
}
