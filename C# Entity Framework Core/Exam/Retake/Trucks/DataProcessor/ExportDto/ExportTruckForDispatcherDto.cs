using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Castle.DynamicProxy.Generators.Emitters;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Truck")]
    public class ExportTruckForDispatcherDto
    {
        [XmlElement("RegistrationNumber")]
        public string RegistrationNumber { get; set; }

        [XmlElement("Make")]
        public string Make { get; set; }
    }
}
