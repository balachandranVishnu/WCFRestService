﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Inhertied from autogenerated proxy class. 
/// </summary>
namespace Harrods.Proxy.Employees.ServiceProxy
{
    class EmployeeServiceProxy : EmployeeContractClient
    {
        public EmployeeServiceProxy()
        {
        }

        public EmployeeServiceProxy(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public EmployeeServiceProxy(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public EmployeeServiceProxy(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public EmployeeServiceProxy(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }
        }
    
}
