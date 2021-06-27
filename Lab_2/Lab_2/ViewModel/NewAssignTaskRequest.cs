using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_2.ViewModel
{
    public class NewAssignTaskRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public List<int> TasksAssiged { get; set; }
        public DateTime? TaskAssignDateTime { get; set; }

    }
}
