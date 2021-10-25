using VoteApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteApp.DataAccess.Entities;

namespace VoteApp.Business.Repository
{
    
    public interface IPollRepository
    {
        public Task<Poll> CreatePoll(Poll poll);

        public Task<Poll> GetPoll(int id);
        public Task<IEnumerable<Poll>> GetAllPolls();

        public Task<Poll> DeletePoll(int id);
        public Task<Poll> UpdatePoll(Poll poll);
    }
}