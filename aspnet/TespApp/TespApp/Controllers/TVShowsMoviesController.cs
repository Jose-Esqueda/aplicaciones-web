using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TespApp.Models;

namespace TespApp.Controllers
{
    public class TVShowsMoviesController : Controller
    {
        public IActionResult Index()
        {
            List<TVShowsMoviesIndexViewModel> TvShowsList = new List<TVShowsMoviesIndexViewModel>();
            var show = new TVShowsMoviesIndexViewModel()
            {
                AnnoSalida = 1974,
                genero = "Terror",
                Nombre = "Masacre en texas",
                Tipo = "R"
            };
            TvShowsList.Add(show);
            show = new TVShowsMoviesIndexViewModel()
            {
                AnnoSalida = 2000,
                genero = "Terror",
                Nombre = "El Aro",
                Tipo = "R"
            };
            TvShowsList.Add(show);
            show = new TVShowsMoviesIndexViewModel()
            {
                AnnoSalida = 2005,
                genero = "Aventura",
                Nombre = "El señor de los anillos",
                Tipo = "8+"
            };
            TvShowsList.Add(show);
            show = new TVShowsMoviesIndexViewModel()
            {
                AnnoSalida = 2005,
                genero = "Ciencia ficcion",
                Nombre = "Viaje al espacio",
                Tipo = "8+"
            };
            TvShowsList.Add(show);

            return View(TvShowsList);
        }
    }
}
