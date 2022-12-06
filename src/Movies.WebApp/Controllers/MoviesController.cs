using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movies.WebApp.ApiServices;
using Movies.WebApp.Models;

namespace Movies.WebApp.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IMovieAPIService _movieAPIService;

        public MoviesController(IMovieAPIService movieAPIService)
        {
            _movieAPIService = movieAPIService;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _movieAPIService.GetMovies();
            return View(movies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieAPIService.GetMovie(id);
            return View(movie);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Movie movie)
        {
            await _movieAPIService.CreateMovie(movie);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _movieAPIService.GetMovie(id);
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Movie movie)
        {
            movie.Id = id;
            await _movieAPIService.UpdateMovie(movie);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _movieAPIService.GetMovie(id);
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _movieAPIService.DeleteMovie(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
