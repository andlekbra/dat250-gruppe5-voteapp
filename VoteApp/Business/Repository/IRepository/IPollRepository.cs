using VoteApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteApp.DataAccess.Entities;
using VoteApp.Shared.Models;

namespace VoteApp.Business.Repository
{
    
    public interface IPollRepository
    {
        public Task<PollDTO> CreatePoll(PollDTO poll);

        public Task<PollDTO> GetPoll(int id);
        public Task<IEnumerable<PollDTO>> GetAllPolls();

        public Task<PollDTO> DeletePoll(int id);
        public Task<PollDTO> UpdatePoll(PollDTO poll);
    }
}