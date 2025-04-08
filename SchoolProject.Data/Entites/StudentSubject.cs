using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entites
{
    public class StudentSubject
    {
        [Key]
        public int StudID { get; set; }
        [Key]
        public int SubID { get; set; }

        public decimal grade {  get; set; }

        [ForeignKey("StudID")]
        [InverseProperty(nameof(Student.StudentsSubjects))]
        public virtual Student Student { get; set; }

        [ForeignKey("SubID")]
        [InverseProperty(nameof(Subjects.StudentsSubjects))]

        public virtual Subjects Subject { get; set; }

    }
}
