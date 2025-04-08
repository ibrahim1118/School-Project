using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolProject.Data.Entites;
using SchoolProject.Core.Feature.Students.Queries.Respones;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Feature.Students.Queries.Modules
{
    public class GetStudentListQueries : IRequest<Response< List<GetStudentListRespones>>>
    {
    }
}
