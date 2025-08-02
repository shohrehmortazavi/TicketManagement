using AutoMapper;
using TicketManagement.Application.Domains.Tickets.DTOs;
using TicketManagement.Application.Domains.Users.DTOs;
using TicketManagement.Domain.Domains.Tickets;
using TicketManagement.Domain.Domains.Users;

namespace TicketManagement.Application.SeedWorks;
public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<Ticket, CreateTicketRequestDto>().ReverseMap();
        CreateMap<Ticket, UpdateTicketRequestDto>().ReverseMap();
        CreateMap<TicketResponseDto, Ticket>().ReverseMap();
   
        CreateMap<User, UserRequestDto>().ReverseMap();
        CreateMap<UserResponseDto, User>().ReverseMap();
    }
}
