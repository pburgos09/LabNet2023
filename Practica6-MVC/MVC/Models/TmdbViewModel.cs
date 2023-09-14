namespace MVC.Models
{
    public class TmdbViewModel
    {
        public int id { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public string release_date { get; set; }
        public string popularity { get; set; }
        public string vote_average { get; set; }
    }
}