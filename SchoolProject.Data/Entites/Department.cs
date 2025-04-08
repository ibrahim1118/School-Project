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
    public partial class Department : GeneralLocalizableEntity
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmetSubject>();
        }
        [Key]
        public int DID { get; set; }
        [StringLength(500)]
        public string DNameAr { get; set; }
        public string DNameEn { get; set; }
        
        public int? InsManager { get; set; }

        [ForeignKey(nameof(InsManager))]
        [InverseProperty(nameof(Instructor.DepartmentManager))]
        public virtual Instructor Instructor { get; set; }
        [InverseProperty(nameof(Student.Department))]
        public virtual ICollection<Student> Students { get; set; }
        
        [InverseProperty(nameof(DepartmetSubject.Department))]
        public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; }

        [InverseProperty(nameof(Instructor.Department))]
         public virtual ICollection<Instructor> Instructors { get; set; }
       
    
    }
}
