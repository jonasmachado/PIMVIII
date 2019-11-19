using System;
using System.ComponentModel.DataAnnotations;

namespace HomeworkBuddy.Web.Filters
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class CpfAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var cpf = Convert.ToString(value);
            return true;
            //return CpfValido.ValidaCpf(RemoverCaracteresDoCpf.SomenteNumeros(cpf));
        }        
    }
}