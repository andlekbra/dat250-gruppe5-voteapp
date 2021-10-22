using VoteApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteApp.Shared.Models;

namespace VoteApp.Business.Repository
{
    public interface IPollTemplateRepository
    {
        public Task<PollTemplateDTO> CreatePollTemplate(PollTemplateDTO pollTemplate);

        public Task<PollTemplateDTO> GetPollTemplate(int id);
        public Task<IEnumerable<PollTemplateDTO>> GetAllPollTemplates();
    }
}
