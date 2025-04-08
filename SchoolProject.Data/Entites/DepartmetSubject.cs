using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolProject.Data.Commons;

namespace SchoolProject.Data.Entites
{
    public class DepartmetSubject : GeneralLocalizableEntity
    {
        [Key]
        public int DID { get; set; }
        [Key]
        public int SubID { get; set; }

        [ForeignKey("DID")]
        [InverseProperty(nameof(Department.DepartmentSubjects))]
        public virtual Department Department { get; set; }

        [ForeignKey("SubID")]
        [InverseProperty(nameof(Subjects.DepartmetsSubjects))]
        public virtual Subjects Subjects { get; set; }
    }
}
