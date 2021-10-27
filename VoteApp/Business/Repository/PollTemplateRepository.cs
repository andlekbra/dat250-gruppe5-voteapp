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
    public class PollTemplateRepository : IPollTemplateRepository

    {

        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public PollTemplateRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<PollTemplateDTO> CreatePollTemplate(PollTemplateDTO pollTemplateDTO)
        {
            PollTemplate pollTemplate = _mapper.Map<PollTemplateDTO, PollTemplate>(pollTemplateDTO);
            var addedPollTemplate = await _db.AddAsync(pollTemplate);
            await _db.SaveChangesAsync();
            return _mapper.Map<PollTemplate,PollTemplateDTO>(addedPollTemplate.Entity);
        }

        public async Task<IEnumerable<PollTemplateDTO>> GetAllPollTemplates()
        {
            try
            {
                IEnumerable<PollTemplateDTO> pollTemplateDTOs = _mapper.Map<IEnumerable<PollTemplate>, IEnumerable< PollTemplateDTO >> (_db.PollTemplates);
                return pollTemplateDTOs;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<PollTemplateDTO> GetPollTemplate(int pollTemplateid)
        {
            try
            {
                PollTemplateDTO pollTemplateDTO = _mapper.Map<PollTemplate, PollTemplateDTO>(
                    await _db.PollTemplates.FirstOrDefaultAsync(x => x.Id == pollTemplateid));
                return pollTemplateDTO;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
