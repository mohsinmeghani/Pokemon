namespace Pokemon.DB
{
    public class Sprites
    {
        public string back_default { get; set; }
        public object back_female { get; set; }
        public string back_shiny { get; set; }
        public object back_shiny_female { get; set; }
        public string front_default { get; set; }
        public object front_female { get; set; }
        public string front_shiny { get; set; }
        public object front_shiny_female { get; set; }
        public Other other { get; set; }
       
    }
    public class Other
    {
        
        public Home home { get; set; }

    }

    public class Home
    {
        public string front_default { get; set; }
      
    }


}
