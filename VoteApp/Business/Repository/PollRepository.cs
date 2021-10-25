using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VoteApp.DataAccess;
using VoteApp.Shared.Models;
using VoteApp.DataAccess.Entities;

namespace VoteApp.Business.Repository
{
	public class PollRepository : IPollRepository

	{

		private readonly VoteAppDbContext _db;
		public PollRepository(VoteAppDbContext db)
		{
			_db = db;
		}

		public async Task<Poll> CreatePoll(Poll poll)
		{
			var addedPoll = await _db.AddAsync(poll);
			await _db.SaveChangesAsync();
			return addedPoll.Entity;
		}

		public async Task<IEnumerable<Poll>> GetAllPolls()
		{
			try
			{
				IEnumerable<Poll> polls = _db.Polls;
				return polls;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public async Task<Poll> GetPoll(int pollid)
		{
			try
			{
				Poll poll =
					await _db.Polls.FirstOrDefaultAsync(x => x.Id == pollid);
				return poll;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
	}
}
