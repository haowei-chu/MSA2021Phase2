using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MSA2021p2.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string GitHub { get; set; }

        public string ImageURI { get; set; }
        
        //New item
        public ICollection<Project> Projects { get; set; } = new List<Project>();

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
