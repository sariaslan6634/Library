using AutoMapper;
using Library.Application.Common.Interfaces;
using Library.Application.Features.Books.Queries;
using Library.Domain.Entities;
using Moq;
using MockQueryable.Core;
using MockQueryable.Moq;
using static Library.Application.Features.Books.Queries.GetBooksListQuery;
using FluentAssertions;

namespace Library.Application.Tests.Features.Books
{
    public class GetBooksListQueryHandlerTests 
    {
        private readonly Mock<ILibraryDbContext> _contextMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly GetBooksListQueryHandler _handler;

        public GetBooksListQueryHandlerTests()
        {
            _contextMock = new Mock<ILibraryDbContext>();
            _mapperMock = new Mock<IMapper>();
            _handler = new GetBooksListQueryHandler(_contextMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_WhenBooksExist_ReturnsBookList()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book { Id = Guid.NewGuid(), Title = "Kitap 1", Writer = "Yazar 1", IsAvailable = true },
                new Book { Id = Guid.NewGuid(), Title = "Kitap 2", Writer = "Yazar 2", IsAvailable = false }
            };

            var mockSet = books.BuildMockDbSet();
            _contextMock.Setup(x => x.Books).Returns(mockSet.Object);

            var dtoList = books.Select(b => new GetBooksListQueryDto(
                b.Id, b.Title, "", 0, b.Writer, "Müsait", b.IsAvailable)).ToList();

            _mapperMock.Setup(x => x.Map<List<GetBooksListQueryDto>>(It.IsAny<object>()))
                .Returns(dtoList);

            // Act
            var result = await _handler.Handle(new GetBooksListQuery(), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
        }
        [Fact]
        public async Task Handle_WhenNoBooksExist_ReturnsEmptyList()
        {
            // Arrange
            var books = new List<Book>();

            var mockSet = books.BuildMockDbSet();
            _contextMock.Setup(x => x.Books).Returns(mockSet.Object);

            var dtoList = books.Select(b => new GetBooksListQueryDto(
                b.Id, b.Title, "", 0, b.Writer, "Müsait", b.IsAvailable)).ToList();

            _mapperMock.Setup(x => x.Map<List<GetBooksListQueryDto>>(It.IsAny<object>()))
                .Returns(dtoList);

            // Act
            var result = await _handler.Handle(new GetBooksListQuery(), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(0);
        }

    }
}
