using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Feature.Department.Queries.Modules;
using SchoolProject.Data.Router;

namespace SchoolProject.API.Controllers
{
   
    [ApiController]
    public class DepartmentController : AppControllerBase
    {


        [HttpGet(Router.DepartemtnRoute.GetById)]
        public async Task<IActionResult> GetDepartemtnBy(int id) 
        {
            var res = await Mediator.Send(new GetDepartmentByIdQuery() { id = id }); 
            return NewResult(res);
        }
    }

}
