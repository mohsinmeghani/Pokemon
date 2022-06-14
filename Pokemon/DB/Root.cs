using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace Pokemon.DB
{
    public class Result
    {
        public string name { get; set; }
        public string url { get; set; }

    }

    public class Root
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<Result> results { get; set; }

        const string baseurl = @"https://pokeapi.co/api/v2/";


        //Generic Function for API Calling and Returning Response Messsage
        private HttpResponseMessage GetCall(string callname)
        {
            var client = new HttpClient();
            client.BaseAddress = new System.Uri(baseurl);
            var responseTask = client.GetAsync(callname);
            responseTask.Wait();
            var result = responseTask.Result;
            return result;

        }

        public Type GetType(string name)
        {
            var result = GetCall("type/"+name);
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Type>();
                readTask.Wait();

                var pokemons = readTask.Result;

                return pokemons;
            }
            return null;
        }
        public Root GetPokemons()
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

        // get Pokemon by Name 
        public Pokemon_DB GetPokemon(string name)
        {
            var result = GetCall("pokemon/" + name);
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Pokemon_DB>();
                readTask.Wait();

                var pokemons = readTask.Result;
                return pokemons;
            }
            return null;
        }

        //Getting Pokemon by ID
        public Pokemon_DB GetPokemon(int Id)
        {
            var result = GetCall("pokemon/" + Id);
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Pokemon_DB>();
                readTask.Wait();

                var pokemons = readTask.Result;
                return pokemons;
            }
            return null;
        }



    }
}
