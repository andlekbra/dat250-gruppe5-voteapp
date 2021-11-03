using AutoMapper;
using System;
using System.Collections.Generic;
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
		private readonly IMapper _mapper;
		public PollRepository(VoteAppDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}

		public async Task<PollDTO> CreatePoll(PollDTO pollDTO)
		{
			Poll poll = _mapper.Map<PollDTO, Poll>(pollDTO);
			var addedPoll = await _db.AddAsync(poll);
			await _db.SaveChangesAsync();
			return _mapper.Map<Poll, PollDTO>(addedPoll.Entity);
		}

		public async Task<PollDTO> DeletePoll(int pollid)
		{
			try
			{
				Poll poll = await _db.Polls.FirstOrDefaultAsync(x => x.Id == pollid);
				_db.Remove(poll);
				await _db.SaveChangesAsync();
				return _mapper.Map<Poll, PollDTO>(poll);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<IEnumerable<PollDTO>> GetAllPolls()
		{
			try
			{
				IEnumerable<PollDTO> polls = _mapper.Map<IEnumerable<Poll>, IEnumerable<PollDTO>>(_db.Polls);
				return polls;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public async Task<PollDTO> GetPoll(int pollid)
		{
			try
			{
				PollDTO poll = _mapper.Map<Poll, PollDTO>(
					await _db.Polls.FirstOrDefaultAsync(x => x.Id == pollid));
				return poll;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public async Task<PollDTO> UpdatePoll(PollDTO poll)
		{

			_db.Entry(poll).State = EntityState.Modified;
			await _db.SaveChangesAsync();
			return poll;
		}
	}
}
