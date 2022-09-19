using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Claims;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            #region Credit
            //CreateMap<Credit, CreditDto>()
            //    .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            //    .ForMember(d => d.BankCredit, o => o.MapFrom(s => s.BankCredit))
            //    .ForMember(d => d.CashCredit, o => o.MapFrom(s => s.CashCredit))
            //    .ForMember(d => d.CreatedBy, o => o.MapFrom(s => s.CreateUser.FirstName + " " + s.CreateUser.LastName))
            //    .ForMember(d => d.CreateDate, o => o.MapFrom(s => s.CreateDate));

            CreateMap<CertificateDto, Certificate>()
           .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
           .ForMember(d => d.CertificateDate, o => o.MapFrom(s => s.CertificateDate));

            CreateMap<UserDto, AppUser>()
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email));

            #endregion

        }
    }
}