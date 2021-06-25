using FluentValidation;
using Lab_2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_2.Validators
{
    public class TaskValidator : AbstractValidator <TaskViewModel>
    {
       public TaskValidator()
        {
            RuleFor(x => x.Description).MinimumLength(10);
            RuleFor(x => x.Title).MinimumLength(10);
        }
    }
}
