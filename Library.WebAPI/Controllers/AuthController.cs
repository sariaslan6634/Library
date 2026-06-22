using Library.Application.Features.Auth.Commands;
using Library.WebAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator _mediator) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command,CancellationToken  cancellationToken)
        {
            var token = await _mediator.Send(command, cancellationToken);
            return Ok(new ResponseDto<string>
            {
                Success = true,
                Message = "Başarılı bir şekilde giriş yapıldı.",
                Data = token
            });
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command,CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new ResponseDto<string>
            {
                Success = true,
                Message = "Kayıt olma işlemi başarılı.",
                Data = result.ToString()
            });
        }
    }
}
