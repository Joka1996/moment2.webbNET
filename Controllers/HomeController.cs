using moment2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace moment2.Controllers {
    public class HomeController: Controller {
    //index, ska läsa ut innehållet.
    public IActionResult Index() {
        DateTime dateAndTime = DateTime.Now;
        string dateNow = dateAndTime.ToShortDateString();
        //spara med viewData som sedan kan läsas ut i vyn.
        ViewData["today"] = dateNow;
        //skicka också med sessions-variabler
        HttpContext.Session.SetString("thisDate", dateNow);

        
        //läs ut json-filen med filmer
        var JsonStr = System.IO.File.ReadAllText("movies.json");
        var JsonObj = JsonConvert.DeserializeObject<List<MovieModel>>(JsonStr);

        //skicka till vyn för utskrift
        return View(JsonObj);
    }

    public IActionResult Movies() {

        //ta emot dagens datum från Index med session.
        string? today = HttpContext.Session.GetString("thisDate");
        ViewData["today"] = today;

        return View();
    }

    //filmsida, här ska det läggas till och sparas.
    [HttpPost]
    public IActionResult Movies(MovieModel model) {
        //lägg till i movies.json, annars felmeddelande.
        if(ModelState.IsValid) {
            var JsonStr = System.IO.File.ReadAllText("movies.json");
            var JsonObj = JsonConvert.DeserializeObject<List<MovieModel>>(JsonStr);

            if(JsonObj != null){
                JsonObj.Add(model);
                ViewBag.sucess = "Film tillagd!";
            } else {
                //felmeddelande
                ViewBag.text = "Något gick fel..";
            }
            System.IO.File.WriteAllText("movies.json", JsonConvert.SerializeObject(JsonObj, Formatting.Indented));

            //töm formuläret
            ModelState.Clear();
        }

        return View();
    }
        //about
        public IActionResult About(string title) 
    {
        //ta emot dagens datum från Index med session.
        string? today = HttpContext.Session.GetString("thisDate");
        ViewData["today"] = today;

            // skriv till skärmen med viewmodel
            List<MovieList> list = new List<MovieList>
            {
                new MovieList{ Grade = 3, Title = "Dont look up" },
                new MovieList{ Grade = 2, Title = "Venom 2" },
                new MovieList{ Grade = 3, Title = "Raya the last dragon" },
                new MovieList{ Grade = 4, Title = "Dune" }
              
            };
            ViewModeln vm = new ViewModeln
            {
                FilmList = list
            }; 

            //skriv ut dagar till födelsedag med ViewData
            DateTime start =  DateTime.Now;
            DateTime end = new DateTime(2022, 11, 09);
            var difference = (end - start).Days;
            string result = difference.ToString();
            ViewData["birthDay"] = result;
            //skicka viewmodel till vyn.
            return View(vm);
    }
    //anpassa sökväg
    [HttpGet("/start/youtubeFilm")]
    public IActionResult Bait() {
        //ta emot dagens datum från Index med session.
        string? today = HttpContext.Session.GetString("thisDate");
        //yesta skicka länk till iframe
        ViewData["today"] = today;
        var link = "https://www.youtube.com/embed/tWhXRtbn_fs";
        ViewData["React to Bad & Great CGi"] = link;
        return View();
    }
}
}

