using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAS.Utility
{
    public static class SD
    {
        public static class DATE
        {
            public const string WeekOf = "WeekOFF";
            public const string Holidays = "Holidays";
            public const string WorkingDays = "Working";
            public const string Submission = "Submission";
        }

        public static class ROLE
        {
            public const string Role_Login = "Login";
            public const string Role_Admin = "Admin";
            public const string Role_Manager = "Manager";
            public const string Role_User = "User";
            public const string Role_TeamLead = "TeamLead";


            //public const string Role_
            //= "Manager";
            //public const string Role_ProjectManager = "ProjectManager";
            //public const string Role_TL = "TL";
            //public const string Role_Employee = "User";
        }

        public static class Claims
        {
            private const string _default = "none";
            public const string Branch = "branch";
            public const string Department = "department";
            public const string Designation = "designation";
            public const string Role = "role";
            public const string Name = "name";
        }

        public static class Designation
        {
            private const string TL = "tl";
        }

        public static string Msg;
        public readonly static string Success = "SUCCESS";
        public readonly static string Error = "ERROR";



    }
}
