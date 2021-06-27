using Lab_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_2.ViewModel
{
    public class AssignUserTasksForUserResponse
    {
        public List<TaskViewModel> Tasks { get; set; }
        public DateTime AssigUserTaskDateTime { get; set; }

    }
}
