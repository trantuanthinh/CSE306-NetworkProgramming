using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assignment_3
{
    [Serializable]
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Address { get; set; }
        public string AvatarPath { get; set; }
    }
}
