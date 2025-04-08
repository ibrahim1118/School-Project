using SchoolProject.Data.Entites;
using SchoolProject.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Abstract
{
     public interface IStudentService
    {
        public Task<List<Student>> getStudentListAsync();

        public IQueryable<Student> getStudentQueryablAsync(StudnetOrderingEnum order , string? Search);
        public Task<Student> getStundentByIdAsync(int id);


        public Task<string> AddStudentAsync(Student student); 

        public Task<string> EditStudentAsync(Student student);
        public Task<string> DeleteStudentAsync(Student student);

    }
}
