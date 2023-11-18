using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class FavoriController : Controller
    {

        private readonly AppkicationContext context;

        // GET: CategorieController
        public FavoriController(AppkicationContext context)
        {
            this.context = context;
        }

        // Display a list of user's favorite films
        public async Task<IActionResult> Index(User user)
        {
            // Get the current user's favorites
            var Us = context.Users.SingleOrDefault(u => u.UserEmail == user.UserEmail);

            var favoriteFilms = await context.FavoriteFilms
                .Include(ff => ff.Film)
                .Where(ff => ff.UserID == Us.UserID)
                .ToListAsync();

            return View(favoriteFilms);
        }


        // GET: CategorieController/Delete/5
        public ActionResult AddToFavorites(int id)
        {
            Film film = context.Films.Find(id);
            return View(film);
        }

        // Add a film to favorites
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToFavorites(int id, Film film)
        {
            var user = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            // Check if the film is already in favorites
            //var existingFavorite = await context.FavoriteFilms
            //    .Where(ff => ff.FilmId == id && ff.UserID == user)
            //    .FirstOrDefaultAsync();

            //if (existingFavorite == null)
            //{
                // Add the film to favorites
                var favoriteFilm = new FavoriteFilm
                {
                    FilmId = id,
                    UserID = 1

                };

                context.FavoriteFilms.Add(favoriteFilm);
                await context.SaveChangesAsync();
            

            // Redirect back to the index or details page, or any other desired page
            return RedirectToAction("Index");
        }

        // Remove a film from favorites
        public async Task<IActionResult> RemoveFromFavorites(int id)
        {
            var favoriteFilm = await context.FavoriteFilms.FindAsync(id);

            if (favoriteFilm != null)
            {
                context.FavoriteFilms.Remove(favoriteFilm);
                await context.SaveChangesAsync();
            }

            // Redirect to the favorites page or any other desired page
            return RedirectToAction("Index");
        }
    }
}
