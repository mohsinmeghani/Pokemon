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
            var p = GetPokemons().Where(x => x.Id == Id);
            return p.FirstOrDefault();
        }
        private List<Pokemonia> GetPokemons()
        {
            var db = new Root();

            var pokemons = db.GetPokemons();
            var list = new List<Pokemonia>();            
            foreach (var p in pokemons.results)
            {
                var mypokemon = new Pokemonia();
                var name = p.name;
                var pokemon_db  = db.GetPokemon(name);

                // setting values in to new Middle Layer
                mypokemon.Id = pokemon_db.Id;
                mypokemon.Name = pokemon_db.Name;
                mypokemon.Url = "http://localhost:5186/api/pokemon/get/" + pokemon_db.Id;
                mypokemon.Weight = pokemon_db.Weight;
                mypokemon.Height = pokemon_db.Height;
                mypokemon.base_experience = pokemon_db.Base_Experience;
                mypokemon.Types = new List<Middle.Type>();

                //adding types

                foreach (var t in pokemon_db.Types)
                {
        
                    var myType = new Pokemon.Middle.Type();
                    myType.Name = t.type.name;
                    mypokemon.Types.Add(myType);
                }
                

                list.Add(mypokemon);
                

            }
            return list;
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
            //var list = GetPokemons().results;
            var list = GetPokemons();
            return list;
        }

        
    }
}
