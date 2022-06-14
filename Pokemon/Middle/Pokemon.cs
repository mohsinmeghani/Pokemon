using Pokemon.DB;
namespace Pokemon.Middle
{
    public class Pokemonia
    {

        public int Id { get; set; }
        public String Name { get; set; }
        public String Url { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int base_experience { get; set; }
        public  List<Type> Types { get; set; }

        public Pokemonia()
        {

        }


        public Pokemonia(int Id)
        {
            var p = Get(Id);
            this.Name = p.Name;
            this.Id = p.Id;
            this.Weight = p.Weight;
            this.Height = p.Height;
            this.Url = p.Url;
            this.base_experience = p.base_experience;
            this.Types = p.Types;
        }

        public Pokemonia Get(int id)
        {
            var db = new Root();
            var p = db.GetPokemon(id);
            var new_p = new Pokemonia();
            new_p.Id = p.Id;
            new_p.Name = p.Name;
            new_p.Url = "http://localhost:5186/api/pokemon/get/" + p.Id;
            new_p.Weight = p.Weight;
            new_p.Height = p.Height;
            new_p.base_experience = p.Base_Experience;
            new_p.Types = new List<Middle.Type>();

            foreach (var t in p.Types)
            {

                var myType = new Pokemon.Middle.Type();
                myType.Name = t.type.name;
                myType.Id = Util.GetIdfromUrl(t.type.url);
                myType.Url = t.type.url;
                new_p.Types.Add(myType);
            }

            return new_p;

        }

    }
}
