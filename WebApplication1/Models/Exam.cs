using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Exam
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required]
        [Range(0,10)]
        [Column("Mark")]
        [Display(Name = "Mark")]
        public int mark { get; set; }
    }
}