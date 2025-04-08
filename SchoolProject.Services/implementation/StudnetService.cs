using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites;
using SchoolProject.Data.Helper;
using SchoolProject.infrastructure.Abstract;
using SchoolProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.implementation
{
    public class StudnetService : IStudentService
    {
        private readonly IStudentRepo studentRepo;

        public StudnetService(IStudentRepo studentRepo)
        {
            this.studentRepo = studentRepo;
        }

        public async Task<string> AddStudentAsync(Student student)
        {
            var stud = studentRepo.GetTableNoTracking().Where(x=>x.NameEn == student.NameEn).FirstOrDefault();
            if (stud is not null)
                return "Exist"; 
           await studentRepo.AddAsync(student);
            return "Added"; 

        }

        public async Task<string> DeleteStudentAsync(Student student)
        {
            await studentRepo.DeleteAsync(student);
            return "Success";
        }

        public async Task<string> EditStudentAsync(Student student)
        {
           await studentRepo.UpdateAsync(student);
            return "Success"; 
        }

        public async Task<List<Student>> getStudentListAsync()
        {
            return await studentRepo.GetStudentListAsync(); 
        }

        public IQueryable<Student> getStudentQueryablAsync(StudnetOrderingEnum order , string? Search)
        {
            var querabe = studentRepo.GetTableNoTracking().Include(x => x.Department).AsQueryable();

            if (Search != null)
            querabe = querabe.Where(x=>x.Address.Contains(Search )||x.NameEn.Contains(Search)).Include(x => x.Department).AsQueryable();

            switch(order)
            {
                case StudnetOrderingEnum.id:
                   querabe =  querabe.OrderBy(x => x.StudID); 
                    break;
                case StudnetOrderingEnum.name:
                    querabe = querabe.OrderBy(x => x.NameEn);
                    break;
                case StudnetOrderingEnum.address:
                    querabe = querabe.OrderBy(x => x.Address);
                    break;
                case StudnetOrderingEnum.deparmentName:
                    querabe = querabe.OrderBy(x => x.Department.DNameEn);
                    break;
            }

            return querabe; 
        }

        public async Task<Student> getStundentByIdAsync(int id)
        {
            return await studentRepo.GetTableNoTracking().Include(x => x.Department).FirstOrDefaultAsync(x=>x.StudID==id); 
        }
    }
}
