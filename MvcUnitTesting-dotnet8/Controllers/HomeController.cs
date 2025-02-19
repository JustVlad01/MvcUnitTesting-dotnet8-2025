using Microsoft.AspNetCore.Mvc;
using MvcUnitTesting_dotnet8.Models;
using System.Diagnostics;
using Tracker.WebAPIClient;

namespace MvcUnitTesting_dotnet8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRepository<Book> repository;

        public HomeController(IRepository<Book> bookRepo, ILogger<HomeController> logger)
        {
            ActivityAPIClient.Track(StudentID: "S00233992",
                StudentName: "Vlad Khokha", activityName: "Rad302 2025 Week 2 Lab 1", Task: "Running initial tests");

            repository = bookRepo;
            _logger = logger;
        }

        public IActionResult Index(string genre)
        {
            if (string.IsNullOrEmpty(genre))
            {
                genre = "All Genres";  // Default to "All Genres" if no genre is provided
            }

            var books = repository.GetAll();

            // If a genre is provided, filter the books based on genre
            if (!string.IsNullOrEmpty(genre) && genre != "All Genres")
            {
                books = books.Where(b => b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            ViewData["Genre"] = genre;  // Pass genre to the view
            return View(books);  // Return filtered list of books
        }


        public IActionResult Privacy()
        {
            ViewData["Message"] = "Your Privacy is our concern";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
