using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Equinox.Models;
using System.Linq;

namespace Equinox.Controllers
{
    public class GymController : Controller
    {
        
        private readonly EquinoxContext _context;
        private const string BookingSessionKey = "Bookings";
        private const string ClubFilterKey = "SelectedClub";
        private const string CategoryFilterKey = "SelectedCategory";

        public GymController(EquinoxContext context)
        {
            _context = context;
        }

       
       public IActionResult Show_Classes(string? club, string? category)
{
    club ??= HttpContext.Session.GetString(ClubFilterKey) ?? "All";
    category ??= HttpContext.Session.GetString(CategoryFilterKey) ?? "All";

    HttpContext.Session.SetString(ClubFilterKey, club);
    HttpContext.Session.SetString(CategoryFilterKey, category);

    var model = new FilterViewModel1
    {
        AllClubs = _context.Clubs.ToList(),
        AllCategories = _context.ClassCategories.ToList(),
        SelectedClubName = club,
        SelectedCategoryName = category
    };

    var query = _context.Classes
        .Include(c => c.Club)
        .Include(c => c.ClassCategory)
        .Include(c => c.User)
        .AsQueryable();

    if (club != "All")
        query = query.Where(c => c.Club.Name == club);

    if (category != "All")
        query = query.Where(c => c.ClassCategory.Name == category);

    model.AvailableClasses = query.ToList();

    var bookings = HttpContext.Session.GetObjectFromJson<List<int>>(BookingSessionKey) ?? new List<int>();
    ViewBag.CartCount = bookings.Count;

    return View(model);
}

        [HttpPost]
        public IActionResult Filter(string club, string category)
        {
            HttpContext.Session.SetString(ClubFilterKey, club);
            HttpContext.Session.SetString(CategoryFilterKey, category);
            return RedirectToAction("Show_Classes");
        }

        public IActionResult Detail(int id)
        {
            var gymClass = _context.Classes
                .Include(c => c.Club)
                .Include(c => c.ClassCategory)
                .Include(c => c.User)
                .FirstOrDefault(c => c.EquinoxClassId == id);

            if (gymClass == null)
                return NotFound();

            ViewBag.CartCount = HttpContext.Session.GetObjectFromJson<List<int>>(BookingSessionKey)?.Count ?? 0;
            return View(gymClass);
        }

        public IActionResult Class_Book(int id)
        {
            var bookings = HttpContext.Session.GetObjectFromJson<List<int>>(BookingSessionKey) ?? new List<int>();
            if (!bookings.Contains(id))
            {
                bookings.Add(id);
                HttpContext.Session.SetObjectAsJson(BookingSessionKey, bookings);
                TempData["Message"] = "Class booked successfully!";
            }
            return RedirectToAction("Show_Classes");
        }

        public IActionResult ViewBookings()
        {
            var bookings = HttpContext.Session.GetObjectFromJson<List<int>>(BookingSessionKey) ?? new List<int>();
            var bookedClasses = _context.Classes
                .Include(c => c.Club)
                .Include(c => c.ClassCategory)
                .Include(c => c.User)
                .Where(c => bookings.Contains(c.EquinoxClassId))
                .ToList();

            ViewBag.CartCount = bookings.Count;
            return View(bookedClasses);
        }
        
public IActionResult ShowDetails(int id)
        {
            var eqClass = _context.Classes
                .Include(c => c.Club)
                .Include(c => c.ClassCategory)
                .Include(c => c.User)
                .FirstOrDefault(c => c.EquinoxClassId == id);

            if (eqClass == null)
            {
                return NotFound();
            }

            return View(eqClass);
        }


        public IActionResult Cancel(int id)
        {
            var bookings = HttpContext.Session.GetObjectFromJson<List<int>>(BookingSessionKey) ?? new List<int>();
            if (bookings.Contains(id))
            {
                bookings.Remove(id);
                HttpContext.Session.SetObjectAsJson(BookingSessionKey, bookings);
                TempData["Message"] = "Booking canceled.";
            }
            return RedirectToAction("ViewBookings");
        }
    }
}
