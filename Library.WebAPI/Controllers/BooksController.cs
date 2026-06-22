using Library.Application.Features.Books.Commands.BorrowBookCommand;
using Library.Application.Features.Books.Commands.CreateBook;
using Library.Application.Features.Books.Commands.DeleteBookCommand;
using Library.Application.Features.Books.Commands.ReturnBookCommand;
using Library.Application.Features.Books.Commands.UpdateBookCommand;
using Library.Application.Features.Books.Queries;
using Library.Domain.Entities;
using Library.WebAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static Library.Application.Features.Books.Queries.GetBookByIdQuery;
using static Library.Application.Features.Books.Queries.GetBooksListQuery;

namespace Library.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetBooksListQuery(), cancellationToken);
            return Ok(new ResponseDto<List<GetBooksListQueryDto>>
            {
                Success = true,
                Message = "Kütüphaneye ait bütün kitapların listesi",
                Data = result
            });
        }
        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetBookById(Guid bookId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetBookByIdQuery(bookId), cancellationToken);
            return Ok(new ResponseDto<CreateBookCommandDto>
            {
                Success = true,
                Data = result
            });
        }
        [Authorize]
        [HttpDelete("{bookId}")]
        public async Task<IActionResult> Delete(Guid bookId, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteBookCommand(bookId), cancellationToken);
            return NoContent();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookCommand command,CancellationToken cancellationToken)
        {
            var book = await _mediator.Send(command, cancellationToken);
            return Ok(new ResponseDto<string>
            {
                Success = true,
                Message = "Kitap eklendi.",
                Data = book.ToString()
            });
        }

        [HttpPost("{bookId}/borrow/{MemberId}")]
        public async Task<IActionResult> Borrow(Guid bookId, Guid MemberId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new BorrowBookCommand(bookId, MemberId), cancellationToken);
            return Ok(new ResponseDto<string>
            {
                Success = true,
                Message = "Kitap ödünc verildi",
                Data = result.ToString()
            });
        }
        [HttpPost("{bookId}/return")]
        public async Task<IActionResult> Return(Guid bookId, CancellationToken cancellationToken)
        {
            await _mediator.Send(new ReturnBookCommand(bookId), cancellationToken);
            return NoContent();
        }
        [HttpPut("{bookId}")]
        public async Task<IActionResult> Update(Guid bookId,[FromBody] UpdateBookCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command with { BookId = bookId }, cancellationToken);
            return Ok(new ResponseDto<string>
            {
                Success = true,
                Message = "Kitap güncellendi",
                Data = result.ToString()
            });
        }
    }
}
