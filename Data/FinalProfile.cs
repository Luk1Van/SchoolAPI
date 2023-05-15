using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolAPI.Data.Entities;
using SchoolAPI.Models;
using System.Runtime.CompilerServices;

namespace SchoolAPI.Data
{
    public class FinalProfile : Profile
    {
        public FinalProfile()
        {
            this.CreateMap<Final, FinalModel>();
            this.CreateMap<FinalModel, Final>();
            this.CreateMap<Course, CourseModel>();
        }
    }
}
