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
    }
}
