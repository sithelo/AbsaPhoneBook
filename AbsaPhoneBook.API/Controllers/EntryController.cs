using AbsaPhoneBook.Application.Features.Entries.Commands.CreateEntry;
using AbsaPhoneBook.Application.Features.Entries.Commands.UpdateEntry;
using AbsaPhoneBook.Application.Features.Entries.Queries.GetEntriesList;
using AbsaPhoneBook.Application.Features.Entries.Queries.GetEntriesListWithPagination;
using AbsaPhoneBook.Application.Features.Entries.Queries.GetEntryDetail;
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
    public class EntryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EntryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all/{search}", Name = "GetAllEntriesBySearch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EntryListWithPaginationVm>>> GetAllEntriesBySearch(string search)
        {
            GetEntriesListWithPaginationQuery getEntriesListWithPaginationQuery = new GetEntriesListWithPaginationQuery() { search = search, size=10, page=1 };
            var dtos = await _mediator.Send(getEntriesListWithPaginationQuery);
            return Ok(dtos);
        }
        [HttpGet("all", Name = "GetAllEntries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EntryListVm>>> GetAllEntries()
        {
            GetEntriesListQuery getEntriesListQuery = new GetEntriesListQuery();
            var dtos = await _mediator.Send(getEntriesListQuery);
            return Ok(dtos);
        }
        [HttpGet("{id}", Name = "GetEntryById")]
        public async Task<ActionResult<EntryDetailVm>> GetEntryById(Guid id)
        {
            var getEntryDetailQuery = new GetEntryDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getEntryDetailQuery));
        }

        [HttpPost(Name = "AddEntry")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEntryCommand createEntryCommand)
        {
            /// var getEntryDetailQuery = new CreateEntryCommand() { Id = id };
            var id = await _mediator.Send(createEntryCommand);
            return Ok(id);
        }
        [HttpPut(Name = "UpdateEntry")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateEntry([FromBody] UpdateEntryCommand updateEntryCommand)
        {
            await _mediator.Send(updateEntryCommand);
            return NoContent();
        }

    }
}
