using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Feature.Students.Commands.Modules;
using SchoolProject.Core.Feature.Students.Queries.Modules;
using SchoolProject.Data.Router;

namespace SchoolProject.API.Controllers
{
    [ApiController]
    public class StudentController : AppControllerBase
    {
        
        [HttpGet(Router.StudentRoute.List)]
        public async Task<IActionResult> GetStudentList()
        {
            var studnt = await Mediator.Send(new GetStudentListQueries());
            return Ok(studnt);
        }

        [HttpGet(Router.StudentRoute.PaginatedList)]
        public async Task<IActionResult> GetStudentPaginatedList([FromQuery] GetStudentPaginatedListQueries getStudentPaginatedListQueries)
        {
            var studnt = await Mediator.Send(getStudentPaginatedListQueries);
            return Ok(studnt);
        }

        [HttpGet(Router.StudentRoute.GetById)]


        public async Task<IActionResult> GetStudentByid(int id)
        {
            var student = await Mediator.Send(new GetStudentByIdQuerie() { id = id });
           return NewResult(student);
                   
        }

        [HttpPost(Router.StudentRoute.Creat)]
        public async Task<IActionResult> AddStudent(AddStudentCommand command)
        {
            var student = await Mediator.Send(command);
            return NewResult(student);

        }


        [HttpPut(Router.StudentRoute.Edit)]
        public async Task<IActionResult> EditStudent(EditStudentCommand command)
        {
            var student = await Mediator.Send(command);
            return NewResult(student);

        }

        [HttpDelete(Router.StudentRoute.Delete)]
        public async Task<IActionResult> DeleteStudent(int Id)
        {
            var student = await Mediator.Send(new DeleteStudentCommand() { id = Id});
            return NewResult(student);

        }
    }
}
