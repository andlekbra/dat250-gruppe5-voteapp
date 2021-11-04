using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VoteApp.Business.Repository;
using VoteApp.Shared;

namespace VoteApp.Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DweetTestController : ControllerBase
	{
		#region Setup
		private readonly IPollRepository _repository;
		private readonly IPollTemplateRepository _repositoryPT;
		public DweetTestController(IPollRepository repository, IPollTemplateRepository repositoryPT)
		{
			_repository = repository;
			_repositoryPT = repositoryPT;
		}
		#endregion

		#region Create
		[HttpPost]
		public IActionResult Create(string Name, string ob)
		{
			try
			{
				_ = DweetIO.DweetFor(Name, ob);


				return CreatedAtAction(nameof(Create), ob);
			}
			catch (Exception ex)
			{

				Debug.WriteLine(ex.ToString());
				return BadRequest();
			}
		}
		#endregion

		#region Read
		[HttpGet]
		[Route("all")]
		public async Task<ActionResult<object>> GetOneAsync(string Name) => await DweetIO.GetLatestDweetFor(Name);
		[HttpGet]
		public async Task<ActionResult<object>> GetAll(string Name) => await DweetIO.GetDweetsFor(Name);
		#endregion
	}
}
