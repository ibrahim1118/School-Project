using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Feature.Department.Queries.Respones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Feature.Department.Queries.Modules
{
    public class GetDepartmentByIdQuery  :IRequest<Response<GetDepartmentByIdRespone>>
    {
        public int id { get; set; }
    }
}
