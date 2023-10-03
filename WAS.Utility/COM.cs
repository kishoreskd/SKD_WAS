using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WAS.Utility
{
    public class COM
    {

        public enum NOTIFICATION
        {
            SUCCESS,
            ERROR
        }




        #region Valid Check
        public static bool IsValidID(int? num) => num != null && num > 0 ? true : false;

        public static bool IsNull<T>(T obj) where T : class
        {
            if (obj is null) return true;
            else return false;
        }
        public static bool IsAny<T>(IEnumerable<T> data)
        {
            return data != null && data.Any();
        }
        public static bool IsNullOrEmpty(string str) => string.IsNullOrEmpty(str) ? true : false;

        public static bool IsValidCount(int? count)
        {
            if (count == null) return false;
            return count > 0;
        }

        #endregion





        #region FilesOperation

        public static bool IsFileExist(string fileName) => System.IO.File.Exists(fileName) ? true : false;
        public static void FileDelete(string fileName) => File.Delete(fileName);
        public static void CopyTo(string fileName, string destination) => File.Copy(fileName, destination);
        public static string PathCombine(string fn1, string fn2) => Path.Combine(fn1, fn2);

        #endregion


        #region DateTime

        public static DateTime GetFormatedDate(DateTime date)
        {
            date = DateTime.ParseExact(date.ToString("dd/MM/yyyy"), "dd/MM/yyyy", null);
            return date;
        }

        public static DateTime GetFormatedDate(string date)
        {
            DateTime dt = DateTime.ParseExact(date, "dd/MM/yyyy", null);
            return dt;
        }

        public static string GetCusomizedDate(string date)
        {
            DateTime dt = DateTime.ParseExact(date, "dd/MM/yyyy", null);
            return dt.ToString("yyyy-MM-dd");
        }


        #endregion


        #region Conversion

        public static double ToDouble(string val) => Convert.ToDouble(val);

        #endregion


        #region Math

        public static double Percent(double percent, double val) => val * percent / 100;

        #endregion


     
    }

}
