using AutoMapper;
using CMS.DTOs;
using CMS.Models;
using Microsoft.AspNetCore.Routing.Constraints;

namespace CMS.Profiles
{
    public class ContactsProfile : Profile
    {
        public ContactsProfile()
        {
            CreateMap<Contact, ContactReadDto>();
            CreateMap<ContactCreateDto, Contact>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
        }
    }
}
