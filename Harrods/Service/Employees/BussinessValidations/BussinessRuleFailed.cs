using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Wrapper for system exception. 
/// This is used to invoke custom exceptions while failing bussiness rules.
/// </summary>
namespace Harrods.Service.Employees.BussinessValidations
{
    public class BussinessRuleFailedException : Exception
    {
        public BussinessRuleFailedException() : base() { }
        public BussinessRuleFailedException(string message) : base(message) { }
        public BussinessRuleFailedException (string message, Exception innerException) : base(message, innerException) { }
    }
}
