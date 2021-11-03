using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteApp.DataAccess;
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
            CreateMap<PollDTO, Poll>().ForMember(p => p.IoTDevices, option => option.Ignore());
            CreateMap<Poll, PollDTO>().ForMember(p => p.IoTDevices, option => option.MapFrom(src => src.IoTDevices.Select(dev => dev.Id)));
        }
    }
}
