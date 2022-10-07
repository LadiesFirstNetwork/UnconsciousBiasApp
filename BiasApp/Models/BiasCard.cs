namespace BiasApp.Models
{
    public class BiasCard
    {
        public string Name { get; set; }        // FrontView + BackView
        public string Definition { get; set; }  // FrontView
        public string Example { get; set; }     // BackView
        public string Image { get; set; }       // FrontView + BackView
    }
}