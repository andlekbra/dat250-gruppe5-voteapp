using VoteApp.Shared.Models;
using VoteApp.Business.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace VoteApp.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PollTemplateController : ControllerBase
{
        private readonly IPollTemplateRepository _repository;
        public PollTemplateController(IPollTemplateRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PollTemplateDTO>> GetAll() => _repository.GetAllPollTemplates().Result.ToList();

        [HttpPost]
        public IActionResult Create(PollTemplateDTO pollTemplateDTO)
        {
            try
            {
                var addedPollTemplate = _repository.CreatePollTemplate(pollTemplateDTO).Result;
                return CreatedAtAction(nameof(Create), addedPollTemplate);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
