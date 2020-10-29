using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace Studnt_app.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public List<Student1> Get()
        {
            using (StreamReader r = new StreamReader("json.json")) {
                string json = r.ReadToEnd();
               List<Student1> students = JsonConvert.DeserializeObject<List<Student1>>(json);
                return students;
            }
        }
        [HttpPut]
        public void Add(Student1 student)
        {
            using (StreamReader r = new StreamReader("json.json"))
            {
                string json = r.ReadToEnd();
                List<Student1> students = JsonConvert.DeserializeObject<List<Student1>>(json);
                students.Add(student);
                var convertedJson = JsonConvert.SerializeObject(students, Formatting.Indented);
            }
            
        }
    }

    public class Student1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Adress { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public int Gender { get; set; }
        public string city { get; set; }
    }

   
}