using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites;
using SchoolProject.infrastructure.Abstract;
using SchoolProject.infrastructure.Data;
using SchoolProject.infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.infrastructure.Repositores
{
    public class StudentRepo :  GenericRepositoryAsync<Student>, IGenericRepositoryAsync<Student> , IStudentRepo
    {
        private readonly ApplactionDbContext _context;

        public StudentRepo(ApplactionDbContext context) : base(context) 
        {
            _context = context;
        }
        public async Task<List<Student>> GetStudentListAsync()
        {
            return await _context.students.Include(st=>st.Department).ToListAsync();
        }
    }
}
