using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Feature.Students.Queries.Modules;
using SchoolProject.Core.Feature.Students.Queries.Respones;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entites;
using SchoolProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Feature.Students.Queries.Handler
{
    public class StudentQuerieHandler :ResponseHandler , 
        IRequestHandler<GetStudentByIdQuerie , Response<GetStudentByIdRespones>> ,
        IRequestHandler<GetStudentListQueries, Response<List<GetStudentListRespones>>>,
        IRequestHandler<GetStudentPaginatedListQueries , PaginatedResult<GetStudentPaginatedListRespones>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper mapper;
        private readonly IStringLocalizer<SharedResources> _stingLocalizer; 
        public StudentQuerieHandler(IStudentService studentService ,
            IMapper mapper ,
            IStringLocalizer<SharedResources> stingLocalizer)
        {
            _studentService = studentService;
            this.mapper = mapper;
            _stingLocalizer = stingLocalizer;
        }
        public async Task<Response<List<GetStudentListRespones>>> Handle(GetStudentListQueries request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.getStudentListAsync(); 
            var res = mapper.Map<List<GetStudentListRespones>>(studentList);
            return Success(res); 
        }

        public async Task<Response<GetStudentByIdRespones>> Handle(GetStudentByIdQuerie request, CancellationToken cancellationToken)
        {
            var student = await _studentService.getStundentByIdAsync(request.id);
            if (student == null)
                return NotFound<GetStudentByIdRespones>(_stingLocalizer[SharedResourcesKeys.NotFound]); 
            var res = mapper.Map<GetStudentByIdRespones>(student); 

            return Success(res);
        }

        public Task<PaginatedResult<GetStudentPaginatedListRespones>> Handle(GetStudentPaginatedListQueries request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentPaginatedListRespones>> expression = e => new GetStudentPaginatedListRespones()
            {StudID = e.StudID , 
            Name = e.NameEn ,
             Address = e.Address ,
             DepartmentName = e.Department.DNameEn , 
             Phone = e.Phone ,
            };
            var querable =  _studentService.getStudentQueryablAsync(request.orderBy , request.Search).Select(expression);
            var paginationList = querable.ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginationList; 
        }
    }
}
