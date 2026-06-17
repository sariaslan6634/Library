using AutoMapper;
using FluentAssertions;
using Library.Application.Common.Interfaces;
using Library.Application.Exceptions.CustomExceptions;
using Library.Application.Features.Books.Commands.BorrowBookCommand;
using Library.Application.Features.Books.Queries;
using Library.Domain.Entities;
using MockQueryable.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Tests.Features.Books
{
    public class BorrowBookCommandHandlerTests
    {
        private readonly Mock<ILibraryDbContext> _contextMock;
        private readonly BorrowBookCommandHandler _handler;

        public BorrowBookCommandHandlerTests()
        {
            _contextMock = new Mock<ILibraryDbContext>();
            _handler = new BorrowBookCommandHandler(_contextMock.Object);
        }

        public async Task Handle_WhenBookNotFound_ThrowsNotFoundException()
        {
            var books = new List<Book>();
            var mockSet = books.BuildMockDbSet();
            _contextMock.Setup(x => x.Books).Returns(mockSet.Object);

            var act = async () => await _handler.Handle(new BorrowBookCommand(Guid.NewGuid(), Guid.NewGuid()), CancellationToken.None);

            await act.Should().ThrowAsync<NotFoundException>();
        }

        [Fact]
        public async Task Handle_WhenBookIsNotAvailable_ThrowsBadRequestException()
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                IsAvailable = false
            };
            var mockSet = new List<Book> { book }.BuildMockDbSet();
            _contextMock.Setup(x => x.Books).Returns(mockSet.Object);

            var act = async () => await _handler.Handle(new BorrowBookCommand(book.Id,Guid.NewGuid()), CancellationToken.None);

            await act.Should().ThrowAsync<BadRequestException>();
        }
    }
}
