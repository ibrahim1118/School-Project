using AutoMapper;
using SchoolProject.Core.Feature.Students.Commands.Modules;
using SchoolProject.Core.Feature.Students.Queries.Respones;
using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.Students
{
    public class StudentProfile  :Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, GetStudentListRespones>().
                 ForMember(des => des.DepartmentName, op => op.MapFrom(src => src.Department.Localize(src.Department.DNameAr , src.Department.DNameEn ))).
                 ForMember(des => des.Name, op => op.MapFrom(src => src.Localize(src.NameAr , src.NameEn)));


            CreateMap<Student, GetStudentByIdRespones>().
                 ForMember(des => des.DepartmentName, op => op.MapFrom(src => src.Localize(src.Department.DNameAr , src.Department.DNameEn))).
                 ForMember(des => des.Name, op => op.MapFrom(src => src.Localize(src.NameAr , src.NameEn)));

            CreateMap<AddStudentCommand, Student>();
            CreateMap<EditStudentCommand, Student>();
        }
    }
}
