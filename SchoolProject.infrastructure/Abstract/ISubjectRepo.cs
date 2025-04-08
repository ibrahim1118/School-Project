using SchoolProject.Data.Entites;
using SchoolProject.infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.infrastructure.Abstract
{
    public interface ISubjectRepo : IGenericRepositoryAsync<Subjects>
    {
    }
}
