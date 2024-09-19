using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MinimalAPI_Anrop_till_aspNet_Rasmus.Models;
using MinimalAPI_Anrop_till_aspNet_Rasmus.Models.DTOs;
using MinimalAPI_Anrop_till_aspNet_Rasmus.Repository;
using System.Runtime.CompilerServices;

namespace MinimalAPI_Anrop_till_aspNet_Rasmus.EndPoint
{
    public static class BookEndpoints
    {
        public static void ConfigurationBookEndpoints(this WebApplication app)
        {
            app.MapGet("api/books", GetAllBooks).WithName("GetBooks").Produces<ApiResponse>();
            app.MapGet("api/book/{id:int}", GetBook).WithName("GetBook").Produces<ApiResponse>();
            app.MapPut("api/book", UpdateBook)
                .WithName("UpdateBook").Accepts<BookUpdateDTO>("application/json").Produces<BookUpdateDTO>(200).Produces(400);
            app.MapPost("api/book", CreateBook)
                .WithName("CreateBook").Accepts<BookCreateDTO>("application/json").Produces<BookCreateDTO>(201).Produces(400);
            app.MapDelete("api/book/{id:int}", DeleteBook).WithName("DeleteBook").Produces<ApiResponse>(200).Produces(400);
        }

        private async static Task<IResult> GetAllBooks(IBookRepository _bookRepository)
        {
            ApiResponse response = new ApiResponse();

            response.Result = await _bookRepository.GetAllAsync();
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;

            return Results.Ok(response);
        }

        private async static Task<IResult> GetBook(IBookRepository _bookRepository, int id)
        {
            ApiResponse response = new ApiResponse();

            response.Result = await _bookRepository.GetAsync(id);
            response.IsSuccess = true;
            response.StatusCode= System.Net.HttpStatusCode.OK;

            return Results.Ok(response);
        }

        private async static Task<IResult> UpdateBook(IBookRepository _bookRepository, IMapper _mapper, BookUpdateDTO book_updateDTO)
        {
            ApiResponse response = new ApiResponse() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

            await _bookRepository.UpdateAsync(_mapper.Map<Books>(book_updateDTO));
            await _bookRepository.SaveASync();

            response.IsSuccess = true;
            response.Result = _mapper.Map<BookUpdateDTO>(await _bookRepository.GetAsync(book_updateDTO.ID));
            response.StatusCode = System.Net.HttpStatusCode.OK;

            return Results.Ok(response);
        }

        private async static Task<IResult> CreateBook(IBookRepository _bookRepository, IMapper _mapper, BookCreateDTO book_createDTO)
        {
            ApiResponse response = new ApiResponse() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

            if(_bookRepository.GetAsync(book_createDTO.Title).GetAwaiter().GetResult() != null)
            {
                response.ErrorMessages.Add("Book already exists in the book store");
                return Results.BadRequest();
            }

            Books book = _mapper.Map<Books>(book_createDTO);
            await _bookRepository.CreateAsync(book);
            await _bookRepository.SaveASync();

            BookDTO bookDTO = _mapper.Map<BookDTO>(book);

            response.Result = bookDTO;
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.Created;

            return Results.Ok(response);
        }

        private async static Task<IResult> DeleteBook(IBookRepository _bookRepository, int id)
        {
            ApiResponse response = new ApiResponse() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

            Books bookToRemove = await _bookRepository.GetAsync(id);

            if(bookToRemove != null)
            {
                await _bookRepository.RemoveASync(bookToRemove);
                await _bookRepository.SaveASync();
                
                response.IsSuccess= true;
                response.StatusCode= System.Net.HttpStatusCode.OK;
                return Results.Ok(response);
            }
            response.ErrorMessages.Add("Could not find book with that ID . . .");
            return Results.BadRequest();
        }

    }
}
