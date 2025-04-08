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
    public class InstractorRep : GenericRepositoryAsync<Instructor> , IInstractorRepo
    {
        private readonly ApplactionDbContext context;

        public InstractorRep(ApplactionDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
