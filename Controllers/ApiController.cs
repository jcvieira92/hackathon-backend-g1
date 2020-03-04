using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using hackathon_backdotnet_g1.Models;

namespace hackathon_backdotnet_g1.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        private readonly DatabaseContext _database;

        public ApiController(ILogger<ApiController> logger, DatabaseContext context)
        {
            _logger = logger;
            _database = context;
        }

        [HttpGet]
        [Route("users")]
        public List<User> GetAllUsers() => _database.getUsers();

        [HttpGet]
        [Route("users/{Id}")]
        public User GetAllUsers(long Id)
        {
            return _database.getUser(Id);
        }

        [HttpPost]
        [Route("adduser")]
        [AllowAnonymous]
        public IActionResult AddUser([FromBody] User user)
        {
            _logger.LogInformation("Add User for UserId: {UserId}", user.UserId);
            _database.AddUser(user);
            return Ok(user);
        }

        [HttpDelete]
        [Route("deluser/{Id}")]
        [AllowAnonymous]
        public object DeleteUser(long Id)
        {
            try
            {
                var user = _database.getUser(Id);
                _logger.LogInformation("Delete User for UserId: {UserId}", Id);
                _database.DeleteUser(user.UserId);
                return Ok(user);
            }
            catch
            {
                return new DefaultError(HttpStatusCode.NotFound, $"Can't find user with ID {Id}");
            }
        }

        [HttpPut]
        [Route("upuser")]
        [AllowAnonymous]
        public object UpdateUser([FromBody] User user)
        {
            try
            {
                _logger.LogInformation("Update User for UserId: {UserId}", user.UserId);
                _database.UpdateUser(user);
                return Ok(user);
            }
            catch
            {
                return new DefaultError(HttpStatusCode.NotFound, $"Can't find user with ID {user.UserId}");
            }
        }

        [HttpGet]
        [Route("books")]
        public List<Book> GetAllBooks() => _database.getBooks();

        [HttpPost]
        [Route("addbook")]
        [AllowAnonymous]
        public IActionResult AddBook([FromBody] Book book)
        {
            _logger.LogInformation("Add Book for BookId: {BookId}", book.BookId);
            _database.AddBook(book);
            return Ok(book);
        }


    }
}