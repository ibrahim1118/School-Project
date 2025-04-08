using FluentValidation;
using SchoolProject.Core.Feature.Students.Commands.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Feature.Students.Commands.Vialdtion
{
    public class EditStudentValidator  :AbstractValidator<EditStudentCommand>
    {
        public EditStudentValidator()
        {
            ApplayValidationRule();
        }

        public void ApplayValidationRule()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not be Empty")
                .NotNull();
        }
    }
}
