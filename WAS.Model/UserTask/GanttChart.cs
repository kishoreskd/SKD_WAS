using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using WAS.Model;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WAS.Model
{
    public class GanttChart
    {
        [Key]
        public int GanttChartId { get; set; }
        public string BackgroundColour { get; set; }
        public string BorderColour { get; set; }
        //public string 

    }   
}
