namespace Pokemon.DB
{
    public class Pokemon_DB
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Base_Experience { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string url { get; set; }
        public List<Type> Types { get; set; }

        public Sprites Sprites { get; set; }


    }
}
