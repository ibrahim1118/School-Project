using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SchoolProject.Data.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entites
{
    public class Instructor : GeneralLocalizableEntity
    {
        [Key]
        public int InsId { get; set; }
        public string ENameAr { get; set; }
        public string ENameEn { get; set; }

        public string Address { get; set; }
        public string Position { get; set; }
        public int? SuperVisorId { get; set; }
        public decimal Salary { get; set; }
        public int DID { get; set; }

        [ForeignKey(nameof(DID))]
        [InverseProperty(nameof(Department.Instructors))]
        public virtual Department Department { get; set; }
        [InverseProperty(nameof(Department.Instructor))]
        public virtual Department DepartmentManager { get; set; }

        [ForeignKey(nameof(SuperVisorId))]
        [InverseProperty(nameof(Instructors))]
        public virtual Instructor SuperVisor { get; set; }

        [InverseProperty(nameof(SuperVisor))]
        public virtual ICollection<Instructor> Instructors { get; set; }

        [InverseProperty(nameof(Ins_Subject.Instructor))]
        public virtual ICollection<Ins_Subject> Ins_Subjects { get; set; }
    }
}
