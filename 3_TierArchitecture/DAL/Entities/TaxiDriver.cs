using Newtonsoft.Json;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class TaxiDriver : Person, ITeacher
    {
        public TaxiDriver(int driverLicense, string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            DriverLicense = driverLicense;
            Age = age;

        }
        [JsonProperty("driverlicense")]
        public int DriverLicense { get; private set; }

        public void Teach()
        {
            throw new NotImplementedException();
        }
    }
}
