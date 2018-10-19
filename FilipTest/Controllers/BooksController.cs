using FilipTest.Models;
using MessagePack;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FilipTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // GET: api/Books
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return Book.Data;
        }

        // POST: api/Books
        [HttpPost]
        public void Post([FromBody] Book book)
        {
            Book.Data.Add(new Book {
                Author = book.Author,
                Title = book.Title,
                Price = book.Price,
                Words = book.Words
            });
        }
    }

}
