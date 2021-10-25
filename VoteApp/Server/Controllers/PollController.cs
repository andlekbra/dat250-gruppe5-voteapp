using VoteApp.Shared.Models;
using VoteApp.Business.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoteApp.DataAccess.Entities;
using System.Diagnostics;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace VoteApp.Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PollController : ControllerBase
	{
		#region Setup
		private readonly IPollRepository _repository;
		private readonly IPollTemplateRepository _repositoryPT;
		public PollController(IPollRepository repository, IPollTemplateRepository repositoryPT)
		{
			_repository = repository;
			_repositoryPT = repositoryPT;
		}
		#endregion

		#region Create
		[HttpPost]
		public IActionResult Create(Poll Poll)
		{
			try
			{
				Task<PollTemplateDTO> pollTemplateTask = _repositoryPT.GetPollTemplate(Poll.PollTemplateId);
				pollTemplateTask.Wait();

				var addedPoll = _repository.CreatePoll(Poll).Result;
				return CreatedAtAction(nameof(Create), addedPoll);
			}
			catch (AggregateException ex)
			{
				string response = JsonSerializer.Serialize(new
				{
					_PHthis = "failed", //_PHthis because "this" is reserved and doesn't seem hide-able in this context
					with = ex.GetBaseException().GetType().ToString(),
					because = $"Likely could not find PollTemplate with id:[{Poll.PollTemplateId}]"
				}).Replace("_PHthis", "this");


				return BadRequest(response);
			}
			catch (Exception ex)
			{
				Debug.WriteLine("coca:" + ex.GetType());
				Debug.WriteLine(ex.ToString());
				return BadRequest();
			}
		}
		#endregion

		#region Read
		[HttpGet]
		public ActionResult<IEnumerable<Poll>> GetAll() => _repository.GetAllPolls().Result.ToList();
		[HttpGet("{id}")]
		public ActionResult<Poll> Get(int id) => _repository.GetPoll(id).Result;
		#endregion

		#region Update
		[HttpPut]
		public IActionResult Update(Poll updatedPoll)
		{
			try
			{
				Task<PollTemplateDTO> pollTemplateTask = _repositoryPT.GetPollTemplate(updatedPoll.PollTemplateId);
				pollTemplateTask.Wait();

				var addedPoll = _repository.UpdatePoll(updatedPoll).Result;
				return CreatedAtAction(nameof(Create), addedPoll);
			}
			catch (AggregateException ex)
			{
				string response = JsonSerializer.Serialize(new
				{
					_PHthis = "failed", //_PHthis because "this" is reserved and doesn't seem hide-able in this context
					with = ex.GetBaseException().GetType().ToString(),
					because = $"Likely could not find PollTemplate with id:[{updatedPoll.PollTemplateId}] or poll does not exist"
				}).Replace("_PHthis", "this");


				return BadRequest(response);
			}
			catch (Exception ex)
			{
				Debug.WriteLine("coca:" + ex.GetType());
				Debug.WriteLine(ex.ToString());
				return BadRequest();
			}
		}
		#endregion
		#region Delete
		[HttpDelete("{id}")]
		public ActionResult<Poll> Delete(int id) => _repository.DeletePoll(id).Result;
		#endregion
	}
}
