using AutoMapper;
using SchoolProject.Core.Feature.Department.Queries.Respones;
using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.Departments
{
    public class DepartmentPorfile  :Profile
    {
        public DepartmentPorfile()
        {
            CreateMap<Department, GetDepartmentByIdRespone>().
                ForMember(des => des.Id, op => op.MapFrom(src => src.DID))
                .ForMember(des => des.Name, op => op.MapFrom(src => src.Localize(src.DNameAr, src.DNameEn)))
                .ForMember(des => des.MangerName, op => op.MapFrom(src => src.Instructor.Localize(src.Instructor.ENameAr, src.Instructor.ENameEn)))
                .ForMember(des => des.Students, op => op.MapFrom(src => src.Students))
                .ForMember(des => des.Instractor, op => op.MapFrom(src => src.Instructors))
                .ForMember(des => des.Subject, op => op.MapFrom(src => src.DepartmentSubjects));

            CreateMap<DepartmetSubject, SubjectRespons>()
                .ForMember(des => des.id, op => op.MapFrom(src => src.SubID))
                .ForMember(des => des.SubjectName, op => op.MapFrom(src => src.Subjects.Localize(src.Subjects.SubjectNameAr, src.Subjects.SubjectNameEn)));

            CreateMap<Student, StudentRespons>()
                   .ForMember(des => des.Id, op => op.MapFrom(src => src.StudID))
                   .ForMember(des => des.StudentName, op => op.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));

            CreateMap<Instructor, InstractorRespons>()
                   .ForMember(des => des.Id, op => op.MapFrom(src => src.InsId))
                   .ForMember(des => des.InstractorName, op => op.MapFrom(src => src.Localize(src.ENameAr, src.ENameEn)));

        }
    }
}
