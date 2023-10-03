using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WAS.Utility;
using WAS.Model;

namespace PGT_WAS.Areas.Manager.Helper
{
    public class ProjectHelper
    {
        private const string _mainRatio = "Main_Ratio";
        private const string _miscRatio = "Misc_Ratio";


        private readonly DateTime[] _holiDays = new DateTime[] {
                new DateTime(2023, 4, 14), new DateTime(2023, 05, 01),new DateTime(2023, 07, 04),
                new DateTime(2023, 08, 15), new DateTime(2023, 09, 06), new DateTime(2023, 10, 02),
                new DateTime(2023, 10, 23), new DateTime(2023, 11, 13), new DateTime(2023, 11, 23),
                new DateTime(2023, 12, 25)
        };


        public ProjectEstimation GetEstimation(Project_VM proj)
        {
            //Initializiation

            double mainH = proj.MainH;
            string mainStartDt = proj.MainStartDt;
            double miscH = proj.MiscH;
            string miscStartDate = proj.MiscStartDate;
            string ratio = proj.Ratio;
            int mainScheduleDt = proj.MainSDt;
            int miscScheduleDt = proj.MiscSDt;
            double whPerday = proj.WHPerday;

            double mainM = proj.MainModelersNdPercent;
            double mainD = proj.MainDetilersNdPercent;
            double mainC = proj.MainCheckersNdPercent;

            double miscM = proj.MainModelersNdPercent;
            double miscD = proj.MainDetilersNdPercent;
            double miscC = proj.MainCheckersNdPercent;


            double mainMresouce;
            double mainDresouce;
            double mainCresouce;

            double miscMresouce;
            double miscDresouce;
            double miscCresouce;

            //Total Hours
            double totalHours = TotalHours(mainH, miscH);

            //Ratio
            Dictionary<string, double[]> ratioPercent = Ratio(ratio, mainH, miscH);
            double rMain1 = ratioPercent[_mainRatio][0];
            double rMain2 = ratioPercent[_mainRatio][1];

            double rMisc1 = ratioPercent[_miscRatio][0];
            double rMisc2 = ratioPercent[_miscRatio][1];

            //Estimation Dates
            DateTime mainStartdt = COM.GetFormatedDate(mainStartDt);
            DateTime miscStartdt = COM.GetFormatedDate(miscStartDate);

            Dictionary<string, List<DateTime>> estimationDatesMain = EstimationDates(mainScheduleDt, mainStartdt);
            Dictionary<string, List<DateTime>> estimationDatesMisc = EstimationDates(mainScheduleDt, miscStartdt);


            //Resource
            double mainResource = TotalResource(rMain1, mainScheduleDt, whPerday);
            double miscResource = TotalResource(rMisc1, miscScheduleDt, whPerday);

            mainMresouce = ResourceAllocate(mainResource, mainM);
            mainDresouce = ResourceAllocate(mainResource, mainD);
            mainCresouce = ResourceAllocate(mainResource, mainC);

            miscMresouce = ResourceAllocate(miscResource, miscM);
            miscDresouce = ResourceAllocate(miscResource, miscD);
            miscCresouce = ResourceAllocate(miscResource, miscC);


            //ProjectEstimation estimation = new ProjectEstimation
            //{
            //    TotalH = totalHours,
            //    IFAR1 = rMain1,
            //    IFAR2 = rMain2,
            //    IFFR1 = rMisc1,
            //    IFFR2 = rMisc2,
            //    ResourcesMain = mainResource,
            //    ResourcesMisc = miscResource,
            //    MainMNd = mainMresouce,
            //    MainDNd = mainDresouce,
            //    MainCNd = mainCresouce,
            //    MiscMNd = miscMresouce,
            //    MiscDNd = miscDresouce,
            //    MiscCNd = miscCresouce,
            //    MainSubmissionDt = estimationDatesMain[SD.DATE.Submission][0].ToString(),
            //    MiscSubmissionDt = estimationDatesMisc[SD.DATE.Submission][0].ToString(),
            //};

            return new ProjectEstimation();
        }


        public double TotalHours(double mainH, double miscH)
        {
            return (mainH + miscH);
        }
        public Dictionary<string, double[]> Ratio(string ratio, double mainH, double miscH)
        {
            Dictionary<string, double[]> ratios = new Dictionary<string, double[]>();

            string[] a = ratio.Trim().Split(":");

            double r1 = COM.ToDouble(a[0]);
            double r2 = COM.ToDouble(a[2]);

            double main1 = COM.Percent(r1, mainH);
            double main2 = COM.Percent(r2, mainH);

            double misc1 = COM.Percent(r1, miscH);
            double misc2 = COM.Percent(r2, miscH);

            ratios.Add(_mainRatio, new double[] { main1, main2 });
            ratios.Add(_miscRatio, new double[] { misc1, misc2 });

            return ratios;
        }
        private Dictionary<string, List<DateTime>> EstimationDates(int ttlscheduledt, DateTime prodStartdt, bool excludeHolidays = true)
        {
            int scheduledate = ttlscheduledt;

            DateTime startdate = COM.GetFormatedDate(prodStartdt);
            DateTime endate = startdate.AddDays(scheduledate);

            DateTime[] dates = Enumerable.Range(0, 1 + endate.Subtract(startdate).Days).Select(dt => startdate.AddDays(dt)).OrderByDescending(dt => dt).ToArray();

            int totalWeekOf = (from dt in dates
                               where dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday
                               select dt).Count();

            if (excludeHolidays)
            {
                totalWeekOf += (from dt in dates
                                where _holiDays.Contains(dt)
                                select dt).Count();
            }

            endate = endate.AddDays(totalWeekOf);

            //Submission is week of add extra;
            do
            {
                if (endate.DayOfWeek == DayOfWeek.Saturday)
                {
                    endate = endate.AddDays(2);
                }

                if (endate.DayOfWeek == DayOfWeek.Sunday)
                {
                    endate = endate.AddDays(1);
                }

                //Extra check
            } while (endate.DayOfWeek == DayOfWeek.Saturday || endate.DayOfWeek == DayOfWeek.Sunday || _holiDays.Contains(endate));

            //New dates with adding week of/holidays
            dates = Enumerable.Range(0, 1 + endate.Subtract(startdate).Days).Select(dt => startdate.AddDays(dt)).ToArray();

            //Week of only
            List<DateTime> weekOf = dates.Where(dt => dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday).Select(dt => dt).ToList();

            //Holidays only
            List<DateTime> holiday = dates.Where(dt => _holiDays.Contains(dt)).Select(dt => dt).ToList();

            //Working days only
            List<DateTime> workingdays = dates.Where(dt => dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday).Select(dt => dt).ToList();
            if (excludeHolidays)
                workingdays.Where(dt => !_holiDays.Contains(dt)).Select(dt => dt);


            Dictionary<string, List<DateTime>> daysCol = new Dictionary<string, List<DateTime>>();

            daysCol.Add(SD.DATE.WeekOf, weekOf);
            daysCol.Add(SD.DATE.Holidays, holiday);
            daysCol.Add(SD.DATE.WorkingDays, workingdays);
            daysCol.Add(SD.DATE.Submission, new List<DateTime> { endate });

            return daysCol;
        }
        public double TotalResource(double totalH, int totalSchedule, double hoursPerDay)
        {
            return (totalH / (totalSchedule * hoursPerDay));
        }
        public double ResourceAllocate(double nOfresource, double percent)
        {
            return COM.Percent(percent, nOfresource);
        }
    }
}
