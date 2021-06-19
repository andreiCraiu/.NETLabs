using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_2.ViewModel
{
    public class NewAssignTaskRequest
    {
        public int ID { get; set; }
        public List<int> TasksAssiged { get; set; }
        public DateTime? TaskAssignDateTime { get; set; }

    }
}
