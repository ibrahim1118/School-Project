using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entites
{
    public class Ins_Subject
    {
        [Key]
        public int InsID { get; set; }
        [Key]
        public int SubId { get; set; }

        [ForeignKey("InsID")]
        [InverseProperty(nameof(Instructor.Ins_Subjects))]
        public Instructor Instructor { get; set; }
        [ForeignKey(nameof(SubId))]

        [InverseProperty(nameof(Subjects.InsSubjects))]
        public Subjects Subjects { get; set; }
             
    }
}
