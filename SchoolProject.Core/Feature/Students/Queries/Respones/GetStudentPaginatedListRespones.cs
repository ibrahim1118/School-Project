﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Feature.Students.Queries.Respones
{
    public class GetStudentPaginatedListRespones
    {
        public int StudID { get; set; }
        
        public string Name { get; set; }
        
        public string Address { get; set; }
       
        public string Phone { get; set; }
        public string DepartmentName { get; set; }

        public GetStudentPaginatedListRespones()
        {
            
        }
      
    }
}
