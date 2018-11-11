using DAL.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace DAL
{
    public class dbConnection<T>
    {
        public List<T> GetAllPerson()
        {
            List<T> people;

            using (StreamReader sr = new StreamReader("JsonFile.json"))
            {
                string line = sr.ReadToEnd();
                people = JsonConvert.DeserializeObject<List<T>>(line);
            }
            Console.WriteLine($"Deserialize");
            return people;
        }

        public void SerializePerson(List<T> messageResponse)
        {
            using (StreamWriter sw = new StreamWriter("JsonFile.json", false, System.Text.Encoding.Default))
            {
                string text = JsonConvert.SerializeObject(messageResponse);
                sw.WriteLine(text);
            }
        }
    }
}
