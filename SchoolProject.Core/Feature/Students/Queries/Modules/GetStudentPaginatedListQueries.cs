using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolProject.Core.Feature.Students.Queries.Respones;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entites;
using SchoolProject.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Feature.Students.Queries.Modules
{
    public class GetStudentPaginatedListQueries  :IRequest<PaginatedResult<GetStudentPaginatedListRespones>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public StudnetOrderingEnum orderBy{ get; set; }

        public string? Search {  get; set; }
    }
}
