using AutoMapper;
using SchoolAPI.Data.Entities;
using SchoolAPI.Models;

namespace SchoolAPI.Data
{
    public class StudentProfie : Profile
    {
        public StudentProfie()
        {
            this.CreateMap<Student, StudentModel>();
            this.CreateMap<StudentModel, Student>();
        }
    }
}
