﻿using System;
using System.Collections.Generic;
using System.Text;
using WebApiContracts.DTO;
using AutoMapper;
using Domain.Entities;

namespace Domain.MapperProfiles
{
    public class DomainProfile:Profile
    {
        /// <summary>
        /// Настройка автомаппера для копирования моделей в dto
        /// </summary>
        public DomainProfile()
        {
            CreateMap<StudentDto, Student>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                 .ForMember(x => x.Group1, opt => opt.Ignore())
                 .ForMember(x => x.Group2, opt => opt.Ignore())
                 .ForMember(x => x.Group3, opt => opt.Ignore())
                 .ForMember(x => x.LocalCity, opt => opt.Ignore())
                 .ForMember(x => x.MainDocument, opt => opt.Ignore());
            CreateMap<Student, StudentDto>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentDto, Department>();
            CreateMap<LocalCityDto, LocalCity>();
            CreateMap<LocalCity, LocalCityDto>();
            CreateMap<RegionDto, Region>();
            CreateMap<Region, RegionDto>();
            CreateMap<School, SchoolDto>()
            .ForMember(dest => dest.RegionId, opt => opt.MapFrom(src => src.CityId));
            CreateMap<SchoolDto, School>()
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.RegionId));
            CreateMap<GroupDto, Group>();
            CreateMap<Group, GroupDto>();

        }
    }
}
