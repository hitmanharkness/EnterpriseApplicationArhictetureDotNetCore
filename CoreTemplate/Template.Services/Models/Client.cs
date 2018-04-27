using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Template.Services.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Smarts { get; set; }
        [Range(0, 999)]
        public double Bodyfat { get; set; }
    }
}
