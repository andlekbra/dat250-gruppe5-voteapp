using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteApp.DataAccess.Entities;
using VoteApp.Shared.Models;

namespace VoteApp.Business
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PollTemplateDTO, PollTemplate>();
            CreateMap<PollTemplate, PollTemplateDTO>();
        }
    }
}
