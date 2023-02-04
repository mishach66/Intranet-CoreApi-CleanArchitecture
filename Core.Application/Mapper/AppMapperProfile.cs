using AutoMapper;
using Core.Application.DTO;
using Core.Application.Features.Commands;
using Core.Domain.Models;

namespace Core.Application.Mapper
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<City, CityResponse>().ReverseMap();
            CreateMap<City, CreateCityCommand>().ReverseMap();
            CreateMap<City, EditCityCommand>().ReverseMap();

            CreateMap<Branch, BranchResponse>().ReverseMap();
            CreateMap<Branch, CreateBranchCommand>().ReverseMap();
            CreateMap<Branch, EditBranchCommand>().ReverseMap();

            CreateMap<Employee, EmployeeResponse>().ReverseMap();
            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, EditEmployeeCommand>().ReverseMap();

            CreateMap<News, NewsResponse>().ReverseMap();
            CreateMap<News, CreateNewsCommand>().ReverseMap();
            CreateMap<News, EditNewsCommand>().ReverseMap();

            CreateMap<Vacancy, VacancyResponse>().ReverseMap();
            CreateMap<Vacancy, CreateVacancyCommand>().ReverseMap();
            CreateMap<Vacancy, EditVacancyCommand>().ReverseMap();

            CreateMap<Sex, SexResponse>().ReverseMap();
        }
    }
}
