using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Router
{
    public static class Router
    {
        public const string root = "Api/"; 
        public const string version = "1.0";
        public const string Rule = root + version + "/";

        public static class StudentRoute
        {

            public const string Prefix = Rule + "Student" + "/";
            public const string List = Prefix + "List";
            public const string GetById = Prefix + "{id}";
            public const string Creat = Prefix + "AddStudent"; 
            public const string Edit = Prefix + "EditStudent"; 
            public const string Delete = Prefix + "DeleteStudent";
            public const string PaginatedList = Prefix + "PaginatedList";
        }
        public static class DepartemtnRoute
        {

            public const string Prefix = Rule + "Department" + "/";
            public const string List = Prefix + "List";
            public const string GetById = Prefix + "{id}";
            public const string Creat = Prefix + "AddStudent";
            public const string Edit = Prefix + "EditStudent";
            public const string Delete = Prefix + "DeleteStudent";
            public const string PaginatedList = Prefix + "PaginatedList";
        }
    }
}
