using System;
using System.ComponentModel.DataAnnotations;

namespace HomeworkBuddy.Web.Filters
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class CheckDateRangeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (((DateTime)value).Date >= DateTime.Now.Date)
            {
                return true;
            }

            return false;
        }
    }
}