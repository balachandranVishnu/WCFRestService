using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Ninject.Modules;
using Ninject.Extensions.Wcf; 
using Ninject.Syntax;
using Harrods.Service.Employees.Contracts;
using Harrods.Service.Employees.Implementation;

/// <summary>
/// Generic test project using Ninject
/// </summary>
namespace Harrods.Service.Employees.UnitTest
{
    public class EmployeeServiceModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IEmployeeContract>().To<EmployeeImpl>();
        }
    }
}
