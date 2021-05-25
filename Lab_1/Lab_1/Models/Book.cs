using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_1.Models
{
    public class Book
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string PubliserHouse { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "The price should be greather than {0}")]
        public double Price { get; set;  }
    }
}
