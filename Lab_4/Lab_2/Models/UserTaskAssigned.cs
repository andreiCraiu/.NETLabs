using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Lab_2.Models
{
    public class UserTaskAssigned
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public ApplicationUser ApplicationUser{ get; set; }
        public IEnumerable<Models.Task> Tasks { get; set; }
        public DateTime DateAssigned { get; set; }
    }
}

