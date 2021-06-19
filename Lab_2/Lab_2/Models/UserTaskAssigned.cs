using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_2.Models
{
    public class UserTaskAssigned
    {
        public int ID { get; set; }
        public int ApplicationUserId{ get; set; }
        public IEnumerable<Models.Task> Tasks { get; set; }
        public DateTime DateAssigned { get; set; }
    }
}
