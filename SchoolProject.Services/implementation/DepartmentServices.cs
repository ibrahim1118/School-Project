using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites;
using SchoolProject.infrastructure.Abstract;
using SchoolProject.infrastructure.Repositores;
using SchoolProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.implementation
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartmentRepo departmentRepo;

        public DepartmentServices(IDepartmentRepo departmentRepo)
        {
            this.departmentRepo = departmentRepo;
        }
        public async Task<Department> GetDepartmentByIdAcync(int id)
        {
            var department = await departmentRepo.GetTableNoTracking()
                .Include(d => d.Instructor)
                .Include(d => d.Instructors)
                .Include(d => d.Students)
                .Include(d => d.DepartmentSubjects).ThenInclude(s=>s.Subjects).Where(d => d.DID == id).FirstOrDefaultAsync();
            return department; 
        }
    }
}
