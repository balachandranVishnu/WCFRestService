using Harrods.Service.Employees.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Harrods.Service.Employees.BussinessValidations
{
    public static class  ValidationRules
    {
        public static void ValidateAddressRules(AddressEntity addressEntity)
        {
            try
            {
                StringBuilder summary = new StringBuilder();
                summary.Append(ValidateRegex(addressEntity.Phone,
                    @"(\+)(\d)(\d).*?(\d)(\d)(\d)(\d).*?(\d)(\d)(\d).*?(\d)", "Phone"));
                //{(\+)(\d)(\d).*?(\d)(\d)(\d)(\d).*?(\d)(\d)(\d).*?(\d)}
                summary.Append(ValidateRegex(addressEntity.Email, @"^.{8,}\w+[\w-\.]*\@\w+((-\w+)|(\w*))\.[a-z]{2,3}$"
                , "Email"));
                if (summary.Length != 0)
                    throw new BussinessRuleFailedException(String.Format("The following inputs are not following the bussiness rules.{0}"
                        , summary.ToString()));
            }
            catch(Exception)
            {
                throw;
            }
        }

         

        private static string ValidateRegex(string input, string regex, string property)
        {
            var match = Regex.Match(input, regex, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                return String.Format("{0} is not following the required format.", property);
            }
            return String.Empty;
        }
    }
}
