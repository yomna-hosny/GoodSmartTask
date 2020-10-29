using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Studnt_app.Models
{
    // class that descripe student fields

    public class Student
    {
        // class that descripe student field
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
    }
}