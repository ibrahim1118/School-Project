using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Feature.Students.Commands.Modules;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entites;
using SchoolProject.Services.Abstract;
using SchoolProject.Services.implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Feature.Students.Commands.Handler
{
    public class StudentCommandHandler : ResponseHandler, IRequestHandler<DeleteStudentCommand , Response<string>> ,   IRequestHandler<EditStudentCommand , Response<string>>,  IRequestHandler<AddStudentCommand, Response<string>>
    {
        private readonly IStudentService studentService;
        private readonly IMapper mapper;
        private readonly IStringLocalizer<SharedResources> _stingLocalizer;
        private readonly IDepartmentServices departmentServices;

        public StudentCommandHandler(IStudentService studentService ,
            IMapper mapper , 
            IStringLocalizer<SharedResources> stingLocalizer  , IDepartmentServices departmentServices)
        {
            this.studentService = studentService;
            this.mapper = mapper;
            _stingLocalizer = stingLocalizer;
            this.departmentServices = departmentServices;
        }
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var department = await departmentServices.GetDepartmentByIdAcync(request.DID); 
            if (department is null)
            {
                return NotFound<string>($"NO Department with id {request.DID}"); 
            }
            var student = mapper.Map<Student>(request); 
            var res = await studentService.AddStudentAsync(student);
            if (res == "Added")
                return Created<string>("Added Successfully");
            else
                return BadRequest<string>("This Name is Existed"); 
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await studentService.getStundentByIdAsync(request.StudID); 
            if (student  == null)
                return NotFound<string>(_stingLocalizer[SharedResourcesKeys.NotFound]); 
            var studentMapped = mapper.Map(request , student);

            var res = await studentService.EditStudentAsync(studentMapped);
            if (res == "Success")
                return Success<string>("Edit Seccessufly");
           
            return BadRequest<string>(); 
            
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var studnt = await studentService.getStundentByIdAsync(request.id);
            if (studnt == null)
                return NotFound<string>(_stingLocalizer[SharedResourcesKeys.NotFound]); 
            var res = await studentService.DeleteStudentAsync(studnt);
            if (res == "Success")
                return Deleted<string>();

            return BadRequest<string>();

        }
    }
}
