using NUnit.Framework;
using RestSharp;
using LibraryManagerTests.Models;
using LibraryManagerTests.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LibraryManagerTests.Tests
{
    [TestFixture]
    public class LibraryManagerApiTests
    {
        private ApiClient _api;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            ServiceManager.StartService();
            _api = new ApiClient();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ServiceManager.StopService();
        }

        [Test]
        public void GetAllBooks_ShouldReturnBooks()
        {
            var request = new RestRequest("/books", Method.Get);
            var response = _api.Client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            var books = JsonConvert.DeserializeObject<List<Book>>(response.Content);
            Assert.That(books, Is.Not.Null);
        }
    }
}