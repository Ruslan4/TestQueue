using DAL;
using DAL.Entities;
using System.Collections.Generic;
using System;

namespace BLL
{
    public class PeopleBLL
    {
        public dbConnection<Student> dbConnection;

        public PeopleBLL()
        {
            dbConnection = new dbConnection<Student>();

            List<Student> students = new List<Student>()
                {
                new Student(68754, "Oleg", "Ivanov",20),
                new Student(34556, "Andrey", "Tir",21),
                new Student(77656, "Alexa", "Ivanova",21),
                new Student(23456, "Petro", "Alexandrov",19),
                new Student(67568, "Oleg", "Ivanov",18)
            };

            dbConnection.SerializePerson(students);
        }

        public int CountStudent()
        {
            return dbConnection.GetAllPerson().Count;
        }

        public void ShowAllSudents()
        {
            foreach (var item in dbConnection.GetAllPerson())
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
        }

        public void AddStudent(List<Student> student)
        {
            dbConnection.SerializePerson(student);
        }
    }
}
