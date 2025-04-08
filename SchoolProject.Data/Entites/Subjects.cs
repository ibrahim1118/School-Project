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

    public class Subjects  : GeneralLocalizableEntity
    {
        public Subjects()
        {
            StudentsSubjects = new HashSet<StudentSubject>();
            DepartmetsSubjects = new HashSet<DepartmetSubject>();
        }
        [Key]
        public int SubID { get; set; }
        [StringLength(500)]
        public string SubjectNameAr { get; set; }
        public string SubjectNameEn { get; set; }

        public int Period { get; set; }

        [InverseProperty(nameof(StudentSubject.Subject))]
        public virtual ICollection<StudentSubject> StudentsSubjects { get; set; }
        [InverseProperty(nameof(DepartmetSubject.Subjects))]
        public virtual ICollection<DepartmetSubject> DepartmetsSubjects { get; set; }

        [InverseProperty(nameof(Ins_Subject.Subjects))]
        public virtual ICollection<Ins_Subject> InsSubjects { get; set; }
    }
}
