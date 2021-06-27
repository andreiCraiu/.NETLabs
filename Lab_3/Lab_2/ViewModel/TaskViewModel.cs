using Lab_2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_2.ViewModel
{
    public class TaskViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime Deadline { get; set; }
        public Importance Importance { get; set; }
        public State State { get; set; }
        public DateTime CloseTime { get; set; }

        internal ActionResult<IEnumerable<TaskViewModel>> ToList()
        {
            throw new NotImplementedException();
        }
    }
}
