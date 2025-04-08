using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Feature.Department.Queries.Modules;
using SchoolProject.Core.Feature.Department.Queries.Respones;
using SchoolProject.Core.Feature.Students.Queries.Modules;
using SchoolProject.Core.Feature.Students.Queries.Respones;
using SchoolProject.Core.Resources;
using SchoolProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Feature.Department.Queries.Handler
{
    public class DepartmentQueryHanler : ResponseHandler,
        IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdRespone>>
    {
        private readonly IDepartmentServices departmentServices;
        private readonly IMapper mapper;
        private readonly IStringLocalizer<SharedResources> stingLocalizer;

        public DepartmentQueryHanler(
            IDepartmentServices departmentServices, 
            IMapper mapper,
            IStringLocalizer<SharedResources> stingLocalizer) 
        {
            this.departmentServices = departmentServices;
            this.mapper = mapper;
            this.stingLocalizer = stingLocalizer;
        }
        public async Task<Response<GetDepartmentByIdRespone>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await departmentServices.GetDepartmentByIdAcync(request.id); 
            if(department == null)
            {
                return NotFound<GetDepartmentByIdRespone>(stingLocalizer[SharedResourcesKeys.NotFound]);
            }
            var mappedDepartment = mapper.Map<GetDepartmentByIdRespone>(department);    
            return Success(mappedDepartment);
            
        }
    }
}
