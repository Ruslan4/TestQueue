using DAL.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Entities
{
    public class Student : Person,IStudy
    {
        public Student(int studentID, string firstName, string lastName, int age)
        {
            StudentID = studentID;
            this.FirstName = firstName;
            this.LastName = lastName;
            Age = age;
        }
        public Student()
        {
        }
        [JsonProperty("studentId")]
        public int StudentID { get; private set; }

        public void Study()
        {
            throw new NotImplementedException();
        }
    }
}
