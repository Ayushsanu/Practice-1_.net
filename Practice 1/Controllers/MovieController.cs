using Microsoft.AspNetCore.Mvc;
using Practice_1.Models;

namespace Practice_1.Controllers

{
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        List<Movie> movies = new List<Movie>
                {
                    new Movie() { Id = 1, Title = "RRR", budget = 400, Description = "Action movie", Director = "S S Rajamouli" },
                    new Movie() { Id = 2, Title = "Inception", budget = 160, Description = "Sci-Fi thriller", Director = "Christopher Nolan" },
                    new Movie() { Id = 3, Title = "The Shawshank Redemption", budget = 25, Description = "Drama", Director = "Frank Darabont" }
                    // Add more movies as needed
                };

        // GET: MovieController
        [Route("Index")]
        public ActionResult Index()
        {
            List<Movie> movies = new List<Movie>
                {
                    new Movie() { Id = 1, Title = "RRR", budget = 400, Description = "Action movie", Director = "S S Rajamouli" },
                    new Movie() { Id = 2, Title = "Inception", budget = 160, Description = "Sci-Fi thriller", Director = "Christopher Nolan" },
                    new Movie() { Id = 3, Title = "The Shawshank Redemption", budget = 25, Description = "Drama", Director = "Frank Darabont" }
                    // Add more movies as needed
                };

            return View(movies);
        }

        // GET: MovieController/Details/5
        [HttpGet]
        [Route("details/{ID}")]
        public ActionResult Details(String ID)
        {
            List<Movie> movies = new List<Movie>
                {
                    new Movie() { Id = 1, Title = "RRR", budget = 400, Description = "Action movie", Director = "S S Rajamouli" },
                    new Movie() { Id = 2, Title = "Inception", budget = 160, Description = "Sci-Fi thriller", Director = "Christopher Nolan" },
                    new Movie() { Id = 3, Title = "The Shawshank Redemption", budget = 25, Description = "Drama", Director = "Frank Darabont" },
                    new Movie() { Id = 4, Title = "RRR", budget = 400, Description = "Action movie", Director = "S S Rajamouli" }
                    // Add more movies as needed
                };
            var result=movies.Where(x=>x.Title == ID).ToList();
            return View("Index",result);
        }

        // GET: MovieController/Create
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieController/Create
        [HttpPost]
        [Route("Create")]
        
        public ActionResult Create(Movie obj)
        {
            if (ModelState.IsValid)
            {
                movies.Add(obj);

            }
            
           
            return View("Index",movies);
            
        }

        // GET: MovieController/Edit/5
        [HttpGet]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            Movie movie=movies.First(x=>x.Id == id);
            return View(movie);
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            Movie oldmovie=movies.First(x => x.Id ==movie.Id);
            oldmovie.Title = movie.Title;
            oldmovie.Director = movie.Director;
            oldmovie.Description = movie.Description;
            oldmovie.budget = movie.budget;
            return View("Index", movies);
        }

        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
