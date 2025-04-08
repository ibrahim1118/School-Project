using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Abstract
{
    public interface IDepartmentServices
    {
        public Task<Department> GetDepartmentByIdAcync(int? id);
    }
}
