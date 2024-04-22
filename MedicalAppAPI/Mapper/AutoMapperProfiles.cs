using AutoMapper;
using MedicalAppAPI.DTOs;
using MedicalAppAPI.Models.Domains;

namespace MedicalAppAPI.Mapper
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<MedicalRecordDto, MedicalRecord>().ReverseMap();
            CreateMap<UpdateRecordDto, MedicalRecord>().ReverseMap();
        }
    }
}
