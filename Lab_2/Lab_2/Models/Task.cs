using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_2.Models
{
    public class Task
    {
        public int ID { get; set; }
        //[Required]
        public string Title { get; set; }
        public string Description { get; set; }
       // [Required]
        public DateTime AddedTime { get; set; }
      //  [Required]
        public DateTime Deadline { get; set; }
      //  [Required]
        public Importance Importance { get; set; }
      //  [Required]
        public State State { get; set; }
        public DateTime CloseTime { get; set; }
        public List <UserTaskAssigned> UserTaskAssigneds { get; set; }

    }
}
