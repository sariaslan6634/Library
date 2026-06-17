using AutoMapper;
using Library.Application.Features.Member.Commands.CreateMember;
using Library.Application.Features.Member.Queries;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static Library.Application.Features.Member.Queries.GetMembersListQuery;

namespace Library.Application.Features.Member.Mapping
{
    public class MemberMappingProfile : Profile
    {
        public MemberMappingProfile()
        {
            CreateMap<CreateMemberCommand, Library.Domain.Entities.Member>().ReverseMap();
            CreateMap<GetMembersListQueryDto, Library.Domain.Entities.Member>().ReverseMap();
        }
    }
}
