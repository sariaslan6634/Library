using FluentValidation;
using Library.Application.Exceptions;
using Library.Application.Exceptions.CustomExceptions;
using Library.WebAPI.Models;

namespace Library.WebAPI.Middlewares
{
    public class ExceptionMiddleware(RequestDelegate next,ILogger<ExceptionMiddleware> _logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{
                _logger.LogError(ex, "Bir hata oluştu : {Message}", ex.Message);

				context.Response.ContentType = "application/json";

                var errorCode = ErrorCodes.Exception;

                if (ex is ValidationException validationEx)
                {
                    context.Response.StatusCode = 400;
                    errorCode = ErrorCodes.ValidationError;

                    var details = validationEx.Errors
                        .GroupBy(x => x.PropertyName)
                        .ToDictionary(g => g.Key,g => g.Select(x => x.ErrorMessage).ToList());

                    var validationResponse = new ErrorResponse
                    {
                        Success = false,
                        Error = new ErrorDetail
                        {
                            Code = errorCode,
                            Message = "Gönderilen veriler geçersiz",
                            Details = details
                        }
                    };
                    await context.Response.WriteAsJsonAsync(validationResponse);
                    return;
                }

                switch (ex)
                {
                    case NotFoundException:
                        context.Response.StatusCode = 404;
                        errorCode = ErrorCodes.NotFound;
                        break;
                    case UnauthorizedException:
                        context.Response.StatusCode = 401;
                        errorCode = ErrorCodes.Unauthorized;
                        break;
                    case BadRequestException:
                        context.Response.StatusCode = 400;
                        errorCode = ErrorCodes.BadRequest;
                        break;
                    case ForbiddenException:
                        context.Response.StatusCode = 403;
                        errorCode = ErrorCodes.Forbidden;
                        break;
                    default:
                        context.Response.StatusCode = 500;
                        break;
                }

                var response = new ErrorResponse
                {
                    Success = false,
                    Error = new ErrorDetail
                    {
                        Code = errorCode,
                        Message = ex.Message
                    }
                };
                await context.Response.WriteAsJsonAsync(response);
			}
        }
    }
}
