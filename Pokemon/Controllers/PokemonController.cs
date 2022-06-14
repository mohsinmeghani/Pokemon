using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokemon.DB;
using System.Net.Http;
using Pokemon.Middle;


namespace Pokemon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        

        private Pokemonia GetPokemon(int Id)
        {
            var db = new Root();
            var myPokemon = new Pokemonia(Id);
            return myPokemon;
        }



        private IEnumerable<Object> GetPokemons()
        {
            var db = new Root();

            var pokemons = db.GetPokemons();
            var list = new List<Pokemonia>();            
            foreach (var p in pokemons.results)
            {
                var mypokemon = new Pokemonia();
                var name = p.name;
                var id = Util.GetIdfromUrl(p.url);
                // setting values in to new Middle Layer
                mypokemon.Id = id;
                mypokemon.Name = name;
                mypokemon.Url = "http://localhost:5186/api/pokemon/get/" + id; //pokemon_db.Id;

                list.Add(mypokemon);
            }
            return list.Select(x=> new {x.Id,x.Name,x.Url}).ToList();
        }

       

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult Get(int Id)
        {
            var p = GetPokemon(Id);
            return Ok(p);
        }

        [HttpGet]
        [Route("Getdb")]
        public IEnumerable<Object> GetDbData()
        {
            var db = new Root();
            var list =db.GetPokemons();
            return list.results;
        }

        [HttpGet]
        [Route("Getdb/{id}")]
        public IActionResult GetDbP(int id)
        {
            var db = new Root();
            var data = db.GetPokemon(id);
            return Ok(data);
        }

        [HttpGet]
        public IEnumerable<Object> Index()
        {
            
                var list = GetPokemons();
                return list;          
            //var list = GetPokemons().results;
           
        }

        
    }
}
