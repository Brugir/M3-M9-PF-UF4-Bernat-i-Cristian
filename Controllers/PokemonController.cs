using Microsoft.AspNetCore.Mvc;
using PokeDexWeb.Models;
using PokeDexWeb.Services;
using System.Linq;
using System.Threading.Tasks;

namespace PokeDexWeb.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokemonService _pokemonService;

        public PokemonController(PokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        // Acció per mostrar la vista de cerca
        public IActionResult Search()
        {
            return View();
        }

        // Acció per gestionar la cerca de Pokémon
        [HttpPost]
        public async Task<IActionResult> Search(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                ViewBag.Error = "Si us plau, introdueix un nom de Pokémon.";
                return View();
            }

            var pokemon = await _pokemonService.GetPokemonByName(name);
            if (pokemon == null)
            {
                ViewBag.Error = "No s'ha trobat el Pokémon.";
                return View();
            }
            var forms = new List<PokemonApiModel> { pokemon };
            return View(forms);
        }
        // Acció per mostrar la vista de cerca per tipus
        public IActionResult SearchByType()
        {
            return View();
        }

        // Acció per mostrar la vista de cerca per regió
        public IActionResult SearchByRegion()
        {
            return View();
        }

        // Acció per gestionar la cerca de pokémons per tipus
        [HttpPost]
        public async Task<IActionResult> SearchByType(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                ViewBag.Error = "Introdueix un tipus de Pokémon.";
                return View();
            }
            var pokemons = await _pokemonService.GetPokemonsByType(type);
            if (pokemons == null || pokemons.Count == 0)
            {
                ViewBag.Error = "No s'han trobat pokémons d'aquest tipus.";
                return View();
            }
            return View("ListByType", pokemons); // Mostra una vista amb la llista de pokémons
        }

        // Acció per gestionar la cerca de pokémons per regió
        [HttpPost]
        public async Task<IActionResult> SearchByRegion(string region)
        {
            if (string.IsNullOrEmpty(region))
            {
                ViewBag.Error = "Introdueix una regió.";
                return View();
            }
            var pokemons = await _pokemonService.GetPokemonsByRegion(region);
            if (pokemons == null || pokemons.Count == 0)
            {
                ViewBag.Error = "No s'han trobat pokémons d'aquesta regió.";
                return View();
            }
            return View("ListByRegion", pokemons); // Mostra una vista amb la llista de pokémons per regió
        }
        // Afegir un Pokémon als favorits
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFavorite(string name, string imageUrl)
        {
            System.Diagnostics.Debug.WriteLine($"[AddFavorite] name={name}, imageUrl={imageUrl}");
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(imageUrl))
            {
                return Json(new { success = false, message = "Falten dades." });
            }
            using (var db = HttpContext.RequestServices.GetService(typeof(PokeDexWeb.Data.AppDbContext)) as PokeDexWeb.Data.AppDbContext)
            {
                // Evitar duplicats
                if (!db.PokemonFavorites.Any(f => f.Name == name))
                {
                    db.PokemonFavorites.Add(new PokemonFavorite { Name = name, ImageUrl = imageUrl });
                    await db.SaveChangesAsync();
                    return Json(new { success = true, message = "Afegit correctament!" });
                }
                else
                {
                    return Json(new { success = false, message = "Ja està als favorits." });
                }
            }
        }

        // Eliminar un favorit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveFavorite(int id)
        {
            using (var db = HttpContext.RequestServices.GetService(typeof(PokeDexWeb.Data.AppDbContext)) as PokeDexWeb.Data.AppDbContext)
            {
                var fav = db.PokemonFavorites.FirstOrDefault(f => f.Id == id);
                if (fav != null)
                {
                    db.PokemonFavorites.Remove(fav);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Favorites");
        }

        // Detall d'un Pokémon (per modal)
        public async Task<IActionResult> Details(string name)
        {
            if (string.IsNullOrEmpty(name)) return Content("No s'ha especificat cap nom.");
            var pokeService = HttpContext.RequestServices.GetService(typeof(PokeDexWeb.Services.PokemonService)) as PokeDexWeb.Services.PokemonService;
            var poke = await pokeService.GetPokemonByName(name);
            if (poke == null) return Content("No s'ha trobat el Pokémon.");
            return PartialView("_PokemonDetailsPartial", poke);
        }

        // Mostrar la llista de favorits
        public IActionResult Favorites()
        {
            using (var db = HttpContext.RequestServices.GetService(typeof(PokeDexWeb.Data.AppDbContext)) as PokeDexWeb.Data.AppDbContext)
            {
                var favs = db.PokemonFavorites.ToList();
                return View(favs);
            }
        }
    }
}
