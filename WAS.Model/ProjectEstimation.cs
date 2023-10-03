
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WAS.Model
{
    public class ProjectEstimation
    {
        [Key]
        public int ProjectEstimationId { get; set; }

        public string IFAr1r2 { get; set; }
        public string IFFr1r2 { get; set; }

        public string MainSubmissionDt { get; set; }
        public string MiscSubmissionDt { get; set; }

        public double ResourcesMain { get; set; }
        public double ResourcesMisc { get; set; }



        public double MainMNd { get; set; }
        public double MainDNd { get; set; }
        public double MainCNd { get; set; }


        public double MiscMNd { get; set; }
        public double MiscDNd { get; set; }
        public double MiscCNd { get; set; }


        [ForeignKey("Project")]
        public int ProjectId { get; set; }
    }
}
