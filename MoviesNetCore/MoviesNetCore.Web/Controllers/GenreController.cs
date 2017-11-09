using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MoviesNetCore.Model;
using MoviesNetCore.Repository;
using MoviesNetCore.Web.Models;

namespace MoviesNetCore.Web.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreRepository genreRepository;
        public GenreController(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        public IActionResult Index()
        {
            var genres = this.genreRepository.List();

            var viewModelList = new List<GenreViewModel>();

            foreach (var genre in genres)
            {
                var viewModel = new GenreViewModel();

                viewModel.Id = genre.Id;
                viewModel.Nombre = genre.Name;

                viewModelList.Add(viewModel);

            }

            return View(viewModelList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(GenreViewModel genre)
        {
            Genre newGenre = new Genre();
            newGenre.Name = genre.Nombre;
            this.genreRepository.Insert(newGenre);
            return RedirectToAction("Index", "Genre");
        }

        public IActionResult Edit(int id)
        {
            Genre genre = this.genreRepository.GetById(id);

            ViewBag.GenreName = genre.Name;

            var viewModel = new GenreViewModel();

            viewModel.Id = genre.Id;
            viewModel.Nombre = genre.Name;

            return View(viewModel);    
        }

        [HttpPost]
        public IActionResult Edit(GenreViewModel viewModel)
        {
            Genre genre = genreRepository.GetById(viewModel.Id);

            genre.Name = viewModel.Nombre;
            genreRepository.Update(genre);

            return RedirectToAction("Index", "Genre");
        }

        public IActionResult Delete(int id)
        {
            this.genreRepository.Delete(id);

            return RedirectToAction("Index", "Genre");
        }
    }
}