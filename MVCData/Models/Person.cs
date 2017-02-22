using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCData.Models
{
    public class Person
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string Cellphone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}