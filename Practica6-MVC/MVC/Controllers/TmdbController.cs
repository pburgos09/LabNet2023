using MVC.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class TmdbController : Controller
    {
        // GET: Tmdb
        public async Task<ActionResult> Index()
        {
            List<TmdbViewModel> tmdbViewModels = await GetAllMovies();
            return View(tmdbViewModels);
        }

        public async Task<List<TmdbViewModel>> GetAllMovies()
        {
            HttpClient client = new HttpClient();

            List<TmdbViewModel> tmdbViewModels = null;

            HttpResponseMessage response = await client.GetAsync("https://api.themoviedb.org/3/movie/popular?api_key=1f54bd990f1cdfb230adb312546d765d&language=en-US&page=1");

            if (response.IsSuccessStatusCode)
            {
               string result = await response.Content.ReadAsStringAsync();
                tmdbViewModels = JsonConvert.DeserializeObject<List<TmdbViewModel>>(result);
            }

            return tmdbViewModels;
        }
    }
}