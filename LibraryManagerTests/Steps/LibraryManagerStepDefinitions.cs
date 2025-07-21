using Reqnroll;
using RestSharp;
using Newtonsoft.Json;
using LibraryManagerTests.Models;
using LibraryManagerTests.Helpers;
using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Threading;

namespace LibraryManagerTests.Steps
{
    [Binding]
    public class LibraryManagerStepDefinitions
    {
        private readonly ApiClient _api = new ApiClient();
        private RestResponse _response;
        private Book _book;
        private int _bookId = 1;

        //private BookId(int a) => a;

        [When("I request all books")]
        public void WhenIRequestAllBooks()
        {
            var request = new RestRequest("/books", Method.Get);
            _response = _api.Client.Execute(request);
        }

        [Then("the response should contain a list of books")]
        public void ThenTheResponseShouldContainAListOfBooks()
        {
            Assert.That(_response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            var books = JsonConvert.DeserializeObject<List<Book>>(_response.Content);
            Assert.That(books, Is.Not.Null);
        }

        [When("I add a new book")]
        public void WhenIAddANewBook()
        {
            _book = new Book { Id = _bookId, Author = "TestAuthor", Title = "TestTitle", Description = "TestDescription" };
            var request = new RestRequest("/books", Method.Post);
            request.AddJsonBody(_book);
            _response = _api.Client.Execute(request);
        }

        [When("I get the book by ID")]
        public void WhenIGetTheBookByID()
        {
            var request = new RestRequest($"/books/{_bookId}", Method.Get);
            _response = _api.Client.Execute(request);
        }

        [Then("the book data should match")]
        public void ThenTheBookDataShouldMatch()
        {
            var fetchedBook = JsonConvert.DeserializeObject<Book>(_response.Content);
            Assert.That(fetchedBook.Id, Is.EqualTo(_bookId));
            Assert.That(fetchedBook.Author, Is.EqualTo(null));
        }

        [Given("I have added a new book")]
        public void GivenIHaveAddedANewBook()
        {
            WhenIAddANewBook();
        }

        [When("I update the book")]
        public void WhenIUpdateTheBook()
        {
            var updatedBook = new Book { Id = _bookId, Author = "UpdatedAuthor", Title = "UpdatedTitle", Description = "UpdatedDescription" };
            var request = new RestRequest($"/books/{_bookId}", Method.Put);
            request.AddJsonBody(updatedBook);
            _response = _api.Client.Execute(request);
        }

        [Then("the updated data should be returned")]
        public void ThenTheUpdatedDataShouldBeReturned()
        {
            var updatedBook = JsonConvert.DeserializeObject<Book>(_response.Content);
            Assert.That(updatedBook.Author, Is.EqualTo("UpdatedAuthor"));
        }

        [When("I delete the book")]
        public void WhenIDeleteTheBook()
        {
            var request = new RestRequest($"/books/{_bookId}", Method.Delete);
            _response = _api.Client.Execute(request);
        }

        [Then("getting the book should return not found")]
        public void ThenGettingTheBookShouldReturnNotFound()
        {
            var request = new RestRequest($"/books/{_bookId}", Method.Get);
            var response = _api.Client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
        }
    }
}