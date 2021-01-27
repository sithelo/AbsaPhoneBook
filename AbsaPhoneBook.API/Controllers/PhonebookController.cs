using AbsaPhoneBook.Application.Features.Phonebooks.Queries.GetPhonebooksList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsaPhoneBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonebookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PhonebookController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("all", Name = "GetAllPhonebooks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PhonebookListVm>>> GetAllPhonebooks()
        {
            GetPhonebooksListQuery getPhonebooksListQuery = new GetPhonebooksListQuery();
            var dtos = await _mediator.Send(getPhonebooksListQuery);
            return Ok(dtos);
        }
    }
}
