using FrontEnd_MinimalAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MinimalAPI_Anrop_till_aspNet_Rasmus.Models.DTOs;
using MVC_FrontEnd_MinimalAPI.Services;
using Newtonsoft.Json;

namespace MVC_FrontEnd_MinimalAPI.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> BookIndex()
        {
            List<BookDTO> List = new List<BookDTO>();
            var response = await _bookService.GetAllBooks<ResponseDTO>();
            if (response != null && response.IsSuccess)
            {
                List = JsonConvert.DeserializeObject<List<BookDTO>>(Convert.ToString(response.Result));
            }
            return View(List);
        }

        public async Task<IActionResult> GetSingleBook(int id)
        {
            BookDTO bookDTO = new BookDTO();

            var response = await _bookService.GetBookById<ResponseDTO>(id);

            if (response != null && response.IsSuccess)
            {
                BookDTO book = JsonConvert.DeserializeObject<BookDTO>(Convert.ToString(response.Result));
                return View(book);
            }
            return View();
        }


        public async Task<IActionResult> UpdateBook(int id)
        {
            var response = await _bookService.GetBookById<ResponseDTO>(id);

            if (response != null && response.IsSuccess)
            {
                BookDTO book = JsonConvert.DeserializeObject<BookDTO>(Convert.ToString(response.Result));
                return View(book);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(BookDTO bookDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _bookService.UpdateBookAsync<ResponseDTO>(bookDTO);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));
                }
            }
            return View(bookDTO);
        }

        public async Task<IActionResult> CreateBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(BookDTO bookDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _bookService.AddBookAsync<ResponseDTO>(bookDTO);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));
                }
            }
            return View(bookDTO);
        }

        public async Task<IActionResult> DeleteBook(int id)
        {
            var response = await _bookService.GetBookById<ResponseDTO>(id);

            if (response != null && response.IsSuccess)
            {
                BookDTO book = JsonConvert.DeserializeObject<BookDTO>(Convert.ToString(response.Result));
                return View(book);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook(BookDTO bookDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _bookService.DeleteBookAsync<ResponseDTO>(bookDTO.ID);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));
                }
            }
            return NotFound();
        }



    }
}
