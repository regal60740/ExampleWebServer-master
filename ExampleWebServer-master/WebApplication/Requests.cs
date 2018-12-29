using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication
{
    public class Requests
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Request { get; set; }
    }
}