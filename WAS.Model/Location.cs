using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WAS.Model
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        [Required]
        [Display(Name = "Location name")]
        public string LocationName { get; set; }
    }
}
