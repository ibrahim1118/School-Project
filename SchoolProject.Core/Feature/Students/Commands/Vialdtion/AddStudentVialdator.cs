using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SchoolProject.Core.Feature.Students.Commands.Modules;
namespace SchoolProject.Core.Feature.Students.Commands.Vialdtion
{
    public class AddStudentVialdator : AbstractValidator<AddStudentCommand>
    {
        public AddStudentVialdator()
        {
            ApplayValidationRule(); 
        }

         public void ApplayValidationRule()
        {
            RuleFor(x => x.NameAr).NotEmpty().NotNull(); 
            RuleFor(x => x.NameEn).NotEmpty().NotNull(); 
        }
    }
}
