using Telerik.JustMock;
using MvcUnitTesting_dotnet8.Models;
using MvcUnitTesting_dotnet8.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tracker.WebAPIClient;

namespace MvcUnitTesting.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index_Returns_All_books_In_DB()
        {
            // Arrange
            var bookRepository = Mock.Create<IRepository<Book>>();
            Mock.Arrange(() => bookRepository.GetAll())
                .Returns(new List<Book>()
                {
                    new Book { Genre = "Fiction", ID = 1, Name = "Moby Dick", Price = 12.50m },
                    new Book { Genre = "Fiction", ID = 2, Name = "War and Peace", Price = 17m },
                    new Book { Genre = "Science Fiction", ID = 1, Name = "Escape from the vortex", Price = 12.50m },
                    new Book { Genre = "History", ID = 2, Name = "The Battle of the Somme", Price = 22m },
                }).MustBeCalled();

            // Act
            HomeController controller = new HomeController(bookRepository, null);
            ViewResult viewResult = controller.Index() as ViewResult;
            var model = viewResult.Model as IEnumerable<Book>;

            // Assert
            Assert.AreEqual(4, model.Count());
        }

        [TestMethod]
        public void Privacy()
        {
            // Arrange
            var bookRepository = Mock.Create<IRepository<Book>>();
            HomeController controller = new HomeController(bookRepository, null);

            // Act
            ViewResult result = controller.Privacy() as ViewResult;

            // Assert
            Assert.AreEqual("Your Privacy is our concern", result.ViewData["Message"]);
        }

        // Test for constructor with activity tracking
        [TestMethod]
        public void Constructor_Tracks_Activity()
        {
            var bookRepository = Mock.Create<IRepository<Book>>();
            var logger = Mock.Create<ILogger<HomeController>>();
            var controller = new HomeController(bookRepository, logger);

           
            ActivityAPIClient.Track(StudentID: "S00233992",
                StudentName: "vlad khokha", activityName: "Rad302 2025 Week 2 Lab 1", Task: "Running initial tests");
        }
    }
}
