using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Studnt_app.Hubs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Studnt_app.Models;
using Microsoft.AspNetCore.SignalR;

namespace Studnt_app.Controllers
{
    public class HomeController : Controller
    {
       private readonly IHubContext<StudentHub> _hubcntx ;
       public HomeController(IHubContext<StudentHub>  hubcntx)
        {
              _hubcntx=hubcntx;
        }
        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            //Add new student and insert it into json file
            string convertedJson;
            //read from json
            using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "json.json"))
            {
                string json = r.ReadToEnd();
                List<Student> students = JsonConvert.DeserializeObject<List<Student>>(json);
                students.Add(student);
                 convertedJson = JsonConvert.SerializeObject(students, Formatting.Indented);
                            }
            //write all with new object
            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "json.json", convertedJson);

            _hubcntx.Clients.All.SendAsync("NewStudent", student);
            return RedirectToAction("ShowStudents");
        }

        public ActionResult AddStudent()
        {        
            return View();
        }

        public ActionResult ShowStudents()
        {
            // show students data
            using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory+"json.json"))
            {
                string json = r.ReadToEnd();
                List<Student> students = JsonConvert.DeserializeObject<List<Student>>(json);
                return View(students);
            }
        }

    }
}