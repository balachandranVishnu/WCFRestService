using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harrods.Service.Employees.Contracts;
using Harrods.Service.Employees.Implementation;
using System.Net;
using Harrods.Service.Employees.Entities;
 /// <summary>
 /// Generic Test project for SOAP and REST Testing
 /// </summary>
namespace Harrods.Service.Employees.UnitTest
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        private IKernel _kernel;

        
        public void FixtureSetup()
        {
            // Init Ninject
            _kernel = new StandardKernel();
            _kernel.Load<EmployeeServiceModule>();
            _kernel.Load<ServicesModule>();
        }

        [Test]
        public void GetAllEmployeesTest()
        {
            GetAllEmployeesTest("Basic");
        }

          
        private async void GetAllEmployeesTest(string protocol)
        {
            // Arrange
            using (var helper = _kernel.Get<NinjectServiceHelper<IEmployeeContract, EmployeeImpl>>(protocol))
            {
                using ((IDisposable)helper.Client)
                {
                    // Act
                    Task<IEnumerable<EmployeeEntity>> Result = helper.Client.GetAllEmployeesAsync();
                    IEnumerable<EmployeeEntity> Entities = await Result;
                    // Assert
                    Assert.IsNotNull(Entities);
                }
            }
        }

        
    }
}
