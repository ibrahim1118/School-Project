using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Feature.Students.Queries.Respones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Feature.Students.Queries.Modules
{
    public class GetStudentByIdQuerie : IRequest<Response<GetStudentByIdRespones>>
    {
        public int id { get; set; } 
    }
}
