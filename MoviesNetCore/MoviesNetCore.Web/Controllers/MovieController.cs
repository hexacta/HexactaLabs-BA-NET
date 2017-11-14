using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesNetCore.Model;
using MoviesNetCore.Repository;
using MoviesNetCore.Web.Models;

namespace MoviesNetCore.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository movieRepository;
        private readonly IGenreRepository genreRepository;

        public MovieController(
            IMovieRepository movieRepository,
            IGenreRepository genreRepository)
        {
            this.movieRepository = movieRepository;
            this.genreRepository = genreRepository;
        }

        public IActionResult Index()
        {
            var movies = this.movieRepository.List();
            var model = this.CreateViewModel(movies);
            return this.View(model);
        }

        public IActionResult Create()
        {
            IEnumerable<Genre> genres = this.genreRepository.List();
            
            MovieViewModel viewModel = new MovieViewModel();
            viewModel.AvailableGenres = new SelectList(genres, "Id", "Name");

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(MovieViewModel movieViewModel)
        {            
            if (ModelState.IsValid)
            {
                Movie movie = this.CreateMovieModel(movieViewModel);

                this.movieRepository.Add(movie);

                return RedirectToAction("Index", "Movie");
            }

            return View(movieViewModel);
        }

        public ActionResult Edit(string id)
        {            
            Movie movie = this.movieRepository.Get(int.Parse(id));
            IEnumerable<Genre> genres = this.genreRepository.List();         

            MovieViewModel model = this.CreateViewModel(movie);
            model.AvailableGenres = new SelectList(genres, "Id", "Name");

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var movie = this.movieRepository.Get(id);
            var model = this.CreateViewModel(movie);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(MovieViewModel model)
        {
            this.movieRepository.Delete(model.Id);
            return this.RedirectToAction("Index", "Movie");
        }
        
        [HttpPost]
        public ActionResult Edit(MovieViewModel movieViewModel)
        {
           if (ModelState.IsValid)
            {
                Movie movie = this.CreateMovieModel(movieViewModel);
                movie.Id = movieViewModel.Id;
                
                this.movieRepository.Update(movie);

                return RedirectToAction("Index", "Movie");
            }
            
            return View(movieViewModel);
        }

        private IList<MovieViewModel> CreateViewModel(IEnumerable<Movie> movies)
        {
            var moviesList = new List<MovieViewModel>();

            foreach (var item in movies)
            {
                MovieViewModel model = this.CreateViewModel(item);
                moviesList.Add(model);
            }

            return moviesList;
        }

        private MovieViewModel CreateViewModel(Movie item)
        {
            var movieViewModel = new MovieViewModel();

            movieViewModel.Id = item.Id;
            movieViewModel.Name = item.Name;
            movieViewModel.Plot = item.Plot;
            movieViewModel.ReleaseDate = item.ReleaseDate;
            movieViewModel.Runtime = item.Runtime;
            movieViewModel.CoverLink = item.CoverLink;
            movieViewModel.Genres = item.MovieGenres.Select(x => x.GenreId.ToString()).ToList();

            return movieViewModel;
        }
        
        private Movie CreateMovieModel(MovieViewModel movieViewModel)
        {
            Movie movie = new Movie();

            movie.CoverLink = movieViewModel.CoverLink;
            movie.Name = movieViewModel.Name;
            movie.Plot = movieViewModel.Plot;
            movie.ReleaseDate = movieViewModel.ReleaseDate;
            movie.Runtime = movieViewModel.Runtime;
            movie.MovieGenres = movieViewModel.Genres.Select(genreId => new MovieGenre
                {
                    GenreId = Convert.ToInt32(genreId),
                    MovieId = movieViewModel.Id
                }).ToList();

            return movie;
        }

        
    }
}