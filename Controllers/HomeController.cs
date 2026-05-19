using Laba4.Data;
using Microsoft.AspNetCore.Mvc;
using Laba4.Models;

namespace Laba4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NoteContext _context;

        // Був дублікат конструктора — залишаємо один
        public HomeController(NoteContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Index був property замість методу — виправлено на [HttpGet]
        [HttpGet]
        public IActionResult Index()
        {
            var notes = _context.Notes.ToList();
            ViewBag.Notes = notes;
            return View(notes);
        }

        [HttpPost]
        public IActionResult Index(string author, string text)
        {
            // author і text тепер параметри методу, а не невідомі змінні
            Note note = new Note
            {
                Author = author,
                Text = text,
                CreatedDate = DateTime.Now
            };

            _context.Notes.Add(note);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}