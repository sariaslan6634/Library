using Library.Application.Features.Member.Commands.CreateMember;
using Library.Application.Features.Member.Queries;
using Library.WebAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Library.Application.Features.Member.Queries.GetMembersListQuery;

namespace Library.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetMembersListQuery(), cancellationToken);
            return Ok(new ResponseDto<List<GetMembersListQueryDto>>
            {
                Success = true,
                Message = "Kütüphaneye kayıtlı üyeler:",
                Data = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMemberCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new ResponseDto<string>
            {
                Success = true,
                Message = $"{command.FirstName + command.LastName}  sisteme eklendi.",
                Data = result.ToString()
            });
        }
    }
}
