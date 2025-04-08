
using MediatR;
using SchoolProject.Core.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Feature.Students.Commands.Modules
{
    public class AddStudentCommand : IRequest<Response<string>>
    {

        [Required]
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(500)]
        public string Phone { get; set; }
        public int? DID { get; set; }
    }
}
