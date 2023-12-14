using AutoMapper;
using GymManager.Entities;
using GymManager.Entities.Dtos;

namespace GymManager.Api.Profiles
{
    public class GymManagerMappingProfile : Profile
    {
        public GymManagerMappingProfile()
        {
            TimeZoneInfo localTimeZone = TimeZoneInfo.FindSystemTimeZoneById("America/Bogota");

            CreateMap<GymRegistrationDto, Gyms>()
                .ReverseMap();
            CreateMap<GymDto, Gyms>()
                .ReverseMap();
            CreateMap<GymUpdateDto, Gyms>()
                .ReverseMap();

            CreateMap<TransactionTypeDto, TransactionTypes>()
                .ReverseMap();
            CreateMap<TransactionTypeDto, TransactionTypes>()
                .ReverseMap();

            CreateMap<DocumentTypeDto, DocumentTypes>()
                .ReverseMap();

            CreateMap<GymLocationDto, GymLocations>()
                .ReverseMap();
            CreateMap<GymLocationRegistrationDto, GymLocations>()
                .ReverseMap();
            CreateMap<GymLocationUpdateDto, GymLocations>()
                .ReverseMap();

            CreateMap<MembershipTypes, MembershipTypeDto>()
                .ForMember(dest => dest.FinalDate, opt => opt.MapFrom(src => src.FinalDate == DateTime.MinValue ? DateTime.Now.AddYears(100) : src.FinalDate))
                .ReverseMap();
            CreateMap<MembershipTypeRegistrationDto, MembershipTypes>()
               .ReverseMap();
            CreateMap<MembershipTypUpdateDto, MembershipTypes>()
               .ReverseMap();

            CreateMap<CustomerDto, Customers>()
                .ReverseMap();
            CreateMap<CustomerRegistrationDto, Customers>()
                .ForMember(dest => dest.Observation, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Observation) ? "" : src.Observation))
                .ReverseMap();

            CreateMap<MembershipCustomerDto, MembershipCustomers>()
                .ReverseMap();
            CreateMap<MembershipCustomerRegistrationDto, MembershipCustomers>()
                .ReverseMap();

            CreateMap<CashBox, CashBoxDto>()
               /*.ForMember(dest => dest.OpeningDate, opt => opt.MapFrom(src => TimeZoneInfo.ConvertTimeFromUtc(src.OpeningDate, localTimeZone)))
               .ForMember(dest => dest.ClosingDate, opt => opt.MapFrom(src => TimeZoneInfo.ConvertTimeFromUtc(src.ClosingDate, localTimeZone)))*/
               .ReverseMap();
            CreateMap<CashBoxRegistrationDto, CashBox>()
                .ReverseMap();

            CreateMap<Transactions, TransactionDto>()
            .ReverseMap();
            CreateMap<Transactions, TransactionRegistrationDto>()
                .ReverseMap();

            CreateMap<CustomerDimensions, CustomerDimensionDto>()
                 .ReverseMap()
                 .ForMember(dest => dest.RegistrationDate, opt => opt.MapFrom(src => TimeZoneInfo.ConvertTimeFromUtc(src.RegistrationDate, localTimeZone)));
            CreateMap<CustomerDimensions, CustomerDimensionRegistrationDto>()
                 .ReverseMap();
        }
    }
}