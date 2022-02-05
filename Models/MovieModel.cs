using System.ComponentModel.DataAnnotations; // för att kunna lägga till required

namespace moment2.Models{
    public class MovieModel{

        // först properties
        //sedan validation
        [Display(Name ="Filmens titel:")]
        [Required(ErrorMessage ="En titel måste fyllas i..")]
        public string? Title { get; set; }


        [Display(Name ="Filmens datum den släpps:")]
        [Required(ErrorMessage ="Ett datum måste fyllas i..")]
        public string? Realese { get; set; }


        [Display(Name ="En tanke om filmen:")]
        [Required(ErrorMessage ="En tanke måste fyllas i..")]
        public string? Thoughts { get; set; }


        [Display(Name ="URL till FilmStaden:")]
        [Required(ErrorMessage ="En URL måste fyllas i..")]
        public string? Url {get; set;}

        [Display(Name ="Förutspå Betyg 1-10: ")]
        [Required(ErrorMessage ="Ett betyg måste fyllas i..")]
        public int? Prediction {get; set;}
    }
}