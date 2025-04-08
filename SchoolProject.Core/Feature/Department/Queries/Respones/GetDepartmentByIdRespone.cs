using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Feature.Department.Queries.Respones
{
    public class GetDepartmentByIdRespone
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? MangerName { get; set; }

        public List<StudentRespons> Students { get; set; }

        public List<InstractorRespons> Instractor {  get; set; }

        public List<SubjectRespons> Subject {  get; set; }
    }
    public class StudentRespons
    {
        public int Id { get; set; }
        public string StudentName { get; set; }

    }
    public class InstractorRespons 
    {
        public int Id { get; set; }
        public string InstractorName { get; set; }
    }
    public class SubjectRespons
    {
        public int id { get; set; }
        public string SubjectName { get; set; }
    }

}
