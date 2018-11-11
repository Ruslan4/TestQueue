using Newtonsoft.Json;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Teacher : Person, ITeacher, IStudy
    {
        [JsonProperty("teacherlicense")]
        public string TeacherLicense { get; private set; }

        [JsonProperty("ageteacher")]
        public int AgeTeacher { get; set; }

        public Teacher(string teacherLicense, string firstName, string lastName, int ageteacher, int age)
        {
            TeacherLicense = teacherLicense;
            this.FirstName = firstName;
            this.LastName = lastName;
            AgeTeacher = ageteacher;
            Age = age;
        }

        public void Teach()
        {
            throw new NotImplementedException();
        }

        public void Study()
        {
            throw new NotImplementedException();
        }
    }
}
