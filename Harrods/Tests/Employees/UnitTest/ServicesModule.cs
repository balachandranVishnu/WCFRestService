using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harrods.Service.Employees.Contracts;
using Harrods.Service.Employees.Implementation;
using System.ServiceModel;

/// <summary>
/// Class for injecting serivce address binding and contract
/// </summary>
namespace Harrods.Service.Employees.UnitTest
{
    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            // Basic service host
            Kernel.Bind<NinjectServiceHelper<IEmployeeContract, EmployeeImpl>>()
                .ToSelf()
                .Named("Basic")
                .WithConstructorArgument("address", "http://localhost/EmployeeService/EmployeeServiceHost.svc")
                .WithConstructorArgument("binding", new BasicHttpBinding());

            

            // Rest service host
            Kernel.Bind<NinjectServiceHelper<IEmployeeContract, EmployeeImpl>>()
                .ToSelf()
                .Named("Rest")
                .WithConstructorArgument("address", "http://localhost/EmployeeService/EmployeeServiceHost.svc")
                .WithConstructorArgument("binding", new WebHttpBinding());
        }
    }
}
