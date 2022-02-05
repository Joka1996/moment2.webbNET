
namespace moment2.Models{
    public class MovieList
    {
        //tom konstruktor
        public MovieList() {}

        //konstruktor för att fylla ett objekt
        public MovieList(int grade, string title)
        {
            this.Grade = grade;
            this.Title = title; 
         
        }

        public int? Grade { get; set; }
        public string? Title { get; set; }

      
    }

    public class ViewModeln
    {
        public IEnumerable<MovieList>? FilmList { get; set; }
    }
}