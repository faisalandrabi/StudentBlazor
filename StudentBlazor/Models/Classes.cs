using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentBlazor.Models
{
    public class Classes
    {
        [Key]
        public int Id { get; set; }
        public string class_name { get; set; }
    }
}
