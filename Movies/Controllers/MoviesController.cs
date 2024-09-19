using Microsoft.AspNetCore.Mvc;
using Movies.Entities;

namespace Movies.Controllers
{
    public class MoviesController : Controller
    {

        private MovieDbContext _movieDbContext;

        public MoviesController(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public IActionResult List()
        {
            List<Movie> movies = _movieDbContext.Movies.ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Movie());
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieDbContext.Movies.Add(movie);
                _movieDbContext.SaveChanges();
                return RedirectToAction("List");
            }
            return View(movie);
        }


        public IActionResult Delete(int? id)
        {
            var DeleteObj = _movieDbContext.Movies.Find(id);
            if (DeleteObj == null)
            {
                return RedirectToAction("List");
            }
            _movieDbContext.Movies.Remove(DeleteObj);
            _movieDbContext.SaveChanges(true);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var DetailsObj = _movieDbContext.Movies.Find(id);

            if (DetailsObj == null)
            {
                return RedirectToAction("List");
            }
            return View(DetailsObj);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var EditObj = _movieDbContext.Movies.Find(id);

            if (EditObj == null)
            {
                return RedirectToAction("List");
            }

            return View(EditObj);

        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                var EditObj = _movieDbContext.Movies.Find(movie.MovieId);

                if (EditObj == null)
                {
                    return RedirectToAction("List");
                }

                EditObj.Name = movie.Name;
                EditObj.Rating = movie.Rating;
                EditObj.Year = movie.Year;

                _movieDbContext.SaveChanges();
                return View(EditObj);
            }
            return View(movie);

        }
    }
}
