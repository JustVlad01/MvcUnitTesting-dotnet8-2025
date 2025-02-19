using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcUnitTesting_dotnet8.Controllers;
using MvcUnitTesting_dotnet8.Models;
using Telerik.JustMock;
using Tracker.WebAPIClient;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock.Helpers;

namespace MvcUnitTesting.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index_Returns_All_books_In_DB()
        {
            var bookRepository = Mock.Create<IRepository<Book>>();
            Mock.Arrange(() => bookRepository.GetAll())
                .Returns(new List<Book>()
                {
                    new Book { Genre = "Fiction", ID = 1, Name = "Moby Dick", Price = 12.50m },
                    new Book { Genre = "Fiction", ID = 2, Name = "War and Peace", Price = 17m },
                    new Book { Genre = "Science Fiction", ID = 1, Name = "Escape from the vortex", Price = 12.50m },
                    new Book { Genre = "History", ID = 2, Name = "The Battle of the Somme", Price = 22m },
                }).MustBeCalled();

            HomeController controller = new HomeController(bookRepository, null);
            ViewResult viewResult = controller.Index("Fiction") as ViewResult;
            var model = viewResult.Model as IEnumerable<Book>;

            Assert.AreEqual(2, model.Count());
        }

        [TestMethod]
        public void show_ViewData_genre_test()
        {
            var mockRepo = Mock.Create<IRepository<Book>>();
            mockRepo.Arrange(repo => repo.GetAll())
                .Returns(new List<Book>()
                {
                    new Book { Genre = "Fiction", ID = 1, Name = "Moby Dick", Price = 12.50m }
                }).MustBeCalled();

            var controller = new HomeController(mockRepo, null);

            var result = controller.Index("Science Fiction") as ViewResult;
            var genre = result?.ViewData["Genre"];

            Assert.AreEqual("Science Fiction", genre);
        }

        [TestMethod]
        public void Privacy()
        {
            var bookRepository = Mock.Create<IRepository<Book>>();
            HomeController controller = new HomeController(bookRepository, null);

            ViewResult result = controller.Privacy() as ViewResult;

            Assert.AreEqual("Your Privacy is our concern", result.ViewData["Message"]);
        }

        [TestMethod]
        public void Constructor_Tracks_Activity()
        {
            var bookRepository = Mock.Create<IRepository<Book>>();
            var logger = Mock.Create<ILogger<HomeController>>();
            var controller = new HomeController(bookRepository, logger);

            ActivityAPIClient.Track(StudentID: "S00233992", StudentName: "vlad khokha", activityName: "Rad302 2025 Week 2 Lab 1", Task: "Running initial tests");
        }

        [TestMethod]
        public void test_book_by_genre()
        {
            var mockRepo = Mock.Create<IRepository<Book>>();
            mockRepo.Arrange(repo => repo.GetAll())
                .Returns(new List<Book>()
                {
                    new Book { Genre = "Fiction", ID = 1, Name = "Moby Dick", Price = 12.50m },
                    new Book { Genre = "Fiction", ID = 2, Name = "War and Peace", Price = 17m },
                    new Book { Genre = "Science Fiction", ID = 1, Name = "Escape from the vortex", Price = 12.50m },
                    new Book { Genre = "History", ID = 2, Name = "The Battle of the Somme", Price = 22m }
                }).MustBeCalled();

            HomeController controller = new HomeController(mockRepo, null);
            ViewResult viewResult = controller.Index("Science Fiction") as ViewResult;
            var model = viewResult.Model as IEnumerable<Book>;

            Assert.AreEqual(1, model.Count());
        }
    }
}
